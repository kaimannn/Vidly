using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;
using Vidly.Web.Repositories;

namespace Vidly.Web.Mocks.Repositories
{
    public class MockMovieRepository : IMovieRepository
    {
        enum Genres
        {
            Comedy = 1,
            Action = 2,
            ScienceFiction = 3,
        }

        public Movie GetMovie(int movieId)
        {
            return GetMovies().SingleOrDefault(m => m.Id == movieId);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return GetMovies();
        }

        private Movie CreateMovie(int movieId, string movieName, int numInStock, Genres genre)
        {
            return new Movie
            {
                Id = movieId,
                Name = movieName,
                NumInStock = numInStock,
                DateAdded = DateTime.Now,
                ReleaseDate = DateTime.Now,
                GenreId = (byte)genre.GetHashCode(),
                Genre = new Genre 
                { 
                    Id = (byte)genre.GetHashCode(), 
                    Name = genre.ToString() 
                }
            };
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                CreateMovie(1, "Hangover", 5, Genres.Comedy),
                CreateMovie(2, "Die Hard", 2, Genres.Action),
                CreateMovie(3, "Interestellar", 10, Genres.ScienceFiction)
            };
        }
    }
}