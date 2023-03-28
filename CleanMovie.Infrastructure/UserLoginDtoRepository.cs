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
        public async Task<UserLoginDto?> GetUserLogin(UserLoginDto userLoginDto)
        {
            return await _context.UserLoginDtos.Include(f => f.UserRoles).FirstOrDefaultAsync(f => f.UserName == userLoginDto.UserName && f.Password == userLoginDto.Password);
        }
        public async Task<List<UserLoginDto>> GetUserLoginById(int? id)
        {
            return await (from u in _context.UserLoginDtos
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

                          }).ToListAsync();
        }
    }
}
