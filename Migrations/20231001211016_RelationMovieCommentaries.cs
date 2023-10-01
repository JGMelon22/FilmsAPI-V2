using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class RelationMovieCommentaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "commentaries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "commentaries_movie_id_idx",
                table: "commentaries",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "movie_id",
                table: "commentaries",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "movie_id",
                table: "commentaries");

            migrationBuilder.DropIndex(
                name: "commentaries_movie_id_idx",
                table: "commentaries");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "commentaries");
        }
    }
}
