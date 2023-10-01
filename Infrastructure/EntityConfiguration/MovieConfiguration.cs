using FilmsAPI_V2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasKey(m => m.MovieId);

        builder.HasIndex(m => m.MovieId)
            .HasDatabaseName("movie_id_idx");

        builder.Property(m => m.MovieId)
            .HasColumnName("movie_id");

        builder.Property(m => m.Title)
            .HasColumnType("VARCHAR")
            .HasColumnName("title")
            .IsRequired();

        builder.Property(m => m.IsInCinema)
            .HasColumnType("BOOLEAN")
            .HasColumnName("is_in_cinema")
            .HasDefaultValue(false);

        builder.Property(m => m.ReleaseDate)
            .HasColumnType("DATE")
            .HasColumnName("release_date");
    }
}