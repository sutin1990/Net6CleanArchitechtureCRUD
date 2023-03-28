using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using CleanMovie.UI.Pages;
using CleanMovie.UI.Pages.Component;
using Microsoft.AspNetCore.Components;
using Radzen;
namespace CleanMovie.UI.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly DialogService _dialogService;
        public MovieService(HttpClient http, NavigationManager navigationManager, DialogService dialogService)
        {
            _http = http;
            _navigationManager = navigationManager;
            this._dialogService = dialogService;
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public async Task GetAllMovies()        
        {
            var result = await _http.GetFromJsonAsync<List<Movie>>("api/Movies/GetAllMovie");
            if (result != null)
            {
                Movies = result;
            }
            //throw new Exception("No data.");
        }

        public async Task<Movie> GetMovie(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseData<Movie>>($"api/Movies/GetMovie/{id}");
            if(result != null && result?.Data != null)
            {
                return result.Data;
            }
            
            throw new Exception("No data.");
        }

        public async Task CreateMovie(Movie movie)
        {
            await _http.PostAsJsonAsync("api/Movies/CreateMovie", movie);
            await GetAllMovies();
            //_navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        public async Task UpdateMovie(Movie movie)
        {
            _ = await _http.PutAsJsonAsync("api/Movies/UpdateMovie", movie);
            await GetAllMovies();
            //_navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        public async Task DeleteMovie(int id)
        {
            var result = await _http.DeleteAsync($"api/Movies/DeleteMovie/{id}");
            await GetAllMovies();
            //_navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        private async Task SetMovie(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Movie>>();
            Movies = response ?? Movies;
            _navigationManager.NavigateTo("movies");
        }

        public async Task<Movie> OpenConfirm(Movie movie)
        {
           var result = await _dialogService.OpenAsync<ConfirmDialog>("Confirm Delete");
            if(result != null)
            {
                movie.IsDeleted = result;
            }            
            return movie;
        }
    }
}
