using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovieApp.Data.Migrations
{
    public partial class SeedMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ReleaseDate", "RunningTime", "Title" },
                values: new object[,]
                {
                    { 10, "Robert Wise", "Musical drama", new DateTime(1965, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, "The Sound Of Music" },
                    { 20, "Howard Hawks", "Adventure", new DateTime(1962, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, "Hatari" },
                    { 30, "William Friedkin", "Supernatural horror", new DateTime(1973, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 133, "The Exorcist" },
                    { 40, "Robert Zemeckis", "Science Fiction", new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, "Back to the Future " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 40);
        }
    }
}
