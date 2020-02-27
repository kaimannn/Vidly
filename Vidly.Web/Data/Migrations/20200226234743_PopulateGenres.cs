using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Adventure')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Crime')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Drama')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(6, 'Fantasy')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(7, 'Science fiction')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(8, 'Horror')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(9, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(10, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(11, 'Western')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
