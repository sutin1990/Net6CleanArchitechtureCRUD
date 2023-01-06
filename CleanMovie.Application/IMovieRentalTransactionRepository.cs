using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public interface IMovieRentalTransactionRepository
    {
        public Task<List<MoviesRentalTransaction>> GetAllMoviesRentalTransaction();
        public Task<MoviesRentalTransaction> GetMoviesRentalTransactionById(int id);
        public Task<List<MoviesRentalTransaction>> GetMoviesRentalTransactionByCriteria(RequestDataConditionTransaction request);
        public Task<MoviesRentalTransaction> CreateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction);
        Task<MoviesRentalTransaction> UpdateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction);
        Task<MoviesRentalTransaction> DeleteMoviesRentalTransaction(int id);
    }
}
