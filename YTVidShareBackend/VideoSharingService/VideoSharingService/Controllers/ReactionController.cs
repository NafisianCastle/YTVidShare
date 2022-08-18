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
    public class ReactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReactionController> _logger;
        private readonly IMapper _mapper;

        public ReactionController(IUnitOfWork unitOfWork, ILogger<ReactionController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReactions()
        {
            try
            {
                var reactions = await _unitOfWork.Reactions.GetAll();
                var result = _mapper.Map<IList<ReactionDTO>>(reactions);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetReactions)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpGet("{id:int}",Name ="CreateReaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReaction(int id)
        {
            try
            {
                var reaction = await _unitOfWork.Reactions.Get(x => x.ReactionID == id);
                var result = _mapper.Map<ReactionDTO>(reaction);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetReaction)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateReaction([FromBody] CreateReactionDTO reactionDTO)
        {
            if (!ModelState.IsValid)
            {
                 _logger.LogError($"Invalid post attempt {nameof(CreateReaction)}");
                return BadRequest(ModelState);
            }
            try
            {
                var reaction = _mapper.Map<Reaction>(reactionDTO);
                await _unitOfWork.Reactions.Insert(reaction); 
                await _unitOfWork.Save();
                
                return Ok(reaction);
            }
            catch ( Exception ex)
            {   
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateReaction)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}
