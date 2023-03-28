using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using LogUtility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public class UserLoginDtoService : IUserLoginDtoService
    {
        IUserLoginDtoRepository _userLoginDtoRepository;
        ILoggerService _loggerService;
        public UserLoginDtoService(IUserLoginDtoRepository userLoginDtoRepository,ILoggerService loggerService)
        {
            _userLoginDtoRepository = userLoginDtoRepository;
            _loggerService = loggerService;

        }
        public async Task<ResponseData<UserLoginDto>> GetUserLogin(UserLoginDto userLoginDto)
        {
            ResponseData<UserLoginDto> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",
                Data = new UserLoginDto()
            };
            try
            {
               
                _loggerService.Info($"Class: {this.GetType().Name},Method:GetUserLogin ,Parameter is null {(userLoginDto is null)}");
                var dbUser = await _userLoginDtoRepository.GetUserLogin(userLoginDto);
                if (dbUser == null)
                    return response;

                response.Data = dbUser;
                response.RequestCode = "200";
                response.ResponseMessage = "Get data by id success.";
            }
            catch(Exception ex)
            {
                _loggerService.Error(ex.Message, ex);
                throw;
            }            
            return response;
        }

        public async Task<ResponseData<List<UserLoginDto>>> GetUserLoginById(int? id)
        {
            ResponseData<List<UserLoginDto>> response = new()
            {
                RequestCode = "404",
                ResponseMessage = "Data not found.",
                Data = new List<UserLoginDto>()
            };
            var dbUser = await _userLoginDtoRepository.GetUserLoginById(id);
            if (dbUser == null)
                return response;

            response.Data = dbUser;
            response.RequestCode = "200";
            response.ResponseMessage = "Get data by id success.";
            return response;
        }
    }
}
