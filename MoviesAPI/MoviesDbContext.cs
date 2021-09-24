using MoviesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAPI
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext([NotNull] DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Genre> Genres { get; init; }

        public DbSet<Actor> Actors { get; init; }
    }
}
