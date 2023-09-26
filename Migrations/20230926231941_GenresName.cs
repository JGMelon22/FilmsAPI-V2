using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class GenresName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genres",
                newName: "genre_name");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "genre_id");

            migrationBuilder.AlterColumn<string>(
                name: "genre_name",
                table: "Genres",
                type: "VARCHAR",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_genre_id",
                table: "Genres",
                column: "genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_genre_id",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "genre_name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.AlterColumn<string>(
                name: "GenreName",
                table: "Genres",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 150);
        }
    }
}
