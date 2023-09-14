using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addLoanAppRACandDupicationVerified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LoanApplicationVerified",
                table: "LoanApplications",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanApplicationRACs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumAge = table.Column<bool>(type: "bit", nullable: true),
                    MaximumAge = table.Column<bool>(type: "bit", nullable: true),
                    IdentityCard = table.Column<bool>(type: "bit", nullable: true),
                    NationalBlacklist = table.Column<bool>(type: "bit", nullable: true),
                    BICollectibility = table.Column<bool>(type: "bit", nullable: true),
                    NotCollectibility = table.Column<bool>(type: "bit", nullable: true),
                    HasAge = table.Column<bool>(type: "bit", nullable: true),
                    HasNoCreditFacilities = table.Column<bool>(type: "bit", nullable: true),
                    NeverReceivedCredit = table.Column<bool>(type: "bit", nullable: true),
                    BPJSTKParticipants = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationRACs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationRACs_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationRACs");

            migrationBuilder.DropColumn(
                name: "LoanApplicationVerified",
                table: "LoanApplications");
        }
    }
}
