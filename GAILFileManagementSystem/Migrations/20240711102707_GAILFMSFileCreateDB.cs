using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAILFileManagementSystem.Migrations
{
    public partial class GAILFMSFileCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<string>(name: "File Type", type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Open_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Closed_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contract_No = table.Column<int>(type: "int", nullable: false),
                    Vendor_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Vendor_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");
        }
    }
}
