using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Models;
using Vidly.Web.Repositories;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = movieRepository.GetMovie(id);

            if (movie == null)
                return NotFound();
            //return NotFound("The movie does not exist in the database.");

            return View(movie);
        }

        [Route("movies")]
        public IActionResult Index()
        {
            var movies = movieRepository.GetAllMovies();

            return View(movies);
        }
    }
}