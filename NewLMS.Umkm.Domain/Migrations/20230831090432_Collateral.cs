using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class Collateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Due = table.Column<int>(type: "int", nullable: true),
                    ManDocNo = table.Column<bool>(type: "bit", nullable: true),
                    ISTBO = table.Column<bool>(type: "bit", nullable: true),
                    Mandatory = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RFDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFMappingAgunan2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFMappingAgunan2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCollaterals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentPublisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrameNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomicileBySTNK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementLetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituationPictureMasurementLetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralZipCodeId = table.Column<int>(type: "int", nullable: true),
                    CollateralNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralDocumentNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralDocumentDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralDocumentCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralDocumentProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HTRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementLetterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LandSurfaceArea = table.Column<double>(type: "float", nullable: true),
                    BuildingSurfaceArea = table.Column<double>(type: "float", nullable: true),
                    BuildingPermit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxObjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NJOPPBBValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NorthernPerimeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SouthernPerimeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WestPerimeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EastPerimeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralOwnedByDebtor = table.Column<bool>(type: "bit", nullable: true),
                    OtherRelation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: true),
                    OwnerNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthOfPlaceCouple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BithOfDateCouple = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoupleNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleIdentityExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoupleIdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    CoupleAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeIdCouple = table.Column<int>(type: "int", nullable: true),
                    CoupleNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupleNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouplePekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfMappingCollateralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VehTypeCollateralId = table.Column<int>(type: "int", nullable: true),
                    RFDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFVehMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFVehClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFVehModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelationColId = table.Column<int>(type: "int", nullable: true),
                    MaritalId = table.Column<int>(type: "int", nullable: true),
                    DeedTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCollaterals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_LoanApplications_LoanApplicationGuid",
                        column: x => x.LoanApplicationGuid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfAppTypes_AppId",
                        column: x => x.AppId,
                        principalTable: "RfAppTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RFDocument_RFDocumentId",
                        column: x => x.RFDocumentId,
                        principalTable: "RFDocument",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RFMappingAgunan2_RfMappingCollateralId",
                        column: x => x.RfMappingCollateralId,
                        principalTable: "RFMappingAgunan2",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfParameterDetails_DeedTypeId",
                        column: x => x.DeedTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfParameterDetails_MaritalId",
                        column: x => x.MaritalId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfParameterDetails_RelationColId",
                        column: x => x.RelationColId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfParameterDetails_VehTypeCollateralId",
                        column: x => x.VehTypeCollateralId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RFVEHCLASS_RFVehClassId",
                        column: x => x.RFVehClassId,
                        principalTable: "RFVEHCLASS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RFVEHMAKER_RFVehMakerId",
                        column: x => x.RFVehMakerId,
                        principalTable: "RFVEHMAKER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RFVehModels_RFVehModelId",
                        column: x => x.RFVehModelId,
                        principalTable: "RFVehModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfZipCodes_CollateralZipCodeId",
                        column: x => x.CollateralZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfZipCodes_RfZipCodeIdCouple",
                        column: x => x.RfZipCodeIdCouple,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_AppId",
                table: "LoanApplicationCollaterals",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_CollateralZipCodeId",
                table: "LoanApplicationCollaterals",
                column: "CollateralZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_DeedTypeId",
                table: "LoanApplicationCollaterals",
                column: "DeedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_LoanApplicationGuid",
                table: "LoanApplicationCollaterals",
                column: "LoanApplicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_MaritalId",
                table: "LoanApplicationCollaterals",
                column: "MaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RelationColId",
                table: "LoanApplicationCollaterals",
                column: "RelationColId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RFDocumentId",
                table: "LoanApplicationCollaterals",
                column: "RFDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RfMappingCollateralId",
                table: "LoanApplicationCollaterals",
                column: "RfMappingCollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RFVehClassId",
                table: "LoanApplicationCollaterals",
                column: "RFVehClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RFVehMakerId",
                table: "LoanApplicationCollaterals",
                column: "RFVehMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RFVehModelId",
                table: "LoanApplicationCollaterals",
                column: "RFVehModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RfZipCodeId",
                table: "LoanApplicationCollaterals",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_RfZipCodeIdCouple",
                table: "LoanApplicationCollaterals",
                column: "RfZipCodeIdCouple");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehTypeCollateralId",
                table: "LoanApplicationCollaterals",
                column: "VehTypeCollateralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationCollaterals");

            migrationBuilder.DropTable(
                name: "RFDocument");

            migrationBuilder.DropTable(
                name: "RFMappingAgunan2");
        }
    }
}
