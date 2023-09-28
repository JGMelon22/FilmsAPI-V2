using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class MoviesActorsCommentaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_genre_id",
                table: "genres",
                newName: "genre_id_idx");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "genre_id");

            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    actor_name = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    salary = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    birthdate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Commentaries",
                columns: table => new
                {
                    CommentaryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Recommend = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaries", x => x.CommentaryId);
                });

            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    is_in_cinema = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    release_date = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.MovieId);
                });

            migrationBuilder.CreateIndex(
                name: "actor_id_idx",
                table: "actors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "movie_id_idx",
                table: "films",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "Commentaries");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "genre_id_idx",
                table: "Genres",
                newName: "IX_Genres_genre_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "genre_id");
        }
    }
}
