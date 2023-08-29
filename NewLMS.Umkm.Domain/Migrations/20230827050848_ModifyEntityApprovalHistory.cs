using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyEntityApprovalHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AH_SEQ",
                table: "ApprovalHistorys",
                newName: "ApprovalHistorySeq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalHistorySeq",
                table: "ApprovalHistorys",
                newName: "AH_SEQ");
        }
    }
}
