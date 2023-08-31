using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddLoanAppKeyPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationKeyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifeTime = table.Column<bool>(type: "bit", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationKeyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RFEDUCATION_RfEducationId",
                        column: x => x.RfEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RFMARITAL_RfMaritalId",
                        column: x => x.RfMaritalId,
                        principalTable: "RFMARITAL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_LoanApplicationId",
                table: "LoanApplicationKeyPersons",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_RfEducationId",
                table: "LoanApplicationKeyPersons",
                column: "RfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_RfMaritalId",
                table: "LoanApplicationKeyPersons",
                column: "RfMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_RfZipCodeId",
                table: "LoanApplicationKeyPersons",
                column: "RfZipCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationKeyPersons");
        }
    }
}
