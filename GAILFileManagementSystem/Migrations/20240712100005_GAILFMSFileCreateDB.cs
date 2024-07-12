using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAILFileManagementSystem.Migrations
{
    public partial class GAILFMSFileCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<string>(name: "File Type", type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Open_Date = table.Column<string>(type: "varchar(100)", nullable: false),
                    Closed_Date = table.Column<string>(type: "varchar(100)", nullable: false),
                    Contract_No = table.Column<int>(type: "int", nullable: false),
                    Vendor_name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Vendor_address = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
