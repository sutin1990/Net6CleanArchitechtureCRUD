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
    public interface IMovieRentalTransactionService
    {
        public Task<List<MoviesRentalTransaction>> GetAllMoviesRentalTransaction(MoviesRentalTransaction userLoginDto);
        public Task<ResponseData<MoviesRentalTransaction>> GetMoviesRentalTransactionById(int id);
        public Task<ResponseData<List<MoviesRentalTransaction>>> GetMoviesRentalTransactionByCriteria(CriteriaTransaction request);

        public Task<ResponseData<MoviesRentalTransaction>> CreateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction);

        public Task<ResponseData<MoviesRentalTransaction>> UpdateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction);
        public Task<ResponseData<MoviesRentalTransaction>> DeleteMoviesRentalTransaction(int id);
    }
}
