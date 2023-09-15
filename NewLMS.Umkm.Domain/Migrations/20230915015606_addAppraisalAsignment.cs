using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addAppraisalAsignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationAppraisals",
                columns: table => new
                {
                    AppraisalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationCollateralId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isInternal = table.Column<bool>(type: "bit", nullable: false),
                    isExternal = table.Column<bool>(type: "bit", nullable: false),
                    Estimator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kjpp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PropertyCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppraisalStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplicationAppraisals", x => x.AppraisalId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationAppraisals_LoanApplicationCollaterals_LoanApplicationCollateralId",
                        column: x => x.LoanApplicationCollateralId,
                        principalTable: "LoanApplicationCollaterals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationAppraisals_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationAppraisals_RfStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStages",
                        principalColumn: "StageId");
                });

            migrationBuilder.CreateTable(
                name: "RfAppraisalKJPPMasters",
                columns: table => new
                {
                    KJPPMasterCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KJPPName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PKSStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PKSEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfAppraisalKJPPMasters", x => x.KJPPMasterCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationAppraisals_LoanApplicationCollateralId",
                table: "LoanApplicationAppraisals",
                column: "LoanApplicationCollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationAppraisals_LoanApplicationId",
                table: "LoanApplicationAppraisals",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationAppraisals_StageId",
                table: "LoanApplicationAppraisals",
                column: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationAppraisals");

            migrationBuilder.DropTable(
                name: "RfAppraisalKJPPMasters");
        }
    }
}
