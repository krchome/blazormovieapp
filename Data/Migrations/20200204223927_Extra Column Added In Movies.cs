using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovieApp.Data.Migrations
{
    public partial class ExtraColumnAddedInMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Movies");
        }
    }
}
