using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.PartialModels;
using CleanMovie.Domain.ReponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public class MovieRentalTransactionService : IMovieRentalTransactionService
    {
        private readonly IMovieRentalTransactionRepository _repository;

        public MovieRentalTransactionService(IMovieRentalTransactionRepository movieRentalTransactionRepository)
        {
            _repository = movieRentalTransactionRepository;
        }

        public async Task<List<MoviesRentalTransaction>> GetAllMoviesRentalTransaction(MoviesRentalTransaction userLoginDto)
        {
            return await _repository.GetAllMoviesRentalTransaction();
        }

        public async Task<ResponseData<List<MoviesRentalTransaction>>> GetMoviesRentalTransactionByCriteria(CriteriaTransaction request)
        {
            ResponseData<List<MoviesRentalTransaction>> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new List<MoviesRentalTransaction>()

            };
            try
            {
                var dbMoviesTrans = await _repository.GetMoviesRentalTransactionByCriteria(request);
                if (dbMoviesTrans == null)
                    return response;

                response.Data = dbMoviesTrans;
                response.RequestCode = "200";
                response.ResponseMessage = $"Get Movie Transaction success.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        public async Task<ResponseData<MoviesRentalTransaction>> CreateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            ResponseData<MoviesRentalTransaction> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new MoviesRentalTransaction()

            };
            try
            {
                var dbMoviesTrans = await _repository.CreateMoviesRentalTransaction(moviesRentalTransaction);
                if (dbMoviesTrans == null)
                    return response;

                response.Data = dbMoviesTrans;
                response.RequestCode = "200";
                response.ResponseMessage = $"Create Movie Transaction success.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<ResponseData<MoviesRentalTransaction>> GetMoviesRentalTransactionById(int id)
        {
            ResponseData<MoviesRentalTransaction> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new MoviesRentalTransaction()

            };
            try
            {
                var dbMoviesTrans = await _repository.GetMoviesRentalTransactionById(id);
                if (dbMoviesTrans == null)
                    return response;

                response.Data = dbMoviesTrans;
                response.RequestCode = "200";
                response.ResponseMessage = $"Get Movie Transaction success.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<ResponseData<MoviesRentalTransaction>> UpdateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            ResponseData<MoviesRentalTransaction> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new MoviesRentalTransaction()

            };
            try
            {
                var dbMoviesTrans = await _repository.UpdateMoviesRentalTransaction(moviesRentalTransaction);
                if (dbMoviesTrans == null)
                    return response;

                response.Data = dbMoviesTrans;
                response.RequestCode = "200";
                response.ResponseMessage = $"Update Movie Transaction success.";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public async Task<ResponseData<MoviesRentalTransaction>> DeleteMoviesRentalTransaction(int id)
        {
            ResponseData<MoviesRentalTransaction> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",

                Data = new MoviesRentalTransaction()

            };
            try
            {
                var dbMoviesTrans = await _repository.DeleteMoviesRentalTransaction(id);
                if (dbMoviesTrans == null)
                    return response;

                response.Data = dbMoviesTrans;
                response.RequestCode = "200";
                response.ResponseMessage = $"Delete Movie Transaction success.";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
