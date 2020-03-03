using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;

namespace Vidly.Web.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenre(int genreId);
    }

    public class SQLGenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLGenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Genre GetGenre(int genreId)
        {
            return _context.Genres.SingleOrDefault(g => g.Id == genreId);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }
    }
}