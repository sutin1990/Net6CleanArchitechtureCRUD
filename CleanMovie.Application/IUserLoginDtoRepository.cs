using CleanMovie.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public interface IUserLoginDtoRepository
    {
        public Task<UserLoginDto> GetUserLogin(UserLoginDto userLoginDto);
        public Task<List<UserLoginDto>> GetUserLoginById(int? id);
    }
}
