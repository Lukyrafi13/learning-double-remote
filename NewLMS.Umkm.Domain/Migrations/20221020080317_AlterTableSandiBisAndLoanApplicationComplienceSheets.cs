using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSandiBisAndLoanApplicationComplienceSheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValidIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProofOfIncome",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorrectIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralInsurance",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralInsurance",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralInsurance");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CorrectIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "CorrectIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets",
                column: "CreditLifeInsurance");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_EmployeeIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "EmployeeIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets",
                column: "FamilyCertificateLegal");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_ProofOfIncome",
                table: "LoanApplicationComplienceSheets",
                column: "ProofOfIncome");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_ValidIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "ValidIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralInsurance",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralInsurance",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CorrectIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "CorrectIdentity",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets",
                column: "CreditLifeInsurance",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_EmployeeIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "EmployeeIdentity",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets",
                column: "FamilyCertificateLegal",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ProofOfIncome",
                table: "LoanApplicationComplienceSheets",
                column: "ProofOfIncome",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ValidIdentity",
                table: "LoanApplicationComplienceSheets",
                column: "ValidIdentity",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralInsurance",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CorrectIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_EmployeeIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ProofOfIncome",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ValidIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralInsurance",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CorrectIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_EmployeeIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_ProofOfIncome",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_ValidIdentity",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.AlterColumn<string>(
                name: "ValidIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProofOfIncome",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FamilyCertificateLegal",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditLifeInsurance",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorrectIdentity",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralInsurance",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
