using AutoMapper;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
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
    public class VideoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VideoController> _logger;
        private readonly IMapper _mapper;

        public VideoController(IUnitOfWork unitOfWork, ILogger<VideoController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpCacheValidation(MustRevalidate =true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVideos([FromQuery] RequestParams requestParams)
        {
            try
            {
                var videos = await _unitOfWork.Videos.GetPagedList(requestParams);
                var result = _mapper.Map<IList<VideoDTO>>(videos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetVideos)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpGet("{id:int}", Name = "GetVideo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVideo(int id)
        {
            try
            {
                var video = await _unitOfWork.Videos.Get(x => x.VideoID == id, new List<string> { "Reactions" });
                var result = _mapper.Map<VideoDTO>(video);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetVideo)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }


        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateVideo([FromBody] CreateVideoDTO videoDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid post attempt {nameof(CreateVideo)}");
                return BadRequest(ModelState);
            }
            try
            {
                var video = _mapper.Map<Video>(videoDTO);
                await _unitOfWork.Videos.Insert(video);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetVideo", new { id = video.VideoID }, video);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateVideo)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateVideo(int id, [FromBody] UpdateVideoDTO videoDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt {nameof(UpdateVideo)}");
                return BadRequest(ModelState);
            }
            try
            {
                var video = await _unitOfWork.Videos.Get(x => x.VideoID == id);
                if (video == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt {nameof(UpdateVideo)}");
                    return BadRequest(ModelState);

                }
                _mapper.Map(videoDTO, video);
                _unitOfWork.Videos.Update(video);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateVideo)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}
