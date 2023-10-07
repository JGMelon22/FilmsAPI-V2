using System.Reflection;
using FilmsAPI_V2.Infrastructure.EntityConfiguration;

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
    public DbSet<MovieActor> MoviesActors => Set<MovieActor>();

    // Setup conventions
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ActorConfiguration());
        // modelBuilder.ApplyConfiguration(new CommentaryConfiguration());
        // modelBuilder.ApplyConfiguration(new GenreConfiguration());
        // modelBuilder.ApplyConfiguration(new MovieConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}