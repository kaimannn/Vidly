using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;

namespace Vidly.Web.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int movieId);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }

    public class SQLMovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLMovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie GetMovie(int movieId)
        {
            return _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == movieId);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        public void AddMovie(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.NumInStock = movie.NumInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

        }
    }
}