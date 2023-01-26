using CleanMovie.Domain.DBModels;

namespace CleanMovie.UI.Services
{
    public interface IMovieService
    {
        public Task GetAllMovies();
        public Task<Movie> GetMovie(int id);
        public Task CreateMovie(Movie movie);
        public Task UpdateMovie(Movie movie);
        public Task DeleteMovie(int id);
        public Task<Movie> OpenConfirm(Movie movie);
        public List<Movie> Movies { get; set; }

        
    }

    public static class SetIsDelete
    {
        public static bool IsDelete { get; set;}
    }
}
