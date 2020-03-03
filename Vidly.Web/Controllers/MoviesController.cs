using Microsoft.AspNetCore.Mvc;
using Vidly.Web.Models;
using Vidly.Web.Repositories;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MoviesController(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = _movieRepository.GetMovie(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.GetAllMovies();

            return View(movies);
        }

        public IActionResult New()
        {
            var genres = _genreRepository.GetAllGenres();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _movieRepository.AddMovie(movie);
            else
                _movieRepository.UpdateMovie(movie);

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieRepository.GetMovie(id);

            if (movie == null)
                return NotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _genreRepository.GetAllGenres()
            };

            return View("MovieForm", viewModel);
        }
    }
}