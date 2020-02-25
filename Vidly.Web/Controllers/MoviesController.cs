using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Models;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Matrix"},
                new Movie {Id = 3, Name = "Die Hard"},
            };

            var movie = movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            //return NotFound("The movie does not exist in the database.");

            return View(movie);
        }

        [Route("movies")]
        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Matrix"},
                new Movie {Id = 3, Name = "Die Hard"},
            };

            return View(movies);
        }
    }
}