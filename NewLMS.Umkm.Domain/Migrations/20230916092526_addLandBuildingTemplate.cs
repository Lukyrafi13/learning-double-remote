using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addLandBuildingTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprBuildingTemplates",
                columns: table => new
                {
                    ApprEnvironmentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjectStatus = table.Column<bool>(type: "bit", nullable: true),
                    Inhabited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBuildingArea = table.Column<double>(type: "float", nullable: true),
                    Foundation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Wall = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Floor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoofTruss = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Roof = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Plafond = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InnerWall = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sills = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ElectricConn = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ElectricConnWatt = table.Column<double>(type: "float", nullable: true),
                    CleanWater = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Phone = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchitectShape = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YearBuilt = table.Column<int>(type: "int", nullable: true),
                    RenovatedYear = table.Column<int>(type: "int", nullable: true),
                    IsImb = table.Column<bool>(type: "bit", nullable: true),
                    ImbNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImbDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImbBasedArea = table.Column<double>(type: "float", nullable: true),
                    RealMeasuringArea = table.Column<double>(type: "float", nullable: true),
                    AreaDifference = table.Column<double>(type: "float", nullable: true),
                    YardToStreet = table.Column<double>(type: "float", nullable: true),
                    YardToFloor = table.Column<double>(type: "float", nullable: true),
                    BuildingCondition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YardCondition = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fence = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprBuildingTemplates", x => x.ApprEnvironmentGuid);
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_ArchitectShape",
                        column: x => x.ArchitectShape,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_BuildingCondition",
                        column: x => x.BuildingCondition,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_CleanWater",
                        column: x => x.CleanWater,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_ElectricConn",
                        column: x => x.ElectricConn,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Fence",
                        column: x => x.Fence,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Floor",
                        column: x => x.Floor,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Foundation",
                        column: x => x.Foundation,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_InnerWall",
                        column: x => x.InnerWall,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Phone",
                        column: x => x.Phone,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Plafond",
                        column: x => x.Plafond,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Roof",
                        column: x => x.Roof,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_RoofTruss",
                        column: x => x.RoofTruss,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Sills",
                        column: x => x.Sills,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_Wall",
                        column: x => x.Wall,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprBuildingTemplates_Parameters_YardCondition",
                        column: x => x.YardCondition,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                });

            migrationBuilder.CreateTable(
                name: "WilayahProvinces",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WilayahProvinces", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ApprBuildingFloors",
                columns: table => new
                {
                    BuildingFloorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprBuildingTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FloorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRoom = table.Column<int>(type: "int", nullable: true),
                    TotalArea = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ApprBuildingFloors", x => x.BuildingFloorGuid);
                    table.ForeignKey(
                        name: "FK_ApprBuildingFloors_ApprBuildingTemplates_ApprBuildingTemplateGuid",
                        column: x => x.ApprBuildingTemplateGuid,
                        principalTable: "ApprBuildingTemplates",
                        principalColumn: "ApprEnvironmentGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WilayahRegencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WilayahRegencies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_WilayahRegencies_WilayahProvinces_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "WilayahProvinces",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprBuildingFloorDetails",
                columns: table => new
                {
                    BuildingFloorDetailGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprBuildingFloorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FloorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomArea = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ApprBuildingFloorDetails", x => x.BuildingFloorDetailGuid);
                    table.ForeignKey(
                        name: "FK_ApprBuildingFloorDetails_ApprBuildingFloors_ApprBuildingFloorGuid",
                        column: x => x.ApprBuildingFloorGuid,
                        principalTable: "ApprBuildingFloors",
                        principalColumn: "BuildingFloorGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WilayahDistricts",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WilayahDistricts", x => x.Code);
                    table.ForeignKey(
                        name: "FK_WilayahDistricts_WilayahRegencies_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "WilayahRegencies",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "WilayahVillages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_WilayahVillages", x => x.Code);
                    table.ForeignKey(
                        name: "FK_WilayahVillages_WilayahDistricts_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "WilayahDistricts",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "ApprLandTemplates",
                columns: table => new
                {
                    ApprLandTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjectStatus = table.Column<bool>(type: "bit", nullable: true),
                    Inhabited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvGrowth = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvDensity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvLandPrice = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResidentialArea = table.Column<double>(type: "float", nullable: true),
                    EducationArea = table.Column<double>(type: "float", nullable: true),
                    IndustryArea = table.Column<double>(type: "float", nullable: true),
                    ShopArea = table.Column<double>(type: "float", nullable: true),
                    OfficeArea = table.Column<double>(type: "float", nullable: true),
                    EmptyArea = table.Column<double>(type: "float", nullable: true),
                    ChangeToFuture = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResidentialMajority = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvEaseOfAccess = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvShopping = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvSchool = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvTransport = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvRecreational = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvCrimeSecurity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvFireSafety = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvDisasterSafety = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Electric = table.Column<bool>(type: "bit", nullable: true),
                    ElectricPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CleanWater = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<bool>(type: "bit", nullable: true),
                    Gass = table.Column<bool>(type: "bit", nullable: true),
                    GarbageCollection = table.Column<bool>(type: "bit", nullable: true),
                    GarbageCollectionDistance = table.Column<double>(type: "float", nullable: true),
                    EntranceWay = table.Column<double>(type: "float", nullable: true),
                    EntranceWayType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnvironmentWay = table.Column<double>(type: "float", nullable: true),
                    EnvironmentWayType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Drainase = table.Column<double>(type: "float", nullable: true),
                    DrainaseType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sidewalk = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StreetLight = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NorthernBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SouthernBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WesternBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EasternBoundary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topografi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Greening = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Arrangement = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WaterDisposal = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FloodRisk = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FireRisk = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandHeight = table.Column<double>(type: "float", nullable: true),
                    Skewer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPublicBurial = table.Column<bool>(type: "bit", nullable: true),
                    PublicBurial = table.Column<double>(type: "float", nullable: true),
                    HighVoltage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandWidth = table.Column<double>(type: "float", nullable: true),
                    LandLength = table.Column<double>(type: "float", nullable: true),
                    CertificateType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CertficateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeasureLetterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureLetterDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandShape = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LandAreaValue = table.Column<double>(type: "float", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValidUntil = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprLandTemplates", x => x.ApprLandTemplateGuid);
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_Arrangement",
                        column: x => x.Arrangement,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_CertificateType",
                        column: x => x.CertificateType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_ChangeToFuture",
                        column: x => x.ChangeToFuture,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_DrainaseType",
                        column: x => x.DrainaseType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EntranceWayType",
                        column: x => x.EntranceWayType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvCrimeSecurity",
                        column: x => x.EnvCrimeSecurity,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvDensity",
                        column: x => x.EnvDensity,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvDisasterSafety",
                        column: x => x.EnvDisasterSafety,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvEaseOfAccess",
                        column: x => x.EnvEaseOfAccess,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvFireSafety",
                        column: x => x.EnvFireSafety,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvGrowth",
                        column: x => x.EnvGrowth,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvironmentWayType",
                        column: x => x.EnvironmentWayType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvLandPrice",
                        column: x => x.EnvLandPrice,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvLocation",
                        column: x => x.EnvLocation,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvRecreational",
                        column: x => x.EnvRecreational,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvSchool",
                        column: x => x.EnvSchool,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvShopping",
                        column: x => x.EnvShopping,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_EnvTransport",
                        column: x => x.EnvTransport,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_FireRisk",
                        column: x => x.FireRisk,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_FloodRisk",
                        column: x => x.FloodRisk,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_Greening",
                        column: x => x.Greening,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_HighVoltage",
                        column: x => x.HighVoltage,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_LandShape",
                        column: x => x.LandShape,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_LandType",
                        column: x => x.LandType,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_ResidentialMajority",
                        column: x => x.ResidentialMajority,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_Sidewalk",
                        column: x => x.Sidewalk,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_Skewer",
                        column: x => x.Skewer,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_StreetLight",
                        column: x => x.StreetLight,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_Topografi",
                        column: x => x.Topografi,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_Parameters_WaterDisposal",
                        column: x => x.WaterDisposal,
                        principalTable: "Parameters",
                        principalColumn: "ParameterGuid");
                    table.ForeignKey(
                        name: "FK_ApprLandTemplates_WilayahVillages_AddressReference",
                        column: x => x.AddressReference,
                        principalTable: "WilayahVillages",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingFloorDetails_ApprBuildingFloorGuid",
                table: "ApprBuildingFloorDetails",
                column: "ApprBuildingFloorGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingFloors_ApprBuildingTemplateGuid",
                table: "ApprBuildingFloors",
                column: "ApprBuildingTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_AppraisalGuid",
                table: "ApprBuildingTemplates",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_ArchitectShape",
                table: "ApprBuildingTemplates",
                column: "ArchitectShape");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_BuildingCondition",
                table: "ApprBuildingTemplates",
                column: "BuildingCondition");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_CleanWater",
                table: "ApprBuildingTemplates",
                column: "CleanWater");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_ElectricConn",
                table: "ApprBuildingTemplates",
                column: "ElectricConn");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Fence",
                table: "ApprBuildingTemplates",
                column: "Fence");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Floor",
                table: "ApprBuildingTemplates",
                column: "Floor");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Foundation",
                table: "ApprBuildingTemplates",
                column: "Foundation");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_InnerWall",
                table: "ApprBuildingTemplates",
                column: "InnerWall");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Phone",
                table: "ApprBuildingTemplates",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Plafond",
                table: "ApprBuildingTemplates",
                column: "Plafond");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Roof",
                table: "ApprBuildingTemplates",
                column: "Roof");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_RoofTruss",
                table: "ApprBuildingTemplates",
                column: "RoofTruss");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Sills",
                table: "ApprBuildingTemplates",
                column: "Sills");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_Wall",
                table: "ApprBuildingTemplates",
                column: "Wall");

            migrationBuilder.CreateIndex(
                name: "IX_ApprBuildingTemplates_YardCondition",
                table: "ApprBuildingTemplates",
                column: "YardCondition");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_AddressReference",
                table: "ApprLandTemplates",
                column: "AddressReference");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_AppraisalGuid",
                table: "ApprLandTemplates",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_Arrangement",
                table: "ApprLandTemplates",
                column: "Arrangement");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_CertificateType",
                table: "ApprLandTemplates",
                column: "CertificateType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_ChangeToFuture",
                table: "ApprLandTemplates",
                column: "ChangeToFuture");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_DrainaseType",
                table: "ApprLandTemplates",
                column: "DrainaseType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EntranceWayType",
                table: "ApprLandTemplates",
                column: "EntranceWayType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvCrimeSecurity",
                table: "ApprLandTemplates",
                column: "EnvCrimeSecurity");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvDensity",
                table: "ApprLandTemplates",
                column: "EnvDensity");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvDisasterSafety",
                table: "ApprLandTemplates",
                column: "EnvDisasterSafety");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvEaseOfAccess",
                table: "ApprLandTemplates",
                column: "EnvEaseOfAccess");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvFireSafety",
                table: "ApprLandTemplates",
                column: "EnvFireSafety");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvGrowth",
                table: "ApprLandTemplates",
                column: "EnvGrowth");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvironmentWayType",
                table: "ApprLandTemplates",
                column: "EnvironmentWayType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvLandPrice",
                table: "ApprLandTemplates",
                column: "EnvLandPrice");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvLocation",
                table: "ApprLandTemplates",
                column: "EnvLocation");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvRecreational",
                table: "ApprLandTemplates",
                column: "EnvRecreational");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvSchool",
                table: "ApprLandTemplates",
                column: "EnvSchool");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvShopping",
                table: "ApprLandTemplates",
                column: "EnvShopping");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_EnvTransport",
                table: "ApprLandTemplates",
                column: "EnvTransport");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_FireRisk",
                table: "ApprLandTemplates",
                column: "FireRisk");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_FloodRisk",
                table: "ApprLandTemplates",
                column: "FloodRisk");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_Greening",
                table: "ApprLandTemplates",
                column: "Greening");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_HighVoltage",
                table: "ApprLandTemplates",
                column: "HighVoltage");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_LandShape",
                table: "ApprLandTemplates",
                column: "LandShape");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_LandType",
                table: "ApprLandTemplates",
                column: "LandType");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_ResidentialMajority",
                table: "ApprLandTemplates",
                column: "ResidentialMajority");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_Sidewalk",
                table: "ApprLandTemplates",
                column: "Sidewalk");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_Skewer",
                table: "ApprLandTemplates",
                column: "Skewer");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_StreetLight",
                table: "ApprLandTemplates",
                column: "StreetLight");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_Topografi",
                table: "ApprLandTemplates",
                column: "Topografi");

            migrationBuilder.CreateIndex(
                name: "IX_ApprLandTemplates_WaterDisposal",
                table: "ApprLandTemplates",
                column: "WaterDisposal");

            migrationBuilder.CreateIndex(
                name: "IX_WilayahDistricts_ParentCode",
                table: "WilayahDistricts",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_WilayahRegencies_ParentCode",
                table: "WilayahRegencies",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_WilayahVillages_ParentCode",
                table: "WilayahVillages",
                column: "ParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprBuildingFloorDetails");

            migrationBuilder.DropTable(
                name: "ApprLandTemplates");

            migrationBuilder.DropTable(
                name: "ApprBuildingFloors");

            migrationBuilder.DropTable(
                name: "WilayahVillages");

            migrationBuilder.DropTable(
                name: "ApprBuildingTemplates");

            migrationBuilder.DropTable(
                name: "WilayahDistricts");

            migrationBuilder.DropTable(
                name: "WilayahRegencies");

            migrationBuilder.DropTable(
                name: "WilayahProvinces");
        }
    }
}
