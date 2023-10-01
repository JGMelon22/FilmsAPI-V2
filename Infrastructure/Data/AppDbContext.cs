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