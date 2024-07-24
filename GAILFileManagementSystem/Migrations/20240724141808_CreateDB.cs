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
                name: "Contracts",
                columns: table => new
                {
                    SNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTRACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTRACT_SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRACT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTRACT_TYPE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.SNO);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    L_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    LOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBLOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    SUBLOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_NO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.L_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VENDOR_NAME = table.Column<string>(type: "varchar(100)", nullable: false),
                    VENDOR_ADDRESS = table.Column<string>(type: "varchar(200)", nullable: true),
                    CONTACT_PERSON = table.Column<string>(type: "varchar(100)", nullable: true),
                    CONTACT_NUMBER = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CONTACT_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VENDOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FILE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILE_NAME = table.Column<string>(type: "varchar(255)", nullable: true),
                    FILE_TYPE = table.Column<string>(type: "varchar(20)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CLOSED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    STATUS = table.Column<string>(type: "varchar(100)", nullable: false),
                    SNO = table.Column<int>(type: "int", nullable: false),
                    ContractSNO = table.Column<int>(type: "int", nullable: true),
                    CONTRACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTRACT_SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRACT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTRACT_TYPE = table.Column<int>(type: "int", nullable: false),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false),
                    VENDOR_ID1 = table.Column<int>(type: "int", nullable: true),
                    VENDOR_NAME = table.Column<string>(type: "varchar(100)", nullable: false),
                    VENDOR_ADDRESS = table.Column<string>(type: "varchar(200)", nullable: true),
                    CONTACT_PERSON = table.Column<string>(type: "varchar(100)", nullable: true),
                    CONTACT_NUMBER = table.Column<string>(type: "varchar(100)", nullable: true),
                    CONTACT_EMAIL = table.Column<string>(type: "varchar(100)", nullable: true),
                    LOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    LocationL_ID = table.Column<int>(type: "int", nullable: true),
                    LOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBLOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    SUBLOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_NO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FILE_ID);
                    table.ForeignKey(
                        name: "FK_Files_Contracts_ContractSNO",
                        column: x => x.ContractSNO,
                        principalTable: "Contracts",
                        principalColumn: "SNO");
                    table.ForeignKey(
                        name: "FK_Files_Locations_LocationL_ID",
                        column: x => x.LocationL_ID,
                        principalTable: "Locations",
                        principalColumn: "L_ID");
                    table.ForeignKey(
                        name: "FK_Files_Vendors_VENDOR_ID1",
                        column: x => x.VENDOR_ID1,
                        principalTable: "Vendors",
                        principalColumn: "VENDOR_ID");
                });

            migrationBuilder.CreateTable(
                name: "ConsolidatedReportViewModel",
                columns: table => new
                {
                    FILE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilesFILE_ID = table.Column<int>(type: "int", nullable: true),
                    FILE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILE_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CLOSED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FILE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDOR_ID1 = table.Column<int>(type: "int", nullable: true),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: false),
                    VENDOR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDOR_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACT_PERSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACT_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractSNO = table.Column<int>(type: "int", nullable: true),
                    CONTRACT_ID = table.Column<int>(type: "int", nullable: false),
                    CONTRACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRACT_SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRACT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRACT_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTRACT_END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONTRACT_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationL_ID = table.Column<int>(type: "int", nullable: true),
                    LOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    LOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBLOCATION_ID = table.Column<int>(type: "int", nullable: false),
                    SUBLOCATION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTN_NO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidatedReportViewModel", x => x.FILE_ID);
                    table.ForeignKey(
                        name: "FK_ConsolidatedReportViewModel_Contracts_ContractSNO",
                        column: x => x.ContractSNO,
                        principalTable: "Contracts",
                        principalColumn: "SNO");
                    table.ForeignKey(
                        name: "FK_ConsolidatedReportViewModel_Files_FilesFILE_ID",
                        column: x => x.FilesFILE_ID,
                        principalTable: "Files",
                        principalColumn: "FILE_ID");
                    table.ForeignKey(
                        name: "FK_ConsolidatedReportViewModel_Locations_LocationL_ID",
                        column: x => x.LocationL_ID,
                        principalTable: "Locations",
                        principalColumn: "L_ID");
                    table.ForeignKey(
                        name: "FK_ConsolidatedReportViewModel_Vendors_VENDOR_ID1",
                        column: x => x.VENDOR_ID1,
                        principalTable: "Vendors",
                        principalColumn: "VENDOR_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_ContractSNO",
                table: "ConsolidatedReportViewModel",
                column: "ContractSNO");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_FilesFILE_ID",
                table: "ConsolidatedReportViewModel",
                column: "FilesFILE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_LocationL_ID",
                table: "ConsolidatedReportViewModel",
                column: "LocationL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_VENDOR_ID1",
                table: "ConsolidatedReportViewModel",
                column: "VENDOR_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ContractSNO",
                table: "Files",
                column: "ContractSNO");

            migrationBuilder.CreateIndex(
                name: "IX_Files_LocationL_ID",
                table: "Files",
                column: "LocationL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_VENDOR_ID1",
                table: "Files",
                column: "VENDOR_ID1");
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
