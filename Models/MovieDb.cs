using System;
using System.Collections.Generic;

namespace MovieDbAngDotNet.Models;

public partial class MovieDb
{
    public MovieDb(string name,int? year) { 
        Name = name;
        Year = year;
    }
    public MovieDb(int id,string name, int? year)
    {
        this.Id = id;
        Name = name;
        Year = year;
    }
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public int? Year { get; private set; }
}
