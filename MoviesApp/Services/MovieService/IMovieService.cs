using System.Collections.Generic;
using MoviesApp.Models;
using MoviesApp.Services.MovieService.Dto;

namespace MoviesApp.Services.MovieService
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        IEnumerable<MovieDto> GetAllMovies();
        MovieDto UpdateMovie(MovieDto movieDto);
        MovieDto AddMovie(MovieDto movieDto);
        MovieDto DeleteMovie(int id);
    }
}
