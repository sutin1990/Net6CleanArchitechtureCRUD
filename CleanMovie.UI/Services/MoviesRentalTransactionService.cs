using CleanMovie.Domain.DBModels;
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
        private readonly NotificationService _notificationService;

        public List<DataGridTransactions> MoviesRentalTransaction { get; set; } = new List<DataGridTransactions>();
        public MoviesRentalTransactionService(HttpClient http, NavigationManager navigationManager, DialogService dialogService, NotificationService notificationService)
        {
            _http = http;
            _navigationManager = navigationManager;
            _dialogService = dialogService;
            _notificationService = notificationService;
        }
        public async Task GetMoviesRentalTransactionByCriteria(CriteriaTransaction request)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/MovieRentalTransaction/GetMoviesRentalTransactionByCriteria", request);
                _ = this.SetMoviesRentalTransactionList(result);
            }
            catch(Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Get Data By Criteria Fail", Detail = $" Get Data By Criteria Fail, Error [{ex.Message}]"});
                throw;
            }
            
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
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Create Success", Detail = $"Create Transaction {moviesRentalTransaction?.Movie?.Name} Success", Duration = 4000 });
                }
                //_navigationManager.NavigateTo("moviesrentaltrans");
                //await SetMovie(result);
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Create Fail", Detail = $"Create Transaction {moviesRentalTransaction?.Movie?.Name} Fail,Error [{ex.Message}]"});
                throw;
            }
           
        }

        public async Task UpdateTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            try
            {
                var result = await _http.PutAsJsonAsync("api/MovieRentalTransaction/Update", moviesRentalTransaction);
                if (result != null)
                {
                    CriteriaTransaction req = new();
                    await this.GetMoviesRentalTransactionByCriteria(req);
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Update Success", Detail = $"Update Transaction {moviesRentalTransaction?.Movie?.Name} Success", Duration = 4000 });
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Update Fail", Detail = $"Update Transaction {moviesRentalTransaction?.Movie?.Name} Fail,Error [{ex.Message}]" });
                throw;
            }           
            //_navigationManager.NavigateTo("moviesrentaltrans");
            //await SetMovie(result);
        }

        public async Task DeleteTransaction(int id)
        {
            try
            {
                var result = await _http.DeleteAsync($"api/MovieRentalTransaction/Delete/{id}");
                if (result != null)
                {
                    MoviesRentalTransaction.RemoveAll(s => s.Id == id);
                    CriteriaTransaction req = new();
                    await this.GetMoviesRentalTransactionByCriteria(req);
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Delete Success", Detail = $"Delete Transaction {id} Success", Duration = 4000 });
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Delete Fail", Detail = $"Delete Transaction {id} Fail,Error [{ex.Message}]" });
                throw;
            }
            
            //_navigationManager.NavigateTo("moviesrentaltrans");            
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
            }
            return moviesRentalTransaction;
        }

        private void ShowNotification(NotificationMessage message)
        {
            _notificationService.Notify(message);
        }
    }
}
