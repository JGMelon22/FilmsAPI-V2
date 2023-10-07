using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class CommentaryColumnMovieIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_actors",
                table: "movies_actors");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "commentaries",
                newName: "movie_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_actors",
                table: "movies_actors",
                columns: new[] { "actor_id", "movie_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_actors",
                table: "movies_actors");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "commentaries",
                newName: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_actors",
                table: "movies_actors",
                columns: new[] { "movie_id", "actor_id" });
        }
    }
}
