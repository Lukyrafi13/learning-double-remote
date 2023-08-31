using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddLoanAppCreditFac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_RFMARITAL_RfMaritalId",
                table: "Debtors");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationKeyPersons_RFMARITAL_RfMaritalId",
                table: "LoanApplicationKeyPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFMARITAL",
                table: "RFMARITAL");

            migrationBuilder.RenameTable(
                name: "RFMARITAL",
                newName: "RFMARITALs");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RfProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RfProducts_ProductId",
                table: "RfProducts",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFMARITALs",
                table: "RFMARITALs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RFSubProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    MandNPWP = table.Column<bool>(type: "bit", nullable: true),
                    LPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIKPSkema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIKPParentSkema = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFSubProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFSubProduct_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plafond = table.Column<float>(type: "real", nullable: false),
                    UsagePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    PrimaryInstallment = table.Column<float>(type: "real", nullable: false),
                    InterestInstallment = table.Column<float>(type: "real", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfAppTypeId = table.Column<int>(type: "int", nullable: true),
                    RFLoanPurposeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSubProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFPlacementCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFTenorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFCreditBehaviorId = table.Column<int>(type: "int", nullable: true),
                    RfSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCreditFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RFLoanPurpose_RFLoanPurposeId",
                        column: x => x.RFLoanPurposeId,
                        principalTable: "RFLoanPurpose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfParameterDetails_RfAppTypeId",
                        column: x => x.RfAppTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfParameterDetails_RFCreditBehaviorId",
                        column: x => x.RFCreditBehaviorId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfPlacementCountries_RFPlacementCountryId",
                        column: x => x.RFPlacementCountryId,
                        principalTable: "RfPlacementCountries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfSectorLBU1s_RfSectorLBU1Code",
                        column: x => x.RfSectorLBU1Code,
                        principalTable: "RfSectorLBU1s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfSectorLBU2s_RfSectorLBU2Code",
                        column: x => x.RfSectorLBU2Code,
                        principalTable: "RfSectorLBU2s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RfSectorLBU3s_RfSectorLBU3Code",
                        column: x => x.RfSectorLBU3Code,
                        principalTable: "RfSectorLBU3s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RFSubProduct_RFSubProductId",
                        column: x => x.RFSubProductId,
                        principalTable: "RFSubProduct",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditFacilities_RFTenors_RFTenorId",
                        column: x => x.RFTenorId,
                        principalTable: "RFTenors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_LoanApplicationId",
                table: "LoanApplicationCreditFacilities",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RfAppTypeId",
                table: "LoanApplicationCreditFacilities",
                column: "RfAppTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RFCreditBehaviorId",
                table: "LoanApplicationCreditFacilities",
                column: "RFCreditBehaviorId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RFLoanPurposeId",
                table: "LoanApplicationCreditFacilities",
                column: "RFLoanPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RFPlacementCountryId",
                table: "LoanApplicationCreditFacilities",
                column: "RFPlacementCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RfSectorLBU1Code",
                table: "LoanApplicationCreditFacilities",
                column: "RfSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RfSectorLBU2Code",
                table: "LoanApplicationCreditFacilities",
                column: "RfSectorLBU2Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RfSectorLBU3Code",
                table: "LoanApplicationCreditFacilities",
                column: "RfSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RFSubProductId",
                table: "LoanApplicationCreditFacilities",
                column: "RFSubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditFacilities_RFTenorId",
                table: "LoanApplicationCreditFacilities",
                column: "RFTenorId");

            migrationBuilder.CreateIndex(
                name: "IX_RFSubProduct_ProductId",
                table: "RFSubProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_RFMARITALs_RfMaritalId",
                table: "Debtors",
                column: "RfMaritalId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationKeyPersons_RFMARITALs_RfMaritalId",
                table: "LoanApplicationKeyPersons",
                column: "RfMaritalId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_RFMARITALs_RfMaritalId",
                table: "Debtors");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationKeyPersons_RFMARITALs_RfMaritalId",
                table: "LoanApplicationKeyPersons");

            migrationBuilder.DropTable(
                name: "LoanApplicationCreditFacilities");

            migrationBuilder.DropTable(
                name: "RFSubProduct");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RfProducts_ProductId",
                table: "RfProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFMARITALs",
                table: "RFMARITALs");

            migrationBuilder.RenameTable(
                name: "RFMARITALs",
                newName: "RFMARITAL");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFMARITAL",
                table: "RFMARITAL",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_RFMARITAL_RfMaritalId",
                table: "Debtors",
                column: "RfMaritalId",
                principalTable: "RFMARITAL",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationKeyPersons_RFMARITAL_RfMaritalId",
                table: "LoanApplicationKeyPersons",
                column: "RfMaritalId",
                principalTable: "RFMARITAL",
                principalColumn: "Id");
        }
    }
}
