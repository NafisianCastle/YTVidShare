using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;
using VideoSharingService.Data.IRepository;
using VideoSharingService.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoSharingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName ="120SecondsDuration")]
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

        [HttpGet("{id:int}",Name ="CreateUser")]
        [ResponseCache(CacheProfileName ="120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(x => x.UserID == id, new List<string> {"Videos"});
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUser)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                 _logger.LogError($"Invalid post attempt {nameof(CreateUser)}");
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.Insert(user); 
                await _unitOfWork.Save();
                
                return CreatedAtRoute("CreateUser", new {id = user.UserID}, user);
            }
            catch ( Exception ex)
            {   
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateUser)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}
