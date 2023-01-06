using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;

namespace CleanMovie.Application
{
    public interface IUserLoginDtoService
    {
        public Task<ResponseData<UserLoginDto>> GetUserLogin(UserLoginDto userLoginDto);
        public Task<ResponseData<List<UserLoginDto>>> GetUserLoginById(int? id);
    }
}
