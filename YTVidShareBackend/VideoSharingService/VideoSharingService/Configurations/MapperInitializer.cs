using AutoMapper;
using VideoSharingService.Data.DTOs;
using VideoSharingService.Data.Models;

namespace VideoSharingService.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<ApiUser, CreateUserDTO>().ReverseMap();
            CreateMap<Video, VideoDTO>().ReverseMap();
            CreateMap<Video, CreateVideoDTO>().ReverseMap();
            CreateMap<Reaction, ReactionDTO>().ReverseMap();
            CreateMap<Reaction, CreateReactionDTO>().ReverseMap();
        }
    }
}
