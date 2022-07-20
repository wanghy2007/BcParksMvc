using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BcParksMvc.Migrations
{
    public partial class AddParkType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkParkType",
                columns: table => new
                {
                    ParkTypesId = table.Column<int>(type: "int", nullable: false),
                    ParksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkParkType", x => new { x.ParkTypesId, x.ParksId });
                    table.ForeignKey(
                        name: "FK_ParkParkType_Park_ParksId",
                        column: x => x.ParksId,
                        principalTable: "Park",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkParkType_ParkType_ParkTypesId",
                        column: x => x.ParkTypesId,
                        principalTable: "ParkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkParkType_ParksId",
                table: "ParkParkType",
                column: "ParksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkParkType");

            migrationBuilder.DropTable(
                name: "ParkType");
        }
    }
}
