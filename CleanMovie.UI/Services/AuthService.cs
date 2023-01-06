using CleanMovie.Domain.DBModels;

namespace CleanMovie.UI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<UserLoginDtoResponse> LoginDto(UserLoginDto request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            var data = await result.Content.ReadFromJsonAsync<UserLoginDtoResponse>();
            return data;
        }
    }
}
