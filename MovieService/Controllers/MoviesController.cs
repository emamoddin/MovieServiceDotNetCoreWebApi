using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieService.Repositories;
using MovieService.Model;
using MovieService.Dto;
using AutoMapper;

namespace MovieService.Controllers
{
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private IMoviesRepository _repository;

        public MoviesController(IMoviesRepository repository)
        {
            _repository = repository;
        }


        // GET /movies
        [HttpGet]
        public async Task<IActionResult> SearchMovies(int MovieId, string Title, string Genre, string Classification, int ReleaseDate, int Rating, string[] Cast)
        {
            try
            {
                var movies = await _repository.SearchMoviesAsync(MovieId, Title, Genre, Classification, ReleaseDate, Rating, Cast);
                if (movies == null)
                {
                    return NotFound();
                }

                var moviesDto = Mapper.Map<IEnumerable<MoviesLibrary.MovieData>>(movies);
                return Ok(moviesDto);
            }
            catch(Exception e)
            {
                throw; // Will throw original error
            }
        }


        // GET /movies
        [HttpGet("SortedListbyTitle")]
        public async Task<IActionResult> SortedMovieList(string SortedFilter)
        {
            try
            {                
                    var movies = await _repository.SortedMovieListAsync(SortedFilter);

                    if (movies == null)
                    {
                        return NotFound();
                    }

                    var moviesDto = Mapper.Map<IEnumerable<MoviesLibrary.MovieData>>(movies);
                    return Ok(moviesDto);
            }
            catch (Exception e)
            {
                throw; // Will throw original error
            }
        }


        // POST /movies
        [HttpPost]
        public IActionResult Post([FromBody]MovieDto movieDto)
        {
            // TODO: Validate Request with custom error response
            try
            {
                Movie movie = null;

            //movieDto.ReleaseDate = DateTime.Now;
            movie = Mapper.Map<Movie>(movieDto);
            movie = _repository.InsertMovie(movie);

            return Created(string.Empty, movieDto);
            }
            catch (Exception e)
            {
                throw; // Will throw original error
            }
        }

        // PUT /movies/80
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Movie movie)
        {
            _repository.UpdateMovie(movie);
        }

    }
}
