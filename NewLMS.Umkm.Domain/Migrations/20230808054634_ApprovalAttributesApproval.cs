using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ApprovalAttributesApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SlikRequests_AppId",
                table: "SlikRequests");

            migrationBuilder.DropIndex(
                name: "IX_Apps_ProspectId",
                table: "Apps");

            migrationBuilder.AddColumn<bool>(
                name: "BacaDanSetuju",
                table: "Approvals",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Covenant",
                table: "Approvals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_AppId",
                table: "SlikRequests",
                column: "AppId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ProspectId",
                table: "Apps",
                column: "ProspectId",
                unique: true,
                filter: "[ProspectId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SlikRequests_AppId",
                table: "SlikRequests");

            migrationBuilder.DropIndex(
                name: "IX_Apps_ProspectId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "BacaDanSetuju",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "Covenant",
                table: "Approvals");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_AppId",
                table: "SlikRequests",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ProspectId",
                table: "Apps",
                column: "ProspectId");
        }
    }
}
