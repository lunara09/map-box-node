using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment.Migrations
{
    public partial class assigmantModelsBeachContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geometry",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geometry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beach",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressFr = table.Column<string>(nullable: true),
                    BeachType = table.Column<string>(nullable: true),
                    Accessible = table.Column<string>(nullable: true),
                    Open = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkFr = table.Column<string>(nullable: true),
                    LinkLabel = table.Column<string>(nullable: true),
                    LinkLab1 = table.Column<string>(nullable: true),
                    LinkDescr = table.Column<string>(nullable: true),
                    LinkDes1 = table.Column<string>(nullable: true),
                    GeometryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beach_Geometry_GeometryId",
                        column: x => x.GeometryId,
                        principalTable: "Geometry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beach_GeometryId",
                table: "Beach",
                column: "GeometryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beach");

            migrationBuilder.DropTable(
                name: "Geometry");
        }
    }
}
