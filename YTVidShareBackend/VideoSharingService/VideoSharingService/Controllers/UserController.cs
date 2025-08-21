using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;
using VideoSharingService.Data.IRepository;
using VideoSharingService.Data.Models;
using VideoSharingService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoSharingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Mask the email address for logging purposes to avoid exposing private info
        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return "unknown";
            
            var parts = email.Split('@');
            var prefix = parts[0];
            var domain = parts[1];
            var maskedPrefix = prefix.Length <= 2
                ? prefix.Substring(0, 1) + "***"
                : prefix.Substring(0, 1) + new string('*', prefix.Length - 2) + prefix.Substring(prefix.Length - 1, 1);
            return $"{maskedPrefix}@{domain}";
        }

        // Hash email address using SHA256 for logging (not reversible)
        private string HashEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return "unknown";
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(email));
                return Convert.ToBase64String(bytes);
            }
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IAuthManager _authManager;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IMapper mapper, UserManager<ApiUser> userManager, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll();
                var result = _mapper.Map<IList<UserDTO>>(users);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpGet("{id:Guid}", Name = "GetUser")]
        [Authorize]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(x => x.Id == id);
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUser)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
        {
            var sanitizedEmail = userDTO.Email?.Replace("\r", "").Replace("\n", "");
            _logger.LogInformation($"Registration attempt for {sanitizedEmail}");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid post attempt {nameof(Register)}");
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            var sanitizedEmail = userDTO.Email?.Replace("\r", "").Replace("\n", "");
            _logger.LogInformation("Login attempt received.");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid post attempt {nameof(Login)}");
                return BadRequest(ModelState);
            }
            try
            {
                return !await _authManager.ValidateUser(userDTO) ? Unauthorized() : Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

    }
}
