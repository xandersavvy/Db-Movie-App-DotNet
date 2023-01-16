using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieDbAngDotNet.Models;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MovieDb> MovieDbs { get; set; }

    public virtual DbSet<UserDb> UserDbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //warning To protect potentially sensitive information in your connection string, you should move it out of source code.You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Movies;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__movieDb__3214EC27A9A3AB50");

            entity.ToTable("movieDb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Year).HasColumnName("YEAR");
        });

        modelBuilder.Entity<UserDb>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__userDb__AB6E6165C55F0CA9");

            entity.ToTable("userDb");

            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
