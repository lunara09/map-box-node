using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment.Migrations
{
    public partial class assignmentModelsBeachContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Beach",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Beach",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Beach");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Beach");
        }
    }
}
