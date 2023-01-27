using CleanMovie.Domain.PartialModels;
using CleanMovie.UI.Pages.Component;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CleanMovie.UI.Services
{
    public class MoviesRentalTransactionService : IMoviesRentalTransactionService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly DialogService _dialogService;

        public List<DataGridTransactions> MoviesRentalTransaction { get; set; } = new List<DataGridTransactions>();
        public MoviesRentalTransactionService(HttpClient http, NavigationManager navigationManager, DialogService dialogService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _dialogService = dialogService;
        }
        public async Task GetMoviesRentalTransactionByCriteria(CriteriaTransaction request)
        {
            var result = await _http.PostAsJsonAsync("api/MovieRentalTransaction/GetMoviesRentalTransactionByCriteria", request);
            _ = this.SetMoviesRentalTransactionList(result);
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

        private async Task SetMoviesRentalTransactionList(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<ResponseData<List<DataGridTransactions>>>();
            var rawList = response?.Data;
            MoviesRentalTransaction = rawList ?? MoviesRentalTransaction;
            //_navigationManager.NavigateTo("movies");
        }


        public async Task CreateTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/MovieRentalTransaction/Create", moviesRentalTransaction);
                if (result != null)
                {
                    CriteriaTransaction req = new();
                    await this.GetMoviesRentalTransactionByCriteria(req);
                }
                //_navigationManager.NavigateTo("moviesrentaltrans");
                //await SetMovie(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task UpdateTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {            
            var result = await _http.PutAsJsonAsync("api/MovieRentalTransaction/Update", moviesRentalTransaction);
            if (result != null)
            {
                CriteriaTransaction req = new();
                await this.GetMoviesRentalTransactionByCriteria(req);
            }
            _navigationManager.NavigateTo("moviesrentaltrans");
            //await SetMovie(result);
        }

        public async Task DeleteTransaction(int id)
        {
            var result = await _http.DeleteAsync($"api/MovieRentalTransaction/Delete/{id}");
            if(result != null)
            {
                MoviesRentalTransaction.RemoveAll(s=>s.Id == id);
            }
            _navigationManager.NavigateTo("moviesrentaltrans");            
        }

        public async Task<MoviesRentalTransaction> OpenEditDialog(DataGridTransactions data)
        {
            MoviesRentalTransaction moviesRentalTransaction = null;
            var result = await _dialogService.OpenAsync<TransactionManageDialog>("Create Transaction",
                new Dictionary<string, object> { { "Data", data } }
                ,new DialogOptions(){ Width = "700px", Height = "512px", Resizable = false, Draggable = false });
            if (result != null)
            {
                moviesRentalTransaction = result;
                //moviesRentalTransaction = new MoviesRentalTransaction
                //{
                //    Id = result.Id,
                //    RentDate = result.RentDate,
                //    ReturnDate= result.ReturnDate,
                //    ExpiryDate= result.ExpiryDate,  
                //    LateFines = result.LateFines,
                //    MovieId = result.MovieId,
                //    CutomerId= result.CutomerId,
                //    StaffRentId= result.StaffRentId,
                //    StaffReturnId= result.StaffReturnId
                //};
            }
            return moviesRentalTransaction;
        }
    }
}
