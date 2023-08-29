using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableLoanApplicationApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusan_SKCode",
                table: "SCJabatans");

            migrationBuilder.DropForeignKey(
                name: "FK_SCSKLIMITs_ScSuratKeputusan_SkCode",
                table: "SCSKLIMITs");

            migrationBuilder.DropForeignKey(
                name: "FK_ScUserDetail_SCJabatans_JabCode",
                table: "ScUserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ScUserDetail_SCUsers_UserId",
                table: "ScUserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScUserDetail",
                table: "ScUserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScSuratKeputusan",
                table: "ScSuratKeputusan");

            migrationBuilder.RenameTable(
                name: "ScUserDetail",
                newName: "ScUserDetails");

            migrationBuilder.RenameTable(
                name: "ScSuratKeputusan",
                newName: "ScSuratKeputusans");

            migrationBuilder.RenameIndex(
                name: "IX_ScUserDetail_JabCode",
                table: "ScUserDetails",
                newName: "IX_ScUserDetails_JabCode");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "LoanApplications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScUserDetails",
                table: "ScUserDetails",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScSuratKeputusans",
                table: "ScSuratKeputusans",
                column: "SkCode");

            migrationBuilder.CreateTable(
                name: "LoanApplicationApprovals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalisaStatus = table.Column<int>(type: "int", nullable: false),
                    ActionBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationApprovals_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationApprovals_LoanApplicationId",
                table: "LoanApplicationApprovals",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusans_SKCode",
                table: "SCJabatans",
                column: "SKCode",
                principalTable: "ScSuratKeputusans",
                principalColumn: "SkCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SCSKLIMITs_ScSuratKeputusans_SkCode",
                table: "SCSKLIMITs",
                column: "SkCode",
                principalTable: "ScSuratKeputusans",
                principalColumn: "SkCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScUserDetails_SCJabatans_JabCode",
                table: "ScUserDetails",
                column: "JabCode",
                principalTable: "SCJabatans",
                principalColumn: "JabCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ScUserDetails_SCUsers_UserId",
                table: "ScUserDetails",
                column: "UserId",
                principalTable: "SCUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusans_SKCode",
                table: "SCJabatans");

            migrationBuilder.DropForeignKey(
                name: "FK_SCSKLIMITs_ScSuratKeputusans_SkCode",
                table: "SCSKLIMITs");

            migrationBuilder.DropForeignKey(
                name: "FK_ScUserDetails_SCJabatans_JabCode",
                table: "ScUserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScUserDetails_SCUsers_UserId",
                table: "ScUserDetails");

            migrationBuilder.DropTable(
                name: "LoanApplicationApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScUserDetails",
                table: "ScUserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScSuratKeputusans",
                table: "ScSuratKeputusans");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "LoanApplications");

            migrationBuilder.RenameTable(
                name: "ScUserDetails",
                newName: "ScUserDetail");

            migrationBuilder.RenameTable(
                name: "ScSuratKeputusans",
                newName: "ScSuratKeputusan");

            migrationBuilder.RenameIndex(
                name: "IX_ScUserDetails_JabCode",
                table: "ScUserDetail",
                newName: "IX_ScUserDetail_JabCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScUserDetail",
                table: "ScUserDetail",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScSuratKeputusan",
                table: "ScSuratKeputusan",
                column: "SkCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusan_SKCode",
                table: "SCJabatans",
                column: "SKCode",
                principalTable: "ScSuratKeputusan",
                principalColumn: "SkCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SCSKLIMITs_ScSuratKeputusan_SkCode",
                table: "SCSKLIMITs",
                column: "SkCode",
                principalTable: "ScSuratKeputusan",
                principalColumn: "SkCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScUserDetail_SCJabatans_JabCode",
                table: "ScUserDetail",
                column: "JabCode",
                principalTable: "SCJabatans",
                principalColumn: "JabCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ScUserDetail_SCUsers_UserId",
                table: "ScUserDetail",
                column: "UserId",
                principalTable: "SCUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
