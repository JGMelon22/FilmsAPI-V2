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
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Commentary> Commentaries => Set<Commentary>();

    // Setup conventions
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /// Genre
        // Id
        modelBuilder.Entity<Genre>()
            .ToTable("genres");

        modelBuilder.Entity<Genre>()
            .HasKey(g => g.GenreId);

        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.GenreId)
            .HasDatabaseName("genre_id_idx");

        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreId)
            .HasColumnName("genre_id");

        // Name
        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreName)
            .HasColumnType("VARCHAR")
            .HasColumnName("genre_name");

        /// Actor
        // Id
        modelBuilder.Entity<Actor>()
            .ToTable("actors");

        modelBuilder.Entity<Actor>()
            .HasKey(a => a.ActorId);

        modelBuilder.Entity<Actor>()
            .HasIndex(a => a.ActorId)
            .HasDatabaseName("actor_id_idx");

        modelBuilder.Entity<Actor>()
            .Property(a => a.ActorId)
            .HasColumnName("actor_id");

        // Name
        modelBuilder.Entity<Actor>()
            .Property(a => a.ActorName)
            .HasColumnType("VARCHAR")
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

        /// Movie
        // Id
        modelBuilder.Entity<Movie>()
            .ToTable("movies");

        modelBuilder.Entity<Movie>()
            .HasKey(m => m.MovieId);

        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.MovieId)
            .HasDatabaseName("movie_id_idx");

        modelBuilder.Entity<Movie>()
            .Property(m => m.MovieId)
            .HasColumnName("movie_id");

        // Title
        modelBuilder.Entity<Movie>()
            .Property(m => m.Title)
            .HasColumnType("VARCHAR")
            .HasColumnName("title")
            .IsRequired();

        // IsInCinema
        modelBuilder.Entity<Movie>()
            .Property(m => m.IsInCinema)
            .HasColumnType("boolean")
            .HasColumnName("is_in_cinema")
            .HasDefaultValue(false);

        // Release Date
        modelBuilder.Entity<Movie>()
            .Property(m => m.ReleaseDate)
            .HasColumnType("DATE")
            .HasColumnName("release_date");

        /// Comment
        modelBuilder.Entity<Commentary>()
            .ToTable("commentaries");

        modelBuilder.Entity<Commentary>()
            .HasKey(c => c.CommentaryId);

        modelBuilder.Entity<Commentary>()
            .HasIndex(c => c.CommentaryId)
            .HasDatabaseName("commentary_id_idx");

        modelBuilder.Entity<Commentary>()
            .Property(c => c.CommentaryId)
            .HasColumnName("commentary_id");

        modelBuilder.Entity<Commentary>()
            .Property(c => c.Content)
            .HasColumnType("VARCHAR")
            .HasColumnName("content")
            .HasMaxLength(500)
            .IsRequired(false);
    }
}