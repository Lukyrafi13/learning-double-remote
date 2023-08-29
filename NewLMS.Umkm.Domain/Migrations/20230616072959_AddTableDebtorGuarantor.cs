using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableDebtorGuarantor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DebtorGuarantors",
                columns: table => new
                {
                    GuarantorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSameAsDebtor = table.Column<bool>(type: "bit", nullable: false),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: true),
                    NoIdentityCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullnameCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirthCouple = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirthCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RWCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeighborhoodCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeIdCouple = table.Column<int>(type: "int", nullable: true),
                    NoMarriageCertificate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateMarriageCertificate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarriageCertificateReleasedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorGuarantors", x => x.GuarantorId);
                    table.ForeignKey(
                        name: "FK_DebtorGuarantors_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtorGuarantors_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebtorGuarantors_RfZipCodes_RfZipCodeIdCouple",
                        column: x => x.RfZipCodeIdCouple,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_RfZipCodeId",
                table: "DebtorGuarantors",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_RfZipCodeIdCouple",
                table: "DebtorGuarantors",
                column: "RfZipCodeIdCouple");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtorGuarantors");
        }
    }
}
