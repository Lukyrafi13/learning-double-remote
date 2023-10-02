using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterRfDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParameterAppraisalGuid",
                table: "RfDocuments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfDocuments_ParameterAppraisalGuid",
                table: "RfDocuments",
                column: "ParameterAppraisalGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_RfDocuments_Parameters_ParameterAppraisalGuid",
                table: "RfDocuments",
                column: "ParameterAppraisalGuid",
                principalTable: "Parameters",
                principalColumn: "ParameterGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfDocuments_Parameters_ParameterAppraisalGuid",
                table: "RfDocuments");

            migrationBuilder.DropIndex(
                name: "IX_RfDocuments_ParameterAppraisalGuid",
                table: "RfDocuments");

            migrationBuilder.DropColumn(
                name: "ParameterAppraisalGuid",
                table: "RfDocuments");
        }
    }
}
