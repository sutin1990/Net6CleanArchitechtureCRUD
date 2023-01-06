using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public Task<ResponseData<Movie>> GetMovie(int id);
        public Movie CreateMovie(Movie movie);
        public Task<ResponseData<Movie>> EditMovies(Movie movie);

        public Task<ResponseData<Movie>> DeleteMovie(int id);
    }
}
