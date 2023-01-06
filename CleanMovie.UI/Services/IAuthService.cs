using CleanMovie.Domain.DBModels;

namespace CleanMovie.UI.Services
{
    public interface IAuthService
    {
        public Task<UserLoginDtoResponse> LoginDto(UserLoginDto request);
    }
}
