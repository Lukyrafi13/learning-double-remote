using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class ChangeColumnIdAndPasswordToCodeAndSandiInTableRfBranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "RfBranches",
                newName: "Sandi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RfBranches",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sandi",
                table: "RfBranches",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "RfBranches",
                newName: "Id");
        }
    }
}
