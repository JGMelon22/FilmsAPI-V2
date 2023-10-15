using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class CommentariesRecomendColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recommend",
                table: "commentaries",
                newName: "recommend");

            migrationBuilder.AlterColumn<bool>(
                name: "recommend",
                table: "commentaries",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "recommend",
                table: "commentaries",
                newName: "Recommend");

            migrationBuilder.AlterColumn<bool>(
                name: "Recommend",
                table: "commentaries",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");
        }
    }
}
