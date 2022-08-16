﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoSharingService.Data.DTOs;
using VideoSharingService.Data.IRepository;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVideos()
        {
            try
            {
                var videos = await _unitOfWork.Videos.GetAll();
                var result = _mapper.Map<IList<VideoDTO>>(videos);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetVideos)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVideo(int id)
        {
            try
            {
                var video = await _unitOfWork.Videos.Get(x => x.VideoID == id, new List<string> {"Reactions"});
                var result = _mapper.Map<VideoDTO>(video);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetVideo)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}