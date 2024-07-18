using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAILFileManagementSystem.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsolidatedReportViewModel",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubLocationId = table.Column<int>(type: "int", nullable: false),
                    SubLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidatedReportViewModel", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
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
                    table.PrimaryKey("PK_Contracts", x => x.sno);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubLocationID = table.Column<int>(type: "int", nullable: false),
                    SubLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LId);
                });

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
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorname = table.Column<string>(type: "varchar(100)", nullable: false),
                    vendoraddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_Contracts_Contractsno",
                        column: x => x.Contractsno,
                        principalTable: "Contracts",
                        principalColumn: "sno");
                    table.ForeignKey(
                        name: "FK_Files_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_Contractsno",
                table: "Files",
                column: "Contractsno");

            migrationBuilder.CreateIndex(
                name: "IX_Files_LocationId",
                table: "Files",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_VendorId",
                table: "Files",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsolidatedReportViewModel");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
