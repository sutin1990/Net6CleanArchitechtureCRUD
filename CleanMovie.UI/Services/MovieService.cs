using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using Microsoft.AspNetCore.Components;

namespace CleanMovie.UI.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public MovieService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
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
            var result = await _http.PostAsJsonAsync("api/Movies/CreateMovie", movie);
            _navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        public async Task UpdateMovie(Movie movie)
        {
            _ = await _http.PutAsJsonAsync("api/Movies/UpdateMovie", movie);
            _navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        public async Task DeleteMovie(int id)
        {
            var result = await _http.DeleteAsync($"api/Movies/DeleteMovie/{id}");
            _ = SetMovie(result);
            //_navigationManager.NavigateTo("movies");
            //await SetMovie(result);
        }

        private async Task SetMovie(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Movie>>();
            Movies = response ?? Movies;
            _navigationManager.NavigateTo("movies");
        }
    }
}
