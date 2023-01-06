using CleanMovie.Domain.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieDbContext : DbContext,IMovieRentalDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { Id = 1, RoleName = "admin" },
                new UserRoles { Id = 2, RoleName = "staff" },
                new UserRoles { Id = 3, RoleName = "member" }
                );

            modelBuilder.Entity<UserLoginDto>().HasData(
                new UserLoginDto { Id = 1, UserName = "sutin1990", Password = "250933", Email = "sutin1990@hotmail.com", UserRolesId = 1 }

                );
            modelBuilder.Entity<MoviesRentalTransaction>().HasData(
                new MoviesRentalTransaction { Id = 1, MovieId = 8,CutomerId = 2,StaffRentId=1,RentDate=new DateTime(2022,12,15)}
                );
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserLoginDto> UserLoginDtos { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<MoviesRentalTransaction> MoviesRentalTransactions { get ; set ; }
    }
}
