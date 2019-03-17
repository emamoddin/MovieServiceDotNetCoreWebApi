using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Model
{
    public class Movie
    {
        public MoviesLibrary.MovieData MovieData { get; set; }        
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public int ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string[] Cast { get; set; }
    }
}
