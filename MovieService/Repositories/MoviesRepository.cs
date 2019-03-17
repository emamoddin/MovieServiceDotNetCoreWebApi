using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieService.Configuration;
using MovieService.Model;
using MovieService.Dto;
using MoviesLibrary;
using AutoMapper;

namespace MovieService.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private static MovieDataSource _moviesCollection;

        public MoviesRepository(MovieDataSource moviesCollection)
        {
            _moviesCollection = moviesCollection;
        }

        /// <summary>
        /// SearchMovies - looks up movie collection based on below filter criteria.
        /// </summary>
        /// <param name="MovieId"></param>
        /// <param name="Title"></param>
        /// <param name="Genre"></param>
        /// <param name="Classification"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="Rating"></param>
        /// <param name="Cast"></param>
        public async Task<IEnumerable<MovieData>> SearchMoviesAsync(int MovieId, string Title, string Genre,  string Classification, int ReleaseDate, int Rating, string[] Cast)
        {
            // TODO: User input validation
            // TODO: Improvement Add service method with await. Add Definition for GetAwaiter to List<MovieData> by updating MovieLibrary. Currently it will be syncronus.
            // TODO: Filter Implementation
            var Movies = _moviesCollection.GetAllData();            

            return Movies;
        }

        /// <summary>
        /// SortedMovieList - looks up movie collection based on below filter criteria.
        /// </summary>
        /// <param name="MovieId"></param>
        /// <param name="Title"></param>
        /// <param name="Genre"></param>
        /// <param name="Classification"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="Rating"></param>
        public async Task<IEnumerable<MovieData>> SortedMovieListAsync(string sortedFilter)
        {
            // TODO: User input validation
            // TODO: Improvement Add service method with await. Add Definition for GetAwaiter to List<MovieData> by updating MovieLibrary.
            // Currently it will be syncronus
            var Movies = _moviesCollection.GetAllData();
            List<MovieData> SortedMovieList = Movies.OrderBy(o => o.Title).ToList(); 
            //SortedMovieList = Movies.OrderBy(o => o.Title).ToList();
            //if (sortedFilter != null)
            //{
            //    //SortedMovieList = Movies.OrderBy(o => o + "." +sortedFilter).ToList();
            //}

            return SortedMovieList;
        }


        /// <summary>
        /// Add's a movie to the movie collection
        /// </summary>
        /// <param name="movie"></param>
        public Movie InsertMovie(Movie movie)
        {
            var MovieData = Mapper.Map<MovieData>(movie);
            _moviesCollection.Create(MovieData);
            return movie;            
        }

        /// <summary>
        /// Update's an existing movie detail in the movie collection.
        /// </summary>
        /// <param name="movie"></param>
        public void UpdateMovie(Movie movie)
        {
            var MovieData = Mapper.Map<MovieData>(movie);
            _moviesCollection.Update(MovieData);
        }


    }
}
