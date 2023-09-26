using FilmsAPI_V2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPI_V2.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres => Set<Genre>();
}