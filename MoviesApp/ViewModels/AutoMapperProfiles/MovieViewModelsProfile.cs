﻿using AutoMapper;
using MoviesApp.Services.Dto;
using MoviesApp.ViewModels.Movies;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class MovieViewModelsProfile : Profile
    {
        public MovieViewModelsProfile()
        {
            CreateMap<MovieDto, InputMovieViewModel>().ReverseMap();
            CreateMap<MovieDto, DeleteMovieViewModel>();
            CreateMap<MovieDto, EditMovieViewModel>().ReverseMap();
            CreateMap<MovieDto, MovieViewModel>();
        }
    }
}