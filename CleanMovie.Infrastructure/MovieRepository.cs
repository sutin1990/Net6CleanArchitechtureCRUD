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
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> movies = new()
        {
            new Movie{Id = 1,Name = "Test Move 1",Cost = 200},
            new Movie{Id = 2,Name = "Test Move 2",Cost = 300}
        };

        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _context = movieDbContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            var res = _context.Movies.ToList();
            return res;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(f => f.Id == id);
            return dbMovie;
        }

        public async Task<Movie> EditMovies(Movie movie)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(f => f.Id == movie.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = movie.Name;
                dbMovie.Cost = movie.Cost;

                await _context.SaveChangesAsync();
            }
            return dbMovie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(f => f.Id == id);

            if (dbMovie != null)
            {
                _context.Remove(dbMovie);
                await _context.SaveChangesAsync();
            }

            return dbMovie;

        }
    }
}
