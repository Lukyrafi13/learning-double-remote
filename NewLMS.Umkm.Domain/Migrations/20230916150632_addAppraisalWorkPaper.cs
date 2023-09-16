using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addAppraisalWorkPaper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprMachineTemplates",
                columns: table => new
                {
                    ApprMachineTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOnInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Overhaul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodicService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    WilayahVillageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprMachineTemplates", x => x.ApprMachineTemplateGuid);
                    table.ForeignKey(
                        name: "FK_ApprMachineTemplates_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprMachineTemplates_WilayahVillages_WilayahVillageCode",
                        column: x => x.WilayahVillageCode,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprProductiveLandTemplate",
                columns: table => new
                {
                    ApprProductiveLandTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollateralOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inhabited = table.Column<bool>(type: "bit", nullable: false),
                    IsHaveBuilding = table.Column<bool>(type: "bit", nullable: false),
                    InhabitedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Electric = table.Column<bool>(type: "bit", nullable: false),
                    CleanWater = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<bool>(type: "bit", nullable: false),
                    Gas = table.Column<bool>(type: "bit", nullable: false),
                    GarbageCollection = table.Column<bool>(type: "bit", nullable: false),
                    Irrigation = table.Column<bool>(type: "bit", nullable: false),
                    Entrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driveway = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drainase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvDrainase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NorthernBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SouthernBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WesternBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EasternBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvGrowth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvDensity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvComodity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvEaseOfAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvWaterFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvWaterQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvTransport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvDisasterSafety = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvChangesFutureUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvMajorityOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertficateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeasureLetterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureLetterDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandShape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandAreaValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topografi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Greening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrangement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterDisposal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloodRisk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FireRisk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighVoltage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicBurial = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectricNetwork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvRoad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvCertificateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvPublicBurial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residential = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Farm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plantation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lifetime = table.Column<bool>(type: "bit", nullable: false),
                    Skewer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarbageCollectionDistance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvEntrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprProductiveLandTemplate", x => x.ApprProductiveLandTemplateGuid);
                    table.ForeignKey(
                        name: "FK_ApprProductiveLandTemplate_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprProductiveLandTemplate_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApprVehicleTemplate",
                columns: table => new
                {
                    ApprVehicleTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomicileCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BpkbNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BpkbName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaintCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodicService = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprVehicleTemplate", x => x.ApprVehicleTemplateGuid);
                    table.ForeignKey(
                        name: "FK_ApprVehicleTemplate_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperLandBuildingSummaries",
                columns: table => new
                {
                    ApprWorkPaperLandBuildingSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PctTotalIndicatorValue = table.Column<double>(type: "float", nullable: true),
                    CurrTotalIndicatorValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrRounding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrLandMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrBuildingMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrAssetMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLandLiquidationValue = table.Column<double>(type: "float", nullable: true),
                    LandLiquidationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctBuildingLiquidationValue = table.Column<double>(type: "float", nullable: true),
                    BuildingLiquidationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperLandBuildingSummaries", x => x.ApprWorkPaperLandBuildingSummaryGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildingSummaries_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperMachineMarketSummaries",
                columns: table => new
                {
                    ApprWorkPaperMachineMarketSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLiquidationValue = table.Column<double>(type: "float", nullable: true),
                    LiquidationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrMarketCostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLiquidationCostValue = table.Column<double>(type: "float", nullable: true),
                    LiquidationCostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApproachType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperMachineMarketSummaries", x => x.ApprWorkPaperMachineMarketSummaryGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarketSummaries_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarketSummaries_Parameters_ApproachType",
                        column: x => x.ApproachType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperShopApartmentSummaries",
                columns: table => new
                {
                    ApprWorkPaperShopApartmentSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrShopValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrShopMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLiquidationValue = table.Column<double>(type: "float", nullable: true),
                    LiquidationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperShopApartmentSummaries", x => x.ApprWorkPaperShopApartmentSummaryGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartmentSummaries_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperVehicleSummaries",
                columns: table => new
                {
                    ApprWorkPaperVehicleSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrShopValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLiquidationValue = table.Column<double>(type: "float", nullable: true),
                    LiquidationValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperVehicleSummaries", x => x.ApprWorkPaperVehicleSummaryGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicleSummaries_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MLiquidation",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_MLiquidation", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperLandBuildings",
                columns: table => new
                {
                    ApprWorkPaperLandBuildingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprWorkPaperLandBuildingSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprBuildingTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprLandTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprProductiveLandTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataNumber = table.Column<int>(type: "int", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AddressReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ObjectDistance = table.Column<double>(type: "float", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfferTime = table.Column<int>(type: "int", nullable: true),
                    OfferValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctDiscount = table.Column<double>(type: "float", nullable: true),
                    BuildingCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EconomicalAge = table.Column<int>(type: "int", nullable: true),
                    BuildingArea = table.Column<double>(type: "float", nullable: true),
                    YearBuilt = table.Column<int>(type: "int", nullable: true),
                    RenovatedYear = table.Column<int>(type: "int", nullable: true),
                    PctRenovationAdjustment = table.Column<double>(type: "float", nullable: true),
                    PctDepreciation = table.Column<double>(type: "float", nullable: true),
                    PctDepreciationAdjustment = table.Column<double>(type: "float", nullable: true),
                    PctDepreciationFinal = table.Column<double>(type: "float", nullable: true),
                    CurrBuildingValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrDepreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrRcnDepreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrBuildingMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LandDocument = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandArea = table.Column<double>(type: "float", nullable: true),
                    LandForm = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrontageWidth = table.Column<double>(type: "float", nullable: true),
                    RoadWidth = table.Column<double>(type: "float", nullable: true),
                    LandPosition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandCondition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Allotment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topografi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PropertyValueIndicator = table.Column<double>(type: "float", nullable: true),
                    BuildingMarketValueIndicator = table.Column<double>(type: "float", nullable: true),
                    LandValueIndicator = table.Column<double>(type: "float", nullable: true),
                    LandValueAreaIndicator = table.Column<double>(type: "float", nullable: true),
                    PctLocation = table.Column<double>(type: "float", nullable: true),
                    PctLandDocument = table.Column<double>(type: "float", nullable: true),
                    PctLandArea = table.Column<double>(type: "float", nullable: true),
                    PctFrontageWidth = table.Column<double>(type: "float", nullable: true),
                    PctRoadWidth = table.Column<double>(type: "float", nullable: true),
                    PctActivaPosition = table.Column<double>(type: "float", nullable: true),
                    PctFacility = table.Column<double>(type: "float", nullable: true),
                    PctUsage = table.Column<double>(type: "float", nullable: true),
                    PctOther1 = table.Column<double>(type: "float", nullable: true),
                    PctOther2 = table.Column<double>(type: "float", nullable: true),
                    PctTotalAdjustment = table.Column<double>(type: "float", nullable: true),
                    IndicatorValue = table.Column<double>(type: "float", nullable: true),
                    PctAdjustmentAbsolute = table.Column<double>(type: "float", nullable: true),
                    CurrLocation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrLandDocument = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrLandArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrFrontageWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrRoadWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrActivaPosition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrFacility = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrUsage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrOther1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrOther2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrTotalAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctDataWeight = table.Column<double>(type: "float", nullable: true),
                    CurrDataWeight = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperLandBuildings", x => x.ApprWorkPaperLandBuildingGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_ApprBuildingTemplates_ApprBuildingTemplateGuid",
                        column: x => x.ApprBuildingTemplateGuid,
                        principalTable: "ApprBuildingTemplates",
                        principalColumn: "ApprEnvironmentGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_ApprLandTemplates_ApprLandTemplateGuid",
                        column: x => x.ApprLandTemplateGuid,
                        principalTable: "ApprLandTemplates",
                        principalColumn: "ApprLandTemplateGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_ApprProductiveLandTemplate_ApprProductiveLandTemplateGuid",
                        column: x => x.ApprProductiveLandTemplateGuid,
                        principalTable: "ApprProductiveLandTemplate",
                        principalColumn: "ApprProductiveLandTemplateGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_ApprWorkPaperLandBuildingSummaries_ApprWorkPaperLandBuildingSummaryGuid",
                        column: x => x.ApprWorkPaperLandBuildingSummaryGuid,
                        principalTable: "ApprWorkPaperLandBuildingSummaries",
                        principalColumn: "ApprWorkPaperLandBuildingSummaryGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_BuildingCategory",
                        column: x => x.BuildingCategory,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_LandCondition",
                        column: x => x.LandCondition,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_LandDocument",
                        column: x => x.LandDocument,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_LandForm",
                        column: x => x.LandForm,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_LandPosition",
                        column: x => x.LandPosition,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_Offer",
                        column: x => x.Offer,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_Parameters_Topografi",
                        column: x => x.Topografi,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperLandBuildings_WilayahVillages_AddressReference",
                        column: x => x.AddressReference,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperMachineCost",
                columns: table => new
                {
                    ApprWorkPaperMachineCostGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprWorkPaperMachineMarketSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprMachineTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DistributorPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EconomicAge = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctDepreciation = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperMachineCost", x => x.ApprWorkPaperMachineCostGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineCost_ApprMachineTemplates_ApprMachineTemplateGuid",
                        column: x => x.ApprMachineTemplateGuid,
                        principalTable: "ApprMachineTemplates",
                        principalColumn: "ApprMachineTemplateGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineCost_ApprWorkPaperMachineMarketSummaries_ApprWorkPaperMachineMarketSummaryGuid",
                        column: x => x.ApprWorkPaperMachineMarketSummaryGuid,
                        principalTable: "ApprWorkPaperMachineMarketSummaries",
                        principalColumn: "ApprWorkPaperMachineMarketSummaryGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperMachineMarkets",
                columns: table => new
                {
                    ApprWorkPaperMachineMarketGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprWorkPaperMachineMarketSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprMachineTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataNumber = table.Column<int>(type: "int", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AddressReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TransactionOffer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Merk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PctDataDate = table.Column<double>(type: "float", nullable: true),
                    PctModelType = table.Column<double>(type: "float", nullable: true),
                    PctCapacity = table.Column<double>(type: "float", nullable: true),
                    PctYear = table.Column<double>(type: "float", nullable: true),
                    PctCondition = table.Column<double>(type: "float", nullable: true),
                    PctManufacurerCountry = table.Column<double>(type: "float", nullable: true),
                    PctDiscount = table.Column<double>(type: "float", nullable: true),
                    PctTotalAdjustment = table.Column<double>(type: "float", nullable: true),
                    PctAbsoluteAdjustment = table.Column<double>(type: "float", nullable: true),
                    PctWeight = table.Column<double>(type: "float", nullable: true),
                    CurrDataDate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrModelType = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrYear = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrCondition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrManufacurerCountry = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrTransactionIndicator = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrValueAfterAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrAmountIndicator = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperMachineMarkets", x => x.ApprWorkPaperMachineMarketGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarkets_ApprMachineTemplates_ApprMachineTemplateGuid",
                        column: x => x.ApprMachineTemplateGuid,
                        principalTable: "ApprMachineTemplates",
                        principalColumn: "ApprMachineTemplateGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarkets_ApprWorkPaperMachineMarketSummaries_ApprWorkPaperMachineMarketSummaryGuid",
                        column: x => x.ApprWorkPaperMachineMarketSummaryGuid,
                        principalTable: "ApprWorkPaperMachineMarketSummaries",
                        principalColumn: "ApprWorkPaperMachineMarketSummaryGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarkets_Parameters_TransactionOffer",
                        column: x => x.TransactionOffer,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperMachineMarkets_WilayahVillages_AddressReference",
                        column: x => x.AddressReference,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperShopApartments",
                columns: table => new
                {
                    ApprWorkPaperShopApartmentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprWorkPaperShopApartmentSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprBuildingTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataNumber = table.Column<int>(type: "int", nullable: true),
                    DataType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AddressReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectDistance = table.Column<double>(type: "float", nullable: true),
                    RoadWidth = table.Column<double>(type: "float", nullable: true),
                    DataUsage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allotment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AreaTotalBuildingFloor = table.Column<double>(type: "float", nullable: true),
                    AreaActualLandControlled = table.Column<double>(type: "float", nullable: true),
                    AreaFirstFloorBuilding = table.Column<double>(type: "float", nullable: true),
                    AreaEqualizationCoefficient = table.Column<double>(type: "float", nullable: true),
                    LandForm = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandCondition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ownership = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacilityInfrastructure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrPriceEqualization = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctDiscount = table.Column<double>(type: "float", nullable: true),
                    CurrPriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrShopPriceM2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctLocation = table.Column<double>(type: "float", nullable: true),
                    PctBuildingArea = table.Column<double>(type: "float", nullable: true),
                    PctBuildingDesign = table.Column<double>(type: "float", nullable: true),
                    PctPhysicBuildingCondition = table.Column<double>(type: "float", nullable: true),
                    PctPhysicLandArea = table.Column<double>(type: "float", nullable: true),
                    PctOwnership = table.Column<double>(type: "float", nullable: true),
                    PctOther = table.Column<double>(type: "float", nullable: true),
                    PctTotalAdjustment = table.Column<double>(type: "float", nullable: true),
                    PctTotalAbsolute = table.Column<double>(type: "float", nullable: true),
                    PctDataWeight = table.Column<double>(type: "float", nullable: true),
                    PctCalculation = table.Column<double>(type: "float", nullable: true),
                    PctAccuracy = table.Column<double>(type: "float", nullable: true),
                    CurrLocation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrBuildingArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrBuildingDesign = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrPhysicBuildingCondition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrPhysicLandArea = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrOwnership = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrOther = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrTotalAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrUnitValueM2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperShopApartments", x => x.ApprWorkPaperShopApartmentGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_ApprBuildingTemplates_ApprBuildingTemplateGuid",
                        column: x => x.ApprBuildingTemplateGuid,
                        principalTable: "ApprBuildingTemplates",
                        principalColumn: "ApprEnvironmentGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_ApprWorkPaperShopApartmentSummaries_ApprWorkPaperShopApartmentSummaryGuid",
                        column: x => x.ApprWorkPaperShopApartmentSummaryGuid,
                        principalTable: "ApprWorkPaperShopApartmentSummaries",
                        principalColumn: "ApprWorkPaperShopApartmentSummaryGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_Parameters_Allotment",
                        column: x => x.Allotment,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_Parameters_DataType",
                        column: x => x.DataType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_Parameters_LandCondition",
                        column: x => x.LandCondition,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_Parameters_LandForm",
                        column: x => x.LandForm,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_Parameters_Ownership",
                        column: x => x.Ownership,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperShopApartments_WilayahVillages_AddressReference",
                        column: x => x.AddressReference,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprWorkPaperVehicles",
                columns: table => new
                {
                    ApprWorkPaperVehicleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprWorkPaperVehicleSummaryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprVehicleTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataNumber = table.Column<int>(type: "int", nullable: true),
                    DataType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AddressReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyAccessories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomicileCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transmission = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Odometer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PctDataDate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctModelType = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctYear = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctCondition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctBodyAccessories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctColor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctDomicileCity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctTransmission = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PctOdometer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    PctDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionIndication = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAdj = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ResultAdj = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AbsoluteAdj = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SumIndicateValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrDataDate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrModelType = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrYear = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrCondition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrBodyAccessories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrColor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrDomicileCity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrTransmission = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrOdometer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrPrice = table.Column<double>(type: "float", nullable: true),
                    CurrTransactionIndication = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrResultAdj = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrSumIndicateValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_ApprWorkPaperVehicles", x => x.ApprWorkPaperVehicleGuid);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicles_ApprVehicleTemplate_ApprVehicleTemplateGuid",
                        column: x => x.ApprVehicleTemplateGuid,
                        principalTable: "ApprVehicleTemplate",
                        principalColumn: "ApprVehicleTemplateGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicles_ApprWorkPaperVehicleSummaries_ApprWorkPaperVehicleSummaryGuid",
                        column: x => x.ApprWorkPaperVehicleSummaryGuid,
                        principalTable: "ApprWorkPaperVehicleSummaries",
                        principalColumn: "ApprWorkPaperVehicleSummaryGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicles_Parameters_DataType",
                        column: x => x.DataType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicles_Parameters_Transmission",
                        column: x => x.Transmission,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprWorkPaperVehicles_WilayahVillages_AddressReference",
                        column: x => x.AddressReference,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "MLiquidationCondition",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ConditionId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Result = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_MLiquidationCondition", x => new { x.TypeId, x.ConditionId });
                    table.ForeignKey(
                        name: "FK_MLiquidationCondition_MLiquidation_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MLiquidation",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MLiquidationItems",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemWeight = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_MLiquidationItems", x => new { x.TypeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_MLiquidationItems_MLiquidation_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MLiquidation",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MLiquidationOption",
                columns: table => new
                {
                    OptionId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    ItemId = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    OptionDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OptionWeight = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_MLiquidationOption", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_MLiquidationOption_MLiquidationItems_TypeId_ItemId",
                        columns: x => new { x.TypeId, x.ItemId },
                        principalTable: "MLiquidationItems",
                        principalColumns: new[] { "TypeId", "ItemId" });
                });

            migrationBuilder.CreateTable(
                name: "ApprLiquidations",
                columns: table => new
                {
                    LiquidationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiquidationType = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    LiquidationItem = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    LiquidationOption = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    LiquidationScore = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ApprLiquidations", x => x.LiquidationGuid);
                    table.ForeignKey(
                        name: "FK_ApprLiquidations_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprLiquidations_MLiquidationItems_LiquidationType_LiquidationItem",
                        columns: x => new { x.LiquidationType, x.LiquidationItem },
                        principalTable: "MLiquidationItems",
                        principalColumns: new[] { "TypeId", "ItemId" });
                    table.ForeignKey(
                        name: "FK_ApprLiquidations_MLiquidationOption_LiquidationOption",
                        column: x => x.LiquidationOption,
                        principalTable: "MLiquidationOption",
                        principalColumn: "OptionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprLiquidations_AppraisalGuid",
                table: "ApprLiquidations",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLiquidations_LiquidationOption",
                table: "ApprLiquidations",
                column: "LiquidationOption");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLiquidations_LiquidationType_LiquidationItem",
                table: "ApprLiquidations",
                columns: new[] { "LiquidationType", "LiquidationItem" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprMachineTemplates_AppraisalGuid",
                table: "ApprMachineTemplates",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprMachineTemplates_WilayahVillageCode",
                table: "ApprMachineTemplates",
                column: "WilayahVillageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApprProductiveLandTemplate_AppraisalGuid",
                table: "ApprProductiveLandTemplate",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprProductiveLandTemplate_ZipCodeId",
                table: "ApprProductiveLandTemplate",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprVehicleTemplate_AppraisalGuid",
                table: "ApprVehicleTemplate",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_AddressReference",
                table: "ApprWorkPaperLandBuildings",
                column: "AddressReference");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_ApprBuildingTemplateGuid",
                table: "ApprWorkPaperLandBuildings",
                column: "ApprBuildingTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_ApprLandTemplateGuid",
                table: "ApprWorkPaperLandBuildings",
                column: "ApprLandTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_ApprProductiveLandTemplateGuid",
                table: "ApprWorkPaperLandBuildings",
                column: "ApprProductiveLandTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_ApprWorkPaperLandBuildingSummaryGuid_DataNumber",
                table: "ApprWorkPaperLandBuildings",
                columns: new[] { "ApprWorkPaperLandBuildingSummaryGuid", "DataNumber" },
                unique: true,
                filter: "[DataNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_BuildingCategory",
                table: "ApprWorkPaperLandBuildings",
                column: "BuildingCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_LandCondition",
                table: "ApprWorkPaperLandBuildings",
                column: "LandCondition");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_LandDocument",
                table: "ApprWorkPaperLandBuildings",
                column: "LandDocument");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_LandForm",
                table: "ApprWorkPaperLandBuildings",
                column: "LandForm");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_LandPosition",
                table: "ApprWorkPaperLandBuildings",
                column: "LandPosition");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_Offer",
                table: "ApprWorkPaperLandBuildings",
                column: "Offer");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildings_Topografi",
                table: "ApprWorkPaperLandBuildings",
                column: "Topografi");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperLandBuildingSummaries_AppraisalGuid",
                table: "ApprWorkPaperLandBuildingSummaries",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineCost_ApprMachineTemplateGuid",
                table: "ApprWorkPaperMachineCost",
                column: "ApprMachineTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineCost_ApprWorkPaperMachineMarketSummaryGuid",
                table: "ApprWorkPaperMachineCost",
                column: "ApprWorkPaperMachineMarketSummaryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarkets_AddressReference",
                table: "ApprWorkPaperMachineMarkets",
                column: "AddressReference");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarkets_ApprMachineTemplateGuid",
                table: "ApprWorkPaperMachineMarkets",
                column: "ApprMachineTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarkets_ApprWorkPaperMachineMarketSummaryGuid_DataNumber",
                table: "ApprWorkPaperMachineMarkets",
                columns: new[] { "ApprWorkPaperMachineMarketSummaryGuid", "DataNumber" },
                unique: true,
                filter: "[DataNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarkets_TransactionOffer",
                table: "ApprWorkPaperMachineMarkets",
                column: "TransactionOffer");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarketSummaries_AppraisalGuid",
                table: "ApprWorkPaperMachineMarketSummaries",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperMachineMarketSummaries_ApproachType",
                table: "ApprWorkPaperMachineMarketSummaries",
                column: "ApproachType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_AddressReference",
                table: "ApprWorkPaperShopApartments",
                column: "AddressReference");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_Allotment",
                table: "ApprWorkPaperShopApartments",
                column: "Allotment");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_ApprBuildingTemplateGuid",
                table: "ApprWorkPaperShopApartments",
                column: "ApprBuildingTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_ApprWorkPaperShopApartmentSummaryGuid_DataNumber",
                table: "ApprWorkPaperShopApartments",
                columns: new[] { "ApprWorkPaperShopApartmentSummaryGuid", "DataNumber" },
                unique: true,
                filter: "[DataNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_DataType",
                table: "ApprWorkPaperShopApartments",
                column: "DataType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_LandCondition",
                table: "ApprWorkPaperShopApartments",
                column: "LandCondition");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_LandForm",
                table: "ApprWorkPaperShopApartments",
                column: "LandForm");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartments_Ownership",
                table: "ApprWorkPaperShopApartments",
                column: "Ownership");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperShopApartmentSummaries_AppraisalGuid",
                table: "ApprWorkPaperShopApartmentSummaries",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicles_AddressReference",
                table: "ApprWorkPaperVehicles",
                column: "AddressReference");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicles_ApprVehicleTemplateGuid",
                table: "ApprWorkPaperVehicles",
                column: "ApprVehicleTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicles_ApprWorkPaperVehicleSummaryGuid_DataNumber",
                table: "ApprWorkPaperVehicles",
                columns: new[] { "ApprWorkPaperVehicleSummaryGuid", "DataNumber" },
                unique: true,
                filter: "[DataNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicles_DataType",
                table: "ApprWorkPaperVehicles",
                column: "DataType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicles_Transmission",
                table: "ApprWorkPaperVehicles",
                column: "Transmission");

            migrationBuilder.CreateIndex(
                name: "IX_ApprWorkPaperVehicleSummaries_AppraisalGuid",
                table: "ApprWorkPaperVehicleSummaries",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MLiquidationOption_TypeId_ItemId",
                table: "MLiquidationOption",
                columns: new[] { "TypeId", "ItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprLiquidations");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperLandBuildings");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperMachineCost");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperMachineMarkets");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperShopApartments");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperVehicles");

            migrationBuilder.DropTable(
                name: "MLiquidationCondition");

            migrationBuilder.DropTable(
                name: "MLiquidationOption");

            migrationBuilder.DropTable(
                name: "ApprProductiveLandTemplate");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperLandBuildingSummaries");

            migrationBuilder.DropTable(
                name: "ApprMachineTemplates");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperMachineMarketSummaries");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperShopApartmentSummaries");

            migrationBuilder.DropTable(
                name: "ApprVehicleTemplate");

            migrationBuilder.DropTable(
                name: "ApprWorkPaperVehicleSummaries");

            migrationBuilder.DropTable(
                name: "MLiquidationItems");

            migrationBuilder.DropTable(
                name: "MLiquidation");
        }
    }
}
