using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class DebtorJobIdInSIKP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "SIKPResponses",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidationMessage",
                table: "SIKPResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorJobId",
                table: "SIKPRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorJobId",
                table: "SIKPRequests",
                column: "DebtorJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfJobs_DebtorJobId",
                table: "SIKPRequests",
                column: "DebtorJobId",
                principalTable: "RfJobs",
                principalColumn: "JobCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfJobs_DebtorJobId",
                table: "SIKPRequests");

            migrationBuilder.DropIndex(
                name: "IX_SIKPRequests_DebtorJobId",
                table: "SIKPRequests");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "ValidationMessage",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "DebtorJobId",
                table: "SIKPRequests");
        }
    }
}
