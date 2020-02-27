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
    }
}