using CleanMovie.Application;
using CleanMovie.Domain.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class UserLoginDtoRepository : IUserLoginDtoRepository
    {
        private readonly MovieDbContext _context;
        public UserLoginDtoRepository(MovieDbContext movieDbContext)
        {
            _context = movieDbContext;
        }
        public async Task<UserLoginDto> GetUserLogin(UserLoginDto userLoginDto)
        {
            try
            {
                var result = await _context.UserLoginDtos.Include(f => f.UserRoles).FirstOrDefaultAsync(f => f.UserName == userLoginDto.UserName && f.Password == userLoginDto.Password);
                return result;
            }
            catch
            {
                throw;
            }


        }
        public async Task<List<UserLoginDto>> GetUserLoginById(int? id)
        {
            try
            {
                //var result = await _context.UserLoginDtos.Where(f => (id >= 0 || f.Id == id) && (f.UserRolesId == 3)).ToListAsync();
                var result = await (from u in _context.UserLoginDtos
                                    where (id == null || u.Id == id) && (u.UserRolesId == 3)
                                    select new UserLoginDto
                                    {
                                        Id = u.Id
                                        ,
                                        UserName = u.UserName
                                        ,
                                        Password = u.Password
                                        ,
                                        UserRolesId = u.UserRolesId
                                        ,
                                        Email = u.Email
                                        ,
                                        FirstName = u.FirstName
                                        ,
                                        LastName = u.LastName

                                    }
                                   )
                                   .ToListAsync();
                return result;

            }
            catch
            {
                throw;
            }

        }
    }
}
