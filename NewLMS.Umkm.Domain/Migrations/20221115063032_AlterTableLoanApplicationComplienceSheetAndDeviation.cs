using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationComplienceSheetAndDeviation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConflictOfInterest",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerSince",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DHNwithdrawal",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Decision",
                table: "Deviations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_ConflictOfInterest",
                table: "LoanApplicationComplienceSheets",
                column: "ConflictOfInterest");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CustomerSince",
                table: "LoanApplicationComplienceSheets",
                column: "CustomerSince");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_DHNwithdrawal",
                table: "LoanApplicationComplienceSheets",
                column: "DHNwithdrawal");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ConflictOfInterest",
                table: "LoanApplicationComplienceSheets",
                column: "ConflictOfInterest",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CustomerSince",
                table: "LoanApplicationComplienceSheets",
                column: "CustomerSince",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_DHNwithdrawal",
                table: "LoanApplicationComplienceSheets",
                column: "DHNwithdrawal",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ConflictOfInterest",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CustomerSince",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_DHNwithdrawal",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_ConflictOfInterest",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CustomerSince",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_DHNwithdrawal",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "ConflictOfInterest",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "CustomerSince",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "DHNwithdrawal",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.AlterColumn<bool>(
                name: "Decision",
                table: "Deviations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
