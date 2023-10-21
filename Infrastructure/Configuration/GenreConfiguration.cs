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
    }
}