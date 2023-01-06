using CleanMovie.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Task<Movie> GetMovie(int id);
        Movie CreateMovie(Movie movie);
        Task<Movie> EditMovies(Movie movie);
        Task<Movie> DeleteMovie(int id);
    }
}
