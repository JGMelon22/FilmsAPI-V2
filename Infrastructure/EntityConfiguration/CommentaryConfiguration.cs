using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
{
    public void Configure(EntityTypeBuilder<Commentary> builder)
    {
        builder.ToTable("commentaries");

        builder.HasKey(c => c.CommentaryId);

        builder.HasIndex(c => c.CommentaryId)
            .HasDatabaseName("commentary_id_idx");

        builder.HasIndex(c=>c.MovieId)
            .HasDatabaseName("commentaries_movie_id_idx");

        builder.Property(c => c.CommentaryId)
            .HasColumnName("commentary_id");

        builder.Property(c => c.Content)
            .HasColumnType("VARCHAR")
            .HasColumnName("content")
            .HasMaxLength(500);

        builder.Property(c=>c.MovieId)
            .HasColumnName("movie_id");

        // One-To-Many
        builder.HasOne(c => c.Movie)
            .WithMany(m => m.Commentaries)
            .HasForeignKey(c => c.MovieId)
            .HasConstraintName("movie_id");
    }
}