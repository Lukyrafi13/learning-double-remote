using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class CreateProspectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfBranch",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcp = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Kc = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    KanwilOri = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    OriKanwilName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kanwil = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    KanwilName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GroupBranch = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Dati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sandi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KcName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBranch", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RfInstituteCode",
                columns: table => new
                {
                    ServiceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EconomySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cultivation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfInstituteCode", x => x.ServiceCode);
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU1",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: true),
                    HideKUR = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfSectorLBU1", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU2",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LBCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfSectorLBU2", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RfSectorLBU2_RfSectorLBU1_RfSectorLBU1Code",
                        column: x => x.RfSectorLBU1Code,
                        principalTable: "RfSectorLBU1",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU3",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false),
                    LBCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfSectorLBU3", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RfSectorLBU3_RfSectorLBU2_RfSectorLBU2Code",
                        column: x => x.RfSectorLBU2Code,
                        principalTable: "RfSectorLBU2",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProspectId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountOfficer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    OwnerCategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyStatusId = table.Column<int>(type: "int", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SourceApplication = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    SameAsIdentity = table.Column<bool>(type: "bit", nullable: false),
                    PlaceAddress = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PlaceProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceNeighborhoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceZipCodeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    SectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ServiceCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetPladfond = table.Column<double>(type: "float", nullable: true),
                    EstimateProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyFullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyNeighborhoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyZipCodeId = table.Column<int>(type: "int", nullable: true),
                    CompanyGroupId = table.Column<int>(type: "int", nullable: true),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessStatus = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prospects_RfBranch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranch",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Prospects_RfGenders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_Prospects_RfInstituteCode_ServiceCodeId",
                        column: x => x.ServiceCodeId,
                        principalTable: "RfInstituteCode",
                        principalColumn: "ServiceCode");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_CompanyGroupId",
                        column: x => x.CompanyGroupId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_CompanyStatusId",
                        column: x => x.CompanyStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfParameterDetails_OwnerCategoryId",
                        column: x => x.OwnerCategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfSectorLBU3_SectorLBU3Code",
                        column: x => x.SectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_CompanyZipCodeId",
                        column: x => x.CompanyZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                        column: x => x.PlaceZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_ApplicationTypeId",
                table: "Prospects",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_BranchId",
                table: "Prospects",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CategoryId",
                table: "Prospects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyGroupId",
                table: "Prospects",
                column: "CompanyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyStatusId",
                table: "Prospects",
                column: "CompanyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyTypeId",
                table: "Prospects",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyZipCodeId",
                table: "Prospects",
                column: "CompanyZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_GenderId",
                table: "Prospects",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_OwnerCategoryId",
                table: "Prospects",
                column: "OwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_PlaceZipCodeId",
                table: "Prospects",
                column: "PlaceZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_ProductId",
                table: "Prospects",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_SectorLBU3Code",
                table: "Prospects",
                column: "SectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_ServiceCodeId",
                table: "Prospects",
                column: "ServiceCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_ZipCodeId",
                table: "Prospects",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU2_RfSectorLBU1Code",
                table: "RfSectorLBU2",
                column: "RfSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU3_RfSectorLBU2Code",
                table: "RfSectorLBU3",
                column: "RfSectorLBU2Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "RfBranch");

            migrationBuilder.DropTable(
                name: "RfInstituteCode");

            migrationBuilder.DropTable(
                name: "RfSectorLBU3");

            migrationBuilder.DropTable(
                name: "RfSectorLBU2");

            migrationBuilder.DropTable(
                name: "RfSectorLBU1");
        }
    }
}
