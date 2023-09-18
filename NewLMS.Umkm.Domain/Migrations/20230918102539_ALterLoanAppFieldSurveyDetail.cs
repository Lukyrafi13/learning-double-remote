using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ALterLoanAppFieldSurveyDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationFieldSurveyDetails_RfParameterDetails_PaymentMethodId",
                table: "LoanApplicationFieldSurveyDetails");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "LoanApplicationFieldSurveyDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationFieldSurveyDetails_RfParameterDetails_PaymentMethodId",
                table: "LoanApplicationFieldSurveyDetails",
                column: "PaymentMethodId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationFieldSurveyDetails_RfParameterDetails_PaymentMethodId",
                table: "LoanApplicationFieldSurveyDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "LoanApplicationFieldSurveyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationFieldSurveyDetails_RfParameterDetails_PaymentMethodId",
                table: "LoanApplicationFieldSurveyDetails",
                column: "PaymentMethodId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }
    }
}
