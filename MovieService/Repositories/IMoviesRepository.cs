using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieService.Model;
using MovieService.Dto;
using MoviesLibrary;

namespace MovieService.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieData>> SearchMoviesAsync(int MovieId, string Title, string Genre, string Classification, int ReleaseDate, int Rating, string[] Cast);
        Task<IEnumerable<MovieData>> SortedMovieListAsync(string sortedFilter);

        Movie InsertMovie(Movie movie);

        void UpdateMovie(Movie movie);
    }
}
