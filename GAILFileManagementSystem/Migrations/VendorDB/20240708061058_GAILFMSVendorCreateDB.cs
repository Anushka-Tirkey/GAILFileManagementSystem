using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILESMGMT.Migrations
{
    public partial class GAILFMSVendorCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendorname = table.Column<string>(type: "varchar(100)", nullable: false),
                    vendoraddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    contactperson = table.Column<string>(type: "varchar(100)", nullable: true),
                    contactno = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    contactemail = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
