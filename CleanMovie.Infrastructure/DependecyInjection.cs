using CleanMovie.Application;
using LogUtility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public static class DependecyInjection
    { 
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services,IConfiguration configuration)
        {
            //Add DbContext 
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CleanMovie.API")), ServiceLifetime.Transient);

            services.AddScoped<IMovieRentalDbContext>(provider =>
            provider.GetService<MovieDbContext>());

            //Add DI
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserLoginDtoRepository, UserLoginDtoRepository>();
            services.AddScoped<IUserLoginDtoService, UserLoginDtoService>();
            services.AddScoped<IMovieRentalTransactionRepository, MovieRentalTransactionRepository>();
            services.AddScoped<IMovieRentalTransactionService, MovieRentalTransactionService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddMediatR(typeof(MovieService).GetTypeInfo().Assembly);
            
            return services;
        }
    }
}
