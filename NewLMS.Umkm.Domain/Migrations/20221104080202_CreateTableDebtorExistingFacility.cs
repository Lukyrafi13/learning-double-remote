using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableDebtorExistingFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DebtorExistingFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtorId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plafond = table.Column<int>(type: "int", nullable: false),
                    Outstanding = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestAccrued = table.Column<int>(type: "int", nullable: false),
                    PastDueInterest = table.Column<int>(type: "int", nullable: false),
                    FeeAdministration = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    NextScheduleInterestAmount = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DebtorExistingFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorExistingFacilities_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtorExistingFacilities_DebtorId",
                table: "DebtorExistingFacilities",
                column: "DebtorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtorExistingFacilities");
        }
    }
}
