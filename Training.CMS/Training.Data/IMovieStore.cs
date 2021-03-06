﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain;

namespace Training.Data
{
    public interface IMovieStore
    {
        /// <summary>
        /// add a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        int AddMovie(Movie movie);
        /// <summary>
        /// update a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        int UpdateMovie(Movie movie);
        /// <summary>
        /// delete a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        int DeleteMovie(Movie movie);
        /// <summary>
        /// update is audit true
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        int IsAudit(Movie movie);
        /// <summary>
        /// get only one movie
        /// </summary>
        /// <returns></returns>
        DataTable ShowMovie(int movieId);
        /// <summary>
        /// get movies by name
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        DataTable ShowMovie(string movieName);
        /// <summary>
        /// get all movies
        /// </summary>
        /// <returns></returns>
        
        DataTable UnauditedMovie();
        DataTable GetMovies();

        DataTable GetMovies(string typename,string actor);

    }
}
