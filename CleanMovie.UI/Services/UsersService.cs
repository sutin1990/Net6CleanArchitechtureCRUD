using Microsoft.AspNetCore.Components;

namespace CleanMovie.UI.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public List<UserLoginDto> Customers { get; set; } = new List<UserLoginDto>();
        public UsersService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetUsers(int? id)
        {
            string uri = "api/Users/GetUserById";
            if(id != null)
            {
                uri += $"/{id}";
            }
            var result = await _http.GetFromJsonAsync<ResponseData<List<UserLoginDto>>>(uri);
            if (result != null)
            {
                Customers = result?.Data ?? Customers;
            }
        }

        private async Task SetUserLoginDto(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<ResponseData<List<UserLoginDto>>>();
            var rawList = response?.Data;
            Customers = rawList ?? Customers;
            //_navigationManager.NavigateTo("movies");
        }
    }
}
