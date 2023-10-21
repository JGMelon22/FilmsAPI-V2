using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmsAPI_V2.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "actor_id", "actor_name", "birthdate", "salary" },
                values: new object[,]
                {
                    { 1, "Heather Langenkamp", new DateTime(1964, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1700m },
                    { 2, "Harrison Ford", new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000m },
                    { 3, "Mark Hamill", new DateTime(1951, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19000m },
                    { 4, "Louis Gossett Jr", new DateTime(1936, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m }
                });

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 2,
                column: "genre_name",
                value: "Horror");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 3,
                column: "genre_name",
                value: "Sci Fi");

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "genre_id", "genre_name" },
                values: new object[] { 1, "Adventure" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movie_id", "release_date", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(1981, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indiana Jones" },
                    { 2, new DateTime(1981, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Nightmare on Elm Street" },
                    { 3, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars" },
                    { 4, new DateTime(1981, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaws 3D" }
                });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresGenreId", "MoviesMovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "commentaries",
                columns: new[] { "commentary_id", "content", "movie_id", "recommend" },
                values: new object[,]
                {
                    { 1, "Superb!", 1, true },
                    { 2, "Wes Craven rocks!", 2, true },
                    { 3, "A heave decline on Jaws saga", 4, false },
                    { 4, "Light Sabers are the future!", 3, true }
                });

            migrationBuilder.InsertData(
                table: "movies_actors",
                columns: new[] { "actor_id", "movie_id", "character_name", "order" },
                values: new object[,]
                {
                    { 1, 2, "Nancy Thompson", 1 },
                    { 2, 1, "Indiana Jones", 2 },
                    { 3, 3, "Luke SkyWalker", 3 },
                    { 4, 4, "Calvin Bouchard", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "commentaries",
                keyColumn: "commentary_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "commentaries",
                keyColumn: "commentary_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "commentaries",
                keyColumn: "commentary_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "commentaries",
                keyColumn: "commentary_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "movies_actors",
                keyColumns: new[] { "actor_id", "movie_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "movies_actors",
                keyColumns: new[] { "actor_id", "movie_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "movies_actors",
                keyColumns: new[] { "actor_id", "movie_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "movies_actors",
                keyColumns: new[] { "actor_id", "movie_id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "actor_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "actor_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "actor_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "actors",
                keyColumn: "actor_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 2,
                column: "genre_name",
                value: "Comedy");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 3,
                column: "genre_name",
                value: "Drama");

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "genre_id", "genre_name" },
                values: new object[,]
                {
                    { 4, "Thriller" },
                    { 5, "War" },
                    { 6, "Sci Fi" }
                });
        }
    }
}
