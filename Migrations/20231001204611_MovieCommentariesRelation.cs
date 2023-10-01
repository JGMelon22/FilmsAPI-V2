using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class MovieCommentariesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "movies",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "CommentaryId",
                table: "commentaries",
                newName: "commentary_id");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "actors",
                newName: "actor_id");

            migrationBuilder.AlterColumn<bool>(
                name: "is_in_cinema",
                table: "movies",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "commentary_id",
                table: "commentaries",
                newName: "CommentaryId");

            migrationBuilder.RenameColumn(
                name: "actor_id",
                table: "actors",
                newName: "ActorId");

            migrationBuilder.AlterColumn<bool>(
                name: "is_in_cinema",
                table: "movies",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN",
                oldDefaultValue: false);
        }
    }
}
