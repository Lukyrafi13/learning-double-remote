using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilityAddReferenceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NikReference",
                table: "SubmittedFacilitiesLogs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoBankAccountReference",
                table: "SubmittedFacilitiesLogs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NikReference",
                table: "SubmittedFacilities",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoBankAccountReference",
                table: "SubmittedFacilities",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoBankAccount",
                table: "Debtors",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NikReference",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "NoBankAccountReference",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "NikReference",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "NoBankAccountReference",
                table: "SubmittedFacilities");

            migrationBuilder.AlterColumn<string>(
                name: "NoBankAccount",
                table: "Debtors",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
