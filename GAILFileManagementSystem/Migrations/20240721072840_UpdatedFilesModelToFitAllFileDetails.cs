using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAILFileManagementSystem.Migrations
{
    public partial class UpdatedFilesModelToFitAllFileDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractDescription",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractSubject",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractType",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GSTN_No",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SubLocationID",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubLocationName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactemail",
                table: "Files",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactno",
                table: "Files",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactperson",
                table: "Files",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilesFileId",
                table: "ConsolidatedReportViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_ContractId",
                table: "ConsolidatedReportViewModel",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_FilesFileId",
                table: "ConsolidatedReportViewModel",
                column: "FilesFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_LocationId",
                table: "ConsolidatedReportViewModel",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReportViewModel_VendorId",
                table: "ConsolidatedReportViewModel",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReportViewModel_Contracts_ContractId",
                table: "ConsolidatedReportViewModel",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "sno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReportViewModel_Files_FilesFileId",
                table: "ConsolidatedReportViewModel",
                column: "FilesFileId",
                principalTable: "Files",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReportViewModel_Locations_LocationId",
                table: "ConsolidatedReportViewModel",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReportViewModel_Vendors_VendorId",
                table: "ConsolidatedReportViewModel",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReportViewModel_Contracts_ContractId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReportViewModel_Files_FilesFileId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReportViewModel_Locations_LocationId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReportViewModel_Vendors_VendorId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReportViewModel_ContractId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReportViewModel_FilesFileId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReportViewModel_LocationId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReportViewModel_VendorId",
                table: "ConsolidatedReportViewModel");

            migrationBuilder.DropColumn(
                name: "ContractDescription",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ContractSubject",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "GSTN_No",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "SubLocationID",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "SubLocationName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "contactemail",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "contactno",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "contactperson",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FilesFileId",
                table: "ConsolidatedReportViewModel");
        }
    }
}
