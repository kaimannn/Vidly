using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int NumInStock { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}
