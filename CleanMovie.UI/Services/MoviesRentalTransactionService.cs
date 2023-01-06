using CleanMovie.Domain.ReponseModels;
using Microsoft.AspNetCore.Components;

namespace CleanMovie.UI.Services
{
    public class MoviesRentalTransactionService : IMoviesRentalTransactionService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public List<MoviesRentalTransaction> MoviesRentalTransaction { get; set; } = new List<MoviesRentalTransaction>();
        public MoviesRentalTransactionService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetMoviesRentalTransactionByCriteria(RequestDataConditionTransaction request)
        {
            var result = await _http.PostAsJsonAsync("api/MovieRentalTransaction/GetMoviesRentalTransactionByCriteria", request);
            _ = this.SetMoviesRentalTransaction(result);
        }

        public async Task<MoviesRentalTransaction> GetMoviesRentalTransactionById(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseData<MoviesRentalTransaction>>($"api/MovieRentalTransaction/GetMoviesRentalTransactionById/{id}");
            if (result != null && result?.Data != null)
            {
                return result.Data;
            }

            throw new Exception("No data.");
        }

        private async Task SetMoviesRentalTransaction(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<ResponseData<List<MoviesRentalTransaction>>>();
            var rawList = response?.Data;
            MoviesRentalTransaction = rawList ?? MoviesRentalTransaction;
            //_navigationManager.NavigateTo("movies");
        }

        public async Task CreateTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            var result = await _http.PostAsJsonAsync("api/MovieRentalTransaction/Create", moviesRentalTransaction);
            _navigationManager.NavigateTo("moviesrentaltrans");
            //await SetMovie(result);
        }

        public async Task UpdateTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            var result = await _http.PutAsJsonAsync("api/MovieRentalTransaction/Update", moviesRentalTransaction);
            _navigationManager.NavigateTo("moviesrentaltrans");
            //await SetMovie(result);
        }

        public async Task DeleteTransaction(int id)
        {
            var result = await _http.DeleteAsync($"api/MovieRentalTransaction/Delete/{id}");
            _navigationManager.NavigateTo("moviesrentaltrans");            
        }
    }
}
