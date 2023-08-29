using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableLoanAddRemarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfProgramSubProduct_RfPrograms_ProgramId",
                table: "RfProgramSubProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_RfProgramSubProduct_RfSubProducts_SubProductId",
                table: "RfProgramSubProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfProgramSubProduct",
                table: "RfProgramSubProduct");

            migrationBuilder.RenameTable(
                name: "RfProgramSubProduct",
                newName: "RfProgramSubProducts");

            migrationBuilder.RenameIndex(
                name: "IX_RfProgramSubProduct_SubProductId",
                table: "RfProgramSubProducts",
                newName: "IX_RfProgramSubProducts_SubProductId");

            migrationBuilder.RenameIndex(
                name: "IX_RfProgramSubProduct_ProgramId",
                table: "RfProgramSubProducts",
                newName: "IX_RfProgramSubProducts_ProgramId");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "LoanApplications",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfProgramSubProducts",
                table: "RfProgramSubProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RfProgramSubProducts_RfPrograms_ProgramId",
                table: "RfProgramSubProducts",
                column: "ProgramId",
                principalTable: "RfPrograms",
                principalColumn: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfProgramSubProducts_RfSubProducts_SubProductId",
                table: "RfProgramSubProducts",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfProgramSubProducts_RfPrograms_ProgramId",
                table: "RfProgramSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_RfProgramSubProducts_RfSubProducts_SubProductId",
                table: "RfProgramSubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfProgramSubProducts",
                table: "RfProgramSubProducts");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "LoanApplications");

            migrationBuilder.RenameTable(
                name: "RfProgramSubProducts",
                newName: "RfProgramSubProduct");

            migrationBuilder.RenameIndex(
                name: "IX_RfProgramSubProducts_SubProductId",
                table: "RfProgramSubProduct",
                newName: "IX_RfProgramSubProduct_SubProductId");

            migrationBuilder.RenameIndex(
                name: "IX_RfProgramSubProducts_ProgramId",
                table: "RfProgramSubProduct",
                newName: "IX_RfProgramSubProduct_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfProgramSubProduct",
                table: "RfProgramSubProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RfProgramSubProduct_RfPrograms_ProgramId",
                table: "RfProgramSubProduct",
                column: "ProgramId",
                principalTable: "RfPrograms",
                principalColumn: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfProgramSubProduct_RfSubProducts_SubProductId",
                table: "RfProgramSubProduct",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }
    }
}
