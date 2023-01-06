using CleanMovie.Domain.ReponseModels;

namespace CleanMovie.UI.Services
{
    public interface IMoviesRentalTransactionService
    {
        public List<MoviesRentalTransaction> MoviesRentalTransaction { get; set; }
        public Task GetMoviesRentalTransactionByCriteria(RequestDataConditionTransaction request);
        public Task<MoviesRentalTransaction> GetMoviesRentalTransactionById(int id);
        public Task CreateTransaction(MoviesRentalTransaction moviesRentalTransaction);
        public Task UpdateTransaction(MoviesRentalTransaction moviesRentalTransaction);
        public Task DeleteTransaction(int id);
    }
}
