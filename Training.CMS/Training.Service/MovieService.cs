﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;
using Training.Domain;

namespace Training.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieStore MovieStore;

        public MovieService()
        {
            MovieStore = StoreFactory.GetMovieStore();
        }
     
        public int AddMovie(Movie movie)
        {
            return MovieStore.AddMovie(movie);
        }

        public int UpdateMovie(Movie movie)
        {
            return MovieStore.UpdateMovie(movie);
        }

        public int DeleteMovie(Movie movie)
        {
            return MovieStore.DeleteMovie(movie);
        }

        public DataTable GetMovies()
        {
            return MovieStore.GetMovies();
        }

        public DataTable GetMovies(string typename, string actor)
        {
            return MovieStore.GetMovies(typename, actor);
        }
    }

}
