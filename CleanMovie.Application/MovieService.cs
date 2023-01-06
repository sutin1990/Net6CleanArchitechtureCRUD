using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie CreateMovie(Movie movie)
        {
            return _movieRepository.CreateMovie(movie);            
        }       

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();            
        }
        public async Task<ResponseData<Movie>> EditMovies(Movie movie)
        {
            ResponseData<Movie> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new Movie()

            };
            var dbMovies = await _movieRepository.EditMovies(movie);
            if (dbMovies == null)
                return response;

            response.Data = dbMovies;
            response.RequestCode = "200";
            response.ResponseMessage = $"Update Movie {dbMovies.Name} success.";
            return response;

        }

        public async Task<ResponseData<Movie>> GetMovie(int id)
        {
            ResponseData<Movie> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",
                
                Data = new Movie()

            };
            var dbMovie = await _movieRepository.GetMovie(id);
            if (dbMovie == null)
                return response;

            response.Data = dbMovie;
            response.RequestCode = "200";
            response.ResponseMessage = "Get data by id success.";
            return response;

        }

        public async Task<ResponseData<Movie>> DeleteMovie(int id)
        {
            ResponseData<Movie> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Cannot delete, data not found.",
                Data = new Movie()

            };
            var dbMovies = await _movieRepository.DeleteMovie(id);
            if (dbMovies == null)
                return response;

            response.Data = dbMovies;
            response.RequestCode = "200";
            response.ResponseMessage = $"Delete Movie {dbMovies.Name} success.";
            return response;
        }
    }
}
