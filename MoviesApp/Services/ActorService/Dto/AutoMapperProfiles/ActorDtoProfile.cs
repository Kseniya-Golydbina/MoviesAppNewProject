using AutoMapper;
using MoviesApp.Models;
using MoviesApp.Services.MovieService.Dto;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.ActorService.Dto.AutoMapperProfiles
{
    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}
