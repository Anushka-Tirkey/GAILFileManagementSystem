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
                name: "Contract",
                columns: table => new
                {
                    sno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
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
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    File_Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Open_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Closed_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    sno = table.Column<int>(type: "int", nullable: false),
                    Contractsno = table.Column<int>(type: "int", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorname = table.Column<string>(type: "varchar(100)", nullable: false),
                    vendoraddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_Contract_Contractsno",
                        column: x => x.Contractsno,
                        principalTable: "Contract",
                        principalColumn: "sno");
                    table.ForeignKey(
                        name: "FK_Files_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_Contractsno",
                table: "Files",
                column: "Contractsno");

            migrationBuilder.CreateIndex(
                name: "IX_Files_VendorId",
                table: "Files",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
