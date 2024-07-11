using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILESMGMT.Migrations.LocationDB
{
    public partial class LocationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubLocationID = table.Column<int>(type: "int", nullable: false),
                    SubLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
