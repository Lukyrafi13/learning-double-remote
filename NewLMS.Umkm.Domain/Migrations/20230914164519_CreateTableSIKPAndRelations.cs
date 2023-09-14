using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class CreateTableSIKPAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CIF",
                table: "Debtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SIKPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SIKPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPs_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIKPRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebtorSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorGenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorMaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorEducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorZipCodeId = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyEstablishmentDeedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyZipCodeId = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyPermit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyVentureCapital = table.Column<long>(type: "bigint", nullable: false),
                    DebtorCompanyCreditValue = table.Column<long>(type: "bigint", nullable: false),
                    DebtorCompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyCollaterals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyEmployee = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyLingkageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorCompanySubisdyStatus = table.Column<bool>(type: "bit", nullable: false),
                    DebtorCompanyPreviousSubsidy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyRfZipCodeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SIKPRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfEducations_DebtorEducationId",
                        column: x => x.DebtorEducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfGenders_DebtorGenderId",
                        column: x => x.DebtorGenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfLinkAges_DebtorCompanyLingkageId",
                        column: x => x.DebtorCompanyLingkageId,
                        principalTable: "RfLinkAges",
                        principalColumn: "LinkAgeCode");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfMaritals_DebtorMaritalStatusId",
                        column: x => x.DebtorMaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfSectorLBU3_DebtorSectorLBU3Code",
                        column: x => x.DebtorSectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfZipCodes_DebtorCompanyRfZipCodeId",
                        column: x => x.DebtorCompanyRfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPRequests_RfZipCodes_DebtorZipCodeId",
                        column: x => x.DebtorZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIKPRequests_SIKPs_Id",
                        column: x => x.Id,
                        principalTable: "SIKPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIKPResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebtorSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorGenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorMaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorEducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorZipCodeId = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyEstablishmentDeedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyZipCodeId = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyPermit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyVentureCapital = table.Column<long>(type: "bigint", nullable: false),
                    DebtorCompanyCreditValue = table.Column<long>(type: "bigint", nullable: false),
                    DebtorCompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyCollaterals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyEmployee = table.Column<int>(type: "int", nullable: false),
                    DebtorCompanyLingkageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorCompanySubisdyStatus = table.Column<bool>(type: "bit", nullable: false),
                    DebtorCompanyPreviousSubsidy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyRfZipCodeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SIKPResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfEducations_DebtorEducationId",
                        column: x => x.DebtorEducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfGenders_DebtorGenderId",
                        column: x => x.DebtorGenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfLinkAges_DebtorCompanyLingkageId",
                        column: x => x.DebtorCompanyLingkageId,
                        principalTable: "RfLinkAges",
                        principalColumn: "LinkAgeCode");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfMaritals_DebtorMaritalStatusId",
                        column: x => x.DebtorMaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfSectorLBU3_DebtorSectorLBU3Code",
                        column: x => x.DebtorSectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfZipCodes_DebtorCompanyRfZipCodeId",
                        column: x => x.DebtorCompanyRfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPResponses_RfZipCodes_DebtorZipCodeId",
                        column: x => x.DebtorZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIKPResponses_SIKPs_Id",
                        column: x => x.Id,
                        principalTable: "SIKPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorCompanyLingkageId",
                table: "SIKPRequests",
                column: "DebtorCompanyLingkageId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorCompanyRfZipCodeId",
                table: "SIKPRequests",
                column: "DebtorCompanyRfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorEducationId",
                table: "SIKPRequests",
                column: "DebtorEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorGenderId",
                table: "SIKPRequests",
                column: "DebtorGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorMaritalStatusId",
                table: "SIKPRequests",
                column: "DebtorMaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorSectorLBU3Code",
                table: "SIKPRequests",
                column: "DebtorSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorZipCodeId",
                table: "SIKPRequests",
                column: "DebtorZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorCompanyLingkageId",
                table: "SIKPResponses",
                column: "DebtorCompanyLingkageId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorCompanyRfZipCodeId",
                table: "SIKPResponses",
                column: "DebtorCompanyRfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorEducationId",
                table: "SIKPResponses",
                column: "DebtorEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorGenderId",
                table: "SIKPResponses",
                column: "DebtorGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorMaritalStatusId",
                table: "SIKPResponses",
                column: "DebtorMaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorSectorLBU3Code",
                table: "SIKPResponses",
                column: "DebtorSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorZipCodeId",
                table: "SIKPResponses",
                column: "DebtorZipCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIKPRequests");

            migrationBuilder.DropTable(
                name: "SIKPResponses");

            migrationBuilder.DropTable(
                name: "SIKPs");

            migrationBuilder.DropColumn(
                name: "CIF",
                table: "Debtors");
        }
    }
}
