using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddProspectEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfAppTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfAppTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfBranches",
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
                    table.PrimaryKey("PK_RfBranches", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RfCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfCompanyGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCompanyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfCompanyStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCompanyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfCompanyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnlCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU1s",
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
                    table.PrimaryKey("PK_RfSectorLBU1s", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RfServiceCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfServiceCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfZipCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    ZipDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dati_II = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dati_II_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Negara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SandiWilayahBI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    KodeKabupaten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeProvinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeKabKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeKecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeKelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfZipCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU2s",
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
                    table.PrimaryKey("PK_RfSectorLBU2s", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RfSectorLBU2s_RfSectorLBU1s_RfSectorLBU1Code",
                        column: x => x.RfSectorLBU1Code,
                        principalTable: "RfSectorLBU1s",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "RfSectorLBU3s",
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
                    table.PrimaryKey("PK_RfSectorLBU3s", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RfSectorLBU3s_RfSectorLBU2s_RfSectorLBU2Code",
                        column: x => x.RfSectorLBU2Code,
                        principalTable: "RfSectorLBU2s",
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
                    RfOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfCompanyStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    RfProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfAppTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfTargetStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfServiceCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    CompanyZipCodeId = table.Column<int>(type: "int", nullable: false),
                    RfCompanyGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfCompanyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OtherCompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Prospects_RfAppTypes_RfAppTypeId",
                        column: x => x.RfAppTypeId,
                        principalTable: "RfAppTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Prospects_RfCategories_RfCategoryId",
                        column: x => x.RfCategoryId,
                        principalTable: "RfCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfCompanyGroups_RfCompanyGroupId",
                        column: x => x.RfCompanyGroupId,
                        principalTable: "RfCompanyGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfCompanyStatuses_RfCompanyStatusId",
                        column: x => x.RfCompanyStatusId,
                        principalTable: "RfCompanyStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfCompanyTypes_RfCompanyTypeId",
                        column: x => x.RfCompanyTypeId,
                        principalTable: "RfCompanyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfGenders_RfGenderId",
                        column: x => x.RfGenderId,
                        principalTable: "RfGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfOwnerCategories_RfOwnerCategoryId",
                        column: x => x.RfOwnerCategoryId,
                        principalTable: "RfOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfProducts_RfProductId",
                        column: x => x.RfProductId,
                        principalTable: "RfProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfSectorLBU3s_RfSectorLBU3Code",
                        column: x => x.RfSectorLBU3Code,
                        principalTable: "RfSectorLBU3s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Prospects_RfServiceCodes_RfServiceCodeId",
                        column: x => x.RfServiceCodeId,
                        principalTable: "RfServiceCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfTargetStatuses_RfTargetStatusId",
                        column: x => x.RfTargetStatusId,
                        principalTable: "RfTargetStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_CompanyZipCodeId",
                        column: x => x.CompanyZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                        column: x => x.PlaceZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_BranchId",
                table: "Prospects",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyZipCodeId",
                table: "Prospects",
                column: "CompanyZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_PlaceZipCodeId",
                table: "Prospects",
                column: "PlaceZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfAppTypeId",
                table: "Prospects",
                column: "RfAppTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCategoryId",
                table: "Prospects",
                column: "RfCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyGroupId",
                table: "Prospects",
                column: "RfCompanyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyStatusId",
                table: "Prospects",
                column: "RfCompanyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyTypeId",
                table: "Prospects",
                column: "RfCompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfGenderId",
                table: "Prospects",
                column: "RfGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfOwnerCategoryId",
                table: "Prospects",
                column: "RfOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfProductId",
                table: "Prospects",
                column: "RfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfSectorLBU3Code",
                table: "Prospects",
                column: "RfSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfServiceCodeId",
                table: "Prospects",
                column: "RfServiceCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfTargetStatusId",
                table: "Prospects",
                column: "RfTargetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_ZipCodeId",
                table: "Prospects",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU2s_RfSectorLBU1Code",
                table: "RfSectorLBU2s",
                column: "RfSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU3s_RfSectorLBU2Code",
                table: "RfSectorLBU3s",
                column: "RfSectorLBU2Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "RfAppTypes");

            migrationBuilder.DropTable(
                name: "RfBranches");

            migrationBuilder.DropTable(
                name: "RfCategories");

            migrationBuilder.DropTable(
                name: "RfCompanyGroups");

            migrationBuilder.DropTable(
                name: "RfCompanyStatuses");

            migrationBuilder.DropTable(
                name: "RfCompanyTypes");

            migrationBuilder.DropTable(
                name: "RfSectorLBU3s");

            migrationBuilder.DropTable(
                name: "RfServiceCodes");

            migrationBuilder.DropTable(
                name: "RfZipCodes");

            migrationBuilder.DropTable(
                name: "RfSectorLBU2s");

            migrationBuilder.DropTable(
                name: "RfSectorLBU1s");
        }
    }
}
