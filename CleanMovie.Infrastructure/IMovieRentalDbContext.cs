using CleanMovie.Domain.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public interface IMovieRentalDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<UserLoginDto> UserLoginDtos { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }
        DbSet<MoviesRentalTransaction> MoviesRentalTransactions { get; set; }
    }
}
