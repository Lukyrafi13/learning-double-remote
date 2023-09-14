using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class Appraisal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appraisals",
                columns: table => new
                {
                    AppraisalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationCollateralId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isInternal = table.Column<bool>(type: "bit", nullable: false),
                    isExternal = table.Column<bool>(type: "bit", nullable: false),
                    Estimator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kjpp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PropertyCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppraisalStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
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
                    table.PrimaryKey("PK_Appraisals", x => x.AppraisalId);
                    table.ForeignKey(
                        name: "FK_Appraisals_LoanApplicationCollaterals_LoanApplicationCollateralId",
                        column: x => x.LoanApplicationCollateralId,
                        principalTable: "LoanApplicationCollaterals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appraisals_LoanApplicationCollateralId",
                table: "Appraisals",
                column: "LoanApplicationCollateralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appraisals");
        }
    }
}
