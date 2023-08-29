using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditRelationSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RFKepemilikanTempatUsahaId",
                table: "Surveys",
                newName: "RFLamaUsahaLainId");

            migrationBuilder.RenameColumn(
                name: "RFBusinessType",
                table: "Surveys",
                newName: "RFKepemilikanUsahaId");

            migrationBuilder.RenameColumn(
                name: "RFBidangUsahaKUR",
                table: "Surveys",
                newName: "RFBusinessTypeId");

            migrationBuilder.RenameColumn(
                name: "LamaUsahaLain",
                table: "Surveys",
                newName: "RFBidangUsahaKURId");

            migrationBuilder.CreateTable(
                name: "RFKepemilikanUsaha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KepemilikanUsahaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KepemilikanUsahaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFKepemilikanUsaha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFLamaUsahaLain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANLDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFLamaUsahaLain", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFBidangUsahaKURId",
                table: "Surveys",
                column: "RFBidangUsahaKURId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFBusinessTypeId",
                table: "Surveys",
                column: "RFBusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFKepemilikanUsahaId",
                table: "Surveys",
                column: "RFKepemilikanUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFLamaUsahaLainId",
                table: "Surveys",
                column: "RFLamaUsahaLainId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFOwnerOTSId",
                table: "Surveys",
                column: "RFOwnerOTSId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFZipCodeId",
                table: "Surveys",
                column: "RFZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFBidangUsahaKURs_RFBidangUsahaKURId",
                table: "Surveys",
                column: "RFBidangUsahaKURId",
                principalTable: "RFBidangUsahaKURs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFBusinessTypes_RFBusinessTypeId",
                table: "Surveys",
                column: "RFBusinessTypeId",
                principalTable: "RFBusinessTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFKepemilikanUsaha_RFKepemilikanUsahaId",
                table: "Surveys",
                column: "RFKepemilikanUsahaId",
                principalTable: "RFKepemilikanUsaha",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFLamaUsahaLain_RFLamaUsahaLainId",
                table: "Surveys",
                column: "RFLamaUsahaLainId",
                principalTable: "RFLamaUsahaLain",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFOwnerOTSs_RFOwnerOTSId",
                table: "Surveys",
                column: "RFOwnerOTSId",
                principalTable: "RFOwnerOTSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFZipCodes_RFZipCodeId",
                table: "Surveys",
                column: "RFZipCodeId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFBidangUsahaKURs_RFBidangUsahaKURId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFBusinessTypes_RFBusinessTypeId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFKepemilikanUsaha_RFKepemilikanUsahaId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFLamaUsahaLain_RFLamaUsahaLainId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFOwnerOTSs_RFOwnerOTSId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFZipCodes_RFZipCodeId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "RFKepemilikanUsaha");

            migrationBuilder.DropTable(
                name: "RFLamaUsahaLain");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFBidangUsahaKURId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFBusinessTypeId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFKepemilikanUsahaId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFLamaUsahaLainId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFOwnerOTSId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFZipCodeId",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "RFLamaUsahaLainId",
                table: "Surveys",
                newName: "RFKepemilikanTempatUsahaId");

            migrationBuilder.RenameColumn(
                name: "RFKepemilikanUsahaId",
                table: "Surveys",
                newName: "RFBusinessType");

            migrationBuilder.RenameColumn(
                name: "RFBusinessTypeId",
                table: "Surveys",
                newName: "RFBidangUsahaKUR");

            migrationBuilder.RenameColumn(
                name: "RFBidangUsahaKURId",
                table: "Surveys",
                newName: "LamaUsahaLain");
        }
    }
}
