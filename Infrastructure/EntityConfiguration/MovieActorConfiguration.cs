using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.ToTable("movies_actors");
        
        builder.HasKey(ma => new {ma.MovieId, ma.ActorId});
    }
}