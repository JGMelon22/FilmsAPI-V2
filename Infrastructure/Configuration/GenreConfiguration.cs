using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("genres");

        builder.HasKey(g => g.GenreId);

        builder.HasIndex(g => g.GenreId)
            .HasDatabaseName("genre_id_idx");

        builder.Property(g => g.GenreId)
            .HasColumnName("genre_id");

        builder.Property(g => g.GenreName)
            .HasColumnType("VARCHAR")
            .HasColumnName("genre_name")
            .IsRequired();

        // Seed Data
        Genre comedy = new Genre {GenreId = 2, GenreName = "Comedy"};
        Genre drama = new Genre {GenreId = 3, GenreName = "Drama"};
        Genre Thriller = new Genre {GenreId = 4, GenreName = "Thriller"};
        Genre War = new Genre {GenreId = 5, GenreName = "War"};
        Genre SciFi = new Genre {GenreId = 6, GenreName = "Sci Fi"};

        builder.HasData(comedy, drama, Thriller, War, SciFi);
    }
}