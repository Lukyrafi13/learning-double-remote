using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfProducts_RfProductProductId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfSubProducts_RfSubProductSubProductId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_RfProductProductId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfProductProductId",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "RfSubProductSubProductId",
                table: "LoanApplications",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_RfSubProductSubProductId",
                table: "LoanApplications",
                newName: "IX_LoanApplications_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "BusinessCycleId",
                table: "LoanApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessCycleMonth",
                table: "LoanApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusinessCycle",
                table: "LoanApplications",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BusinessCycleId",
                table: "LoanApplications",
                column: "BusinessCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfParameterDetails_BusinessCycleId",
                table: "LoanApplications",
                column: "BusinessCycleId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfProducts_ProductId",
                table: "LoanApplications",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfParameterDetails_BusinessCycleId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfProducts_ProductId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BusinessCycleId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BusinessCycleId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BusinessCycleMonth",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "IsBusinessCycle",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "LoanApplications",
                newName: "RfSubProductSubProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_ProductId",
                table: "LoanApplications",
                newName: "IX_LoanApplications_RfSubProductSubProductId");

            migrationBuilder.AddColumn<string>(
                name: "RfProductProductId",
                table: "LoanApplications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfProductProductId",
                table: "LoanApplications",
                column: "RfProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfProducts_RfProductProductId",
                table: "LoanApplications",
                column: "RfProductProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfSubProducts_RfSubProductSubProductId",
                table: "LoanApplications",
                column: "RfSubProductSubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }
    }
}
