using System;
using System.Collections.Generic;
using MovieDbAngDotNet.Models;

namespace MovieDbAngDotNet.DataAccessLayer;


public interface IMovieDb
{
    IEnumerable<MovieDb> GetMovies();
    MovieDb? GetMovieById(int id);

    MovieDb? GetMovieByName(string name);

    void AddMovie(MovieDb movieDb);
    void DeleteMovieById(int id);

    void UpdateMovie(MovieDb movieDb);
}
