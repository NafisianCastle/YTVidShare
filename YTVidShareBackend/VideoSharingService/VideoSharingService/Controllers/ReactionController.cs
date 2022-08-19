using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;
using VideoSharingService.Data.IRepository;
using VideoSharingService.Data.Models;


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
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReactions(int id)
        {
            try
            {
                var reactions = await _unitOfWork.Reactions.GetAll(x => x.VideoID == id);
                var result = _mapper.Map<IList<ReactionDTO>>(reactions);
                var reactionList = new List<ReactorDTO>();

                foreach (var item in result)
                {
                    var singleReaction = new ReactorDTO();
                    singleReaction.ReactedUserName = _unitOfWork.Users.Get(x => x.Id == item.ReactedUserID).Result.UserName;
                    singleReaction.ReactedUserID = item.ReactedUserID;
                    singleReaction.Value = item.Value;
                    reactionList.Add(singleReaction);
                }
                var uploaderID = _unitOfWork.Videos.Get(x => x.VideoID == id).Result.UserEmail;

                var videoDetails = new VideoDetails();
                videoDetails.ReactorDTOs = reactionList;
                videoDetails.UploaderUserName = _unitOfWork.Users.Get(x => x.Id == uploaderID).Result.UserName;

                return Ok(videoDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetReactions)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveReaction([FromBody] CreateReactionDTO reactionDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid post attempt {nameof(SaveReaction)}");
                return BadRequest(ModelState);
            }
            try
            {
                var videoExist = await _unitOfWork.Reactions.GetAll(x => x.VideoID == reactionDTO.VideoID);

                var exist = (from video in videoExist
                             where video.ReactedUserID == reactionDTO.ReactedUserID
                             select video).FirstOrDefault();

                if (exist != null && videoExist != null)
                {

                    _mapper.Map(reactionDTO, exist);
                    _unitOfWork.Reactions.Update(exist);
                    await _unitOfWork.Save();
                }
                else
                {
                    var reaction = _mapper.Map<Reaction>(reactionDTO);
                    await _unitOfWork.Reactions.Insert(reaction);
                    await _unitOfWork.Save();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(SaveReaction)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

    }
}
