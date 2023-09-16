using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPResponseAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebtorJobId",
                table: "SIKPResponses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorJobId",
                table: "SIKPResponses",
                column: "DebtorJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfJobs_DebtorJobId",
                table: "SIKPResponses",
                column: "DebtorJobId",
                principalTable: "RfJobs",
                principalColumn: "JobCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfJobs_DebtorJobId",
                table: "SIKPResponses");

            migrationBuilder.DropIndex(
                name: "IX_SIKPResponses_DebtorJobId",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "DebtorJobId",
                table: "SIKPResponses");
        }
    }
}
