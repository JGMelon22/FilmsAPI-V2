using FilmsAPI_V2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsAPI_V2.Infrastructure.EntityConfiguration;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("actors");

        builder.HasKey(a => a.ActorId);

        builder.HasIndex(a => a.ActorId)
            .HasDatabaseName("actor_id_idx");

        builder.Property(a => a.ActorId)
            .HasColumnName("actor_id");

        builder.Property(a => a.ActorName)
            .HasColumnType("VARCHAR")
            .HasColumnName("actor_name")
            .IsRequired();

        builder.Property(a => a.Salary)
            .HasColumnType("DECIMAL")
            .HasPrecision(10, 2)
            .HasColumnName("salary"); // Might not know the actor salary

        builder.Property(a => a.BirthDate)
            .HasColumnType("DATE")
            .HasColumnName("birthdate");
    }
}