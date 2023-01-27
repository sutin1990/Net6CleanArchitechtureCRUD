using CleanMovie.Domain.PartialModels;

namespace CleanMovie.UI.Services
{
    public interface IMoviesRentalTransactionService
    {
        public List<DataGridTransactions> MoviesRentalTransaction { get; set; }
        public Task GetMoviesRentalTransactionByCriteria(CriteriaTransaction request);
        public Task<MoviesRentalTransaction> GetMoviesRentalTransactionById(int id);
        public Task CreateTransaction(MoviesRentalTransaction moviesRentalTransaction);
        public Task UpdateTransaction(MoviesRentalTransaction moviesRentalTransaction);
        public Task DeleteTransaction(int id);
        public Task<MoviesRentalTransaction> OpenEditDialog(DataGridTransactions data);
    }
}
