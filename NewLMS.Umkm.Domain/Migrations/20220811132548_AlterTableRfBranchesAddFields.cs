using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableRfBranchesAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dati",
                table: "RfBranches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupBranch",
                table: "RfBranches",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kanwil",
                table: "RfBranches",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KanwilName",
                table: "RfBranches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KanwilOri",
                table: "RfBranches",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kc",
                table: "RfBranches",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KcName",
                table: "RfBranches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kcp",
                table: "RfBranches",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeType",
                table: "RfBranches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriKanwilName",
                table: "RfBranches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "RfBranches",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dati",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "GroupBranch",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "Kanwil",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "KanwilName",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "KanwilOri",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "Kc",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "KcName",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "Kcp",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "OfficeType",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "OriKanwilName",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "RfBranches");
        }
    }
}
