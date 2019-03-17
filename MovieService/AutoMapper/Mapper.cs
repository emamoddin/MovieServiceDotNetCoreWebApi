using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieService.Model;
using MovieService.Dto;

namespace MovieService.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<MoviesLibrary.MovieData, MovieDto>();
            CreateMap<MovieDto, MoviesLibrary.MovieData>();
        }
    }
}
