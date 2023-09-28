using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class Content500Characters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentaries",
                table: "Commentaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_films",
                table: "films");

            migrationBuilder.RenameTable(
                name: "Commentaries",
                newName: "commentaries");

            migrationBuilder.RenameTable(
                name: "films",
                newName: "movies");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "commentaries",
                newName: "content");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "commentaries",
                type: "VARCHAR",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_commentaries",
                table: "commentaries",
                column: "CommentaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "commentary_id_idx",
                table: "commentaries",
                column: "CommentaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_commentaries",
                table: "commentaries");

            migrationBuilder.DropIndex(
                name: "commentary_id_idx",
                table: "commentaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.RenameTable(
                name: "commentaries",
                newName: "Commentaries");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "films");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Commentaries",
                newName: "Content");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Commentaries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentaries",
                table: "Commentaries",
                column: "CommentaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_films",
                table: "films",
                column: "MovieId");
        }
    }
}
