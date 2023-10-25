using System.Reflection;
using FilmsAPI_V2.Infrastructure.Configuration.Seeding;

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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        InitialSeeding.Seed(modelBuilder);
    }
}