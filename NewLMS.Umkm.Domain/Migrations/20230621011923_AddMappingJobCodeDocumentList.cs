using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddMappingJobCodeDocumentList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors");

            migrationBuilder.AddColumn<string>(
                name: "JobCode",
                table: "RfDocumentLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MartitalStatus",
                table: "RfDocumentLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors",
                column: "LoanApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors");

            migrationBuilder.DropColumn(
                name: "JobCode",
                table: "RfDocumentLists");

            migrationBuilder.DropColumn(
                name: "MartitalStatus",
                table: "RfDocumentLists");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors",
                column: "LoanApplicationId");
        }
    }
}
