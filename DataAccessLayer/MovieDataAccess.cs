using System;
using System.Collections.Generic;
using MovieDbAngDotNet.Models;

namespace MovieDbAngDotNet.DataAccessLayer;

public class MovieDataAccess : IMovieDb
{

    private MoviesContext _context;
    public MovieDataAccess(MoviesContext context)
    {
        _context = context;
    }
    public IEnumerable<MovieDb> AddMovie(MovieDb movieDb)
    {
        try
        {
            this._context.MovieDbs.Add(movieDb);
            this._context.SaveChanges();
            return this._context.MovieDbs.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<MovieDb>().ToList();
        }

    }

    public void DeleteMovieById(int id)
    {
        try
        {
            MovieDb? movieDb = _context.MovieDbs.Find(id);
            if (movieDb != null)
            {
                this._context.MovieDbs.Remove(movieDb);
                this._context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public MovieDb? GetMovieById(int id)
    {
        try
        {
            return _context.MovieDbs.Find(id) as MovieDb;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public MovieDb? GetMovieByName(string name)
    {
        try
        {
            return _context.MovieDbs.Find(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public IEnumerable<MovieDb> GetMovies()
    {
        try
        {
            return _context.MovieDbs.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<MovieDb>().ToList();
        }

    }

    public void UpdateMovie(MovieDb movieDb)
    {
        try
        {

            MovieDb? _movieDb = _context.MovieDbs.Find(movieDb.Id);
            if (_movieDb != null)
            {
                this._context.MovieDbs.Remove(movieDb);
                this._context.MovieDbs.Add(movieDb);
                this._context.SaveChanges();
            }
            this._context.SaveChanges();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}