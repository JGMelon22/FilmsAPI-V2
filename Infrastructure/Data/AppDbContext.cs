using FilmsAPI_V2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI_V2.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Actor> Actors => Set<Actor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Genre
        // Id
        modelBuilder.Entity<Genre>()
            .HasKey(g => g.GenreId);

        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.GenreId);

        modelBuilder.Entity<Genre>()
            .ToTable("genres");

        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreId)
            .HasColumnName("genre_id");

        // Name
        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .HasColumnName("genre_name");

        // Actor
        // Id
        modelBuilder.Entity<Actor>()
            .ToTable("actors");

        modelBuilder.Entity<Actor>()
            .HasKey(a => a.ActorId);

        modelBuilder.Entity<Actor>()
            .HasIndex(a => a.ActorId)
            .HasDatabaseName("actor_id_idx");

        // Name
        modelBuilder.Entity<Actor>()
            .Property(a => a.ActorName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .HasColumnName("actor_name")
            .IsRequired();

        // Salary
        modelBuilder.Entity<Actor>()
            .Property(a => a.Salary)
            .HasColumnType("DECIMAL")
            .HasPrecision(10, 2)
            .HasColumnName("salary");

        // Birthdate
        modelBuilder.Entity<Actor>()
            .Property(a => a.BirthDate)
            .HasColumnType("DATE")
            .HasColumnName("birthdate");
    }
}