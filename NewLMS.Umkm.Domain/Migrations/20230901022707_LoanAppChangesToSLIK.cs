using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class LoanAppChangesToSLIK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfContactPersonZipCodeId",
                table: "CompanyEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfParameterDetails_MaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditFacilities_RFSubProduct_RFSubProductId",
                table: "LoanApplicationCreditFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStage_StageId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStage_TargetStage",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFSubProduct_RfProducts_ProductId",
                table: "RFSubProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikCreditHistorys_RFCondition_RFConditionId",
                table: "SlikCreditHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikCreditHistorys_RFTipeKredit_RFTipeKreditId",
                table: "SlikCreditHistorys");

            migrationBuilder.RenameTable(
                name: "RFTipeKredit",
                newName: "RFCreditType");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCreditScorings_LoanApplicationGuid",
                table: "LoanApplicationCreditScorings");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_MaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFSubProduct",
                table: "RFSubProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfStage",
                table: "RfStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFCondition",
                table: "RFCondition");

            migrationBuilder.DropColumn(
                name: "MaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.RenameTable(
                name: "RFSubProduct",
                newName: "RFSubProducts");

            migrationBuilder.RenameTable(
                name: "RfStage",
                newName: "RfStages");

            migrationBuilder.RenameTable(
                name: "RFCondition",
                newName: "RFConditions");

            migrationBuilder.RenameColumn(
                name: "RFTipeKreditId",
                table: "SlikCreditHistorys",
                newName: "RfCreditTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SlikCreditHistorys_RFTipeKreditId",
                table: "SlikCreditHistorys",
                newName: "IX_SlikCreditHistorys_RfCreditTypeId");

            migrationBuilder.RenameColumn(
                name: "BithOfDateCouple",
                table: "LoanApplicationCollaterals",
                newName: "CoupleDateOfBirth");

            migrationBuilder.RenameColumn(
                name: "BirthOfPlaceCouple",
                table: "LoanApplicationCollaterals",
                newName: "CouplePlaceOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_RFSubProduct_ProductId",
                table: "RFSubProducts",
                newName: "IX_RFSubProducts_ProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "RfMaritalId",
                table: "LoanApplicationCollaterals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "CompanyEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RfContactPersonZipCodeId",
                table: "CompanyEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NPWP",
                table: "CompanyEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFSubProducts",
                table: "RFSubProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfStages",
                table: "RfStages",
                column: "StageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFConditions",
                table: "RFConditions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RfCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditAgreement = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfCreditTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_LoanApplicationGuid",
                table: "LoanApplicationCreditScorings",
                column: "LoanApplicationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RfMaritalId",
                table: "LoanApplicationCollaterals",
                column: "RfMaritalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfContactPersonZipCodeId",
                table: "CompanyEntities",
                column: "RfContactPersonZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMARITALs_RfMaritalId",
                table: "LoanApplicationCollaterals",
                column: "RfMaritalId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditFacilities_RFSubProducts_RFSubProductId",
                table: "LoanApplicationCreditFacilities",
                column: "RFSubProductId",
                principalTable: "RFSubProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_TargetStage",
                table: "LoanApplicationStageLogs",
                column: "TargetStage",
                principalTable: "RfStages",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFSubProducts_RfProducts_ProductId",
                table: "RFSubProducts",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikCreditHistorys_RFConditions_RFConditionId",
                table: "SlikCreditHistorys",
                column: "RFConditionId",
                principalTable: "RFConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikCreditHistorys_RfCreditTypes_RfCreditTypeId",
                table: "SlikCreditHistorys",
                column: "RfCreditTypeId",
                principalTable: "RfCreditTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfContactPersonZipCodeId",
                table: "CompanyEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMARITALs_RfMaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditFacilities_RFSubProducts_RFSubProductId",
                table: "LoanApplicationCreditFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_TargetStage",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFSubProducts_RfProducts_ProductId",
                table: "RFSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikCreditHistorys_RFConditions_RFConditionId",
                table: "SlikCreditHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikCreditHistorys_RfCreditTypes_RfCreditTypeId",
                table: "SlikCreditHistorys");

            migrationBuilder.DropTable(
                name: "RfCreditTypes");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCreditScorings_LoanApplicationGuid",
                table: "LoanApplicationCreditScorings");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_RfMaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFSubProducts",
                table: "RFSubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfStages",
                table: "RfStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RFConditions",
                table: "RFConditions");

            migrationBuilder.DropColumn(
                name: "RfMaritalId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NPWP",
                table: "CompanyEntities");

            migrationBuilder.RenameTable(
                name: "RFSubProducts",
                newName: "RFSubProduct");

            migrationBuilder.RenameTable(
                name: "RfStages",
                newName: "RfStage");

            migrationBuilder.RenameTable(
                name: "RFConditions",
                newName: "RFCondition");

            migrationBuilder.RenameColumn(
                name: "RfCreditTypeId",
                table: "SlikCreditHistorys",
                newName: "RFTipeKreditId");

            migrationBuilder.RenameIndex(
                name: "IX_SlikCreditHistorys_RfCreditTypeId",
                table: "SlikCreditHistorys",
                newName: "IX_SlikCreditHistorys_RFTipeKreditId");

            migrationBuilder.RenameColumn(
                name: "CouplePlaceOfBirth",
                table: "LoanApplicationCollaterals",
                newName: "BirthOfPlaceCouple");

            migrationBuilder.RenameColumn(
                name: "CoupleDateOfBirth",
                table: "LoanApplicationCollaterals",
                newName: "BithOfDateCouple");

            migrationBuilder.RenameIndex(
                name: "IX_RFSubProducts_ProductId",
                table: "RFSubProduct",
                newName: "IX_RFSubProduct_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "MaritalId",
                table: "LoanApplicationCollaterals",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "CompanyEntities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RfContactPersonZipCodeId",
                table: "CompanyEntities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFSubProduct",
                table: "RFSubProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfStage",
                table: "RfStage",
                column: "StageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFCondition",
                table: "RFCondition",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "RFCreditType",
                newName: "RFTipeKredit");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_LoanApplicationGuid",
                table: "LoanApplicationCreditScorings",
                column: "LoanApplicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_MaritalId",
                table: "LoanApplicationCollaterals",
                column: "MaritalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfContactPersonZipCodeId",
                table: "CompanyEntities",
                column: "RfContactPersonZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfParameterDetails_MaritalId",
                table: "LoanApplicationCollaterals",
                column: "MaritalId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditFacilities_RFSubProduct_RFSubProductId",
                table: "LoanApplicationCreditFacilities",
                column: "RFSubProductId",
                principalTable: "RFSubProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStage_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId",
                principalTable: "RfStage",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStage_TargetStage",
                table: "LoanApplicationStageLogs",
                column: "TargetStage",
                principalTable: "RfStage",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFSubProduct_RfProducts_ProductId",
                table: "RFSubProduct",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikCreditHistorys_RFCondition_RFConditionId",
                table: "SlikCreditHistorys",
                column: "RFConditionId",
                principalTable: "RFCondition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikCreditHistorys_RFTipeKredit_RFTipeKreditId",
                table: "SlikCreditHistorys",
                column: "RFTipeKreditId",
                principalTable: "RFTipeKredit",
                principalColumn: "Id");
        }
    }
}
