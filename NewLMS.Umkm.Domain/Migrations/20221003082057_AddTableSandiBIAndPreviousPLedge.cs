using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableSandiBIAndPreviousPLedge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreviousPledges",
                columns: table => new
                {
                    PreviousPledgeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 16, nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CollateralType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PledgeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PledgeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PledgeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notaryname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalAprasialValue = table.Column<int>(type: "int", nullable: false),
                    ExternalAprasialValue = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationWithDebtor = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PreviousPledges", x => x.PreviousPledgeId);
                    table.ForeignKey(
                        name: "FK_PreviousPledges_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateTable(
            //     name: "SandiBIs",
            //     columns: table => new
            //     {
            //         SandiBiId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //         SIDDebtorClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUDebtorClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SIDEconomySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUEconomySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DebtorStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DebtorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PortfolioCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CompanyRank = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SIDCreditTrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUCreditTrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         RatingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SIDCreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUCreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SIDUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CollateralIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CollateralIssuerRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SIDUserOrientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LBUUserOrientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         MeasuringCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //         DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SandiBIs", x => x.SandiBiId);
            //         table.ForeignKey(
            //             name: "FK_SandiBIs_LoanApplications_SandiBiId",
            //             column: x => x.SandiBiId,
            //             principalTable: "LoanApplications",
            //             principalColumn: "LoanApplicationId",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_LoanApplicationId",
                table: "PreviousPledges",
                column: "LoanApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousPledges");

            // migrationBuilder.DropTable(
            //     name: "SandiBIs");
        }
    }
}
