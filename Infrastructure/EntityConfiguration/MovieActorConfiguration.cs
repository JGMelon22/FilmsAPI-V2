using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.ToTable("movies_actors");

        builder.HasKey(ma => new { ma.ActorId, ma.MovieId });

        builder.HasIndex(ma => ma.ActorId)
            .HasDatabaseName("movies_actors_actor_id_idx");

        builder.HasIndex(ma => ma.MovieId)
            .HasDatabaseName("movies_actors_movie_id_idx");

        // Explicit FK configuration
        builder.HasOne(ma => ma.Actor)
            .WithMany(a => a.MoviesActors)
            .HasForeignKey(ma => ma.ActorId);

        builder.HasOne(ma => ma.Movie)
            .WithMany(m => m.MoviesActors)
            .HasForeignKey(ma => ma.MovieId);

        builder.Property(ma => ma.ActorId)
            .HasColumnName("actor_id");

        builder.Property(ma => ma.MovieId)
            .HasColumnName("movie_id");

        builder.Property(ma => ma.Character)
            .HasColumnType("VARCHAR")
            .HasColumnName("character_name")
            .IsRequired();

        builder.Property(ma => ma.Order)
            .HasColumnType("INTEGER")
            .HasColumnName("order");
    }
}