using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class CreateTableRfCreditType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditType",
                table: "LoanApplicationCreditHistories",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RfCreditType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreditAgreement = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfCreditType", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_CreditType",
                table: "LoanApplicationCreditHistories",
                column: "CreditType");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfCreditType_CreditType",
                table: "LoanApplicationCreditHistories",
                column: "CreditType",
                principalTable: "RfCreditType",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfCreditType_CreditType",
                table: "LoanApplicationCreditHistories");

            migrationBuilder.DropTable(
                name: "RfCreditType");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCreditHistories_CreditType",
                table: "LoanApplicationCreditHistories");

            migrationBuilder.DropColumn(
                name: "CreditType",
                table: "LoanApplicationCreditHistories");
        }
    }
}
