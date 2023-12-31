﻿// <auto-generated />
using FilmsAPI_V2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("20230926225450_GenresFirstMigration")]
partial class GenresFirstMigration
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.11")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("FilmsAPI_V2.Domain.Entities.Genre", b =>
            {
                b.Property<int>("GenreId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                b.Property<string>("GenreName")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("GenreId");

                b.ToTable("Genres");
            });
#pragma warning restore 612, 618
    }
}
