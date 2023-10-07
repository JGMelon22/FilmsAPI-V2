using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyGenresMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "integer", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresGenreId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesMovieId",
                table: "GenreMovie",
                column: "MoviesMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");
        }
    }
}
