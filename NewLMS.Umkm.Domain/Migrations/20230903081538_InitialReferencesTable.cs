using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class InitialReferencesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfApplicationTypes",
                columns: table => new
                {
                    ApplicationTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfApplicationTypes", x => x.ApplicationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessFieldKURs",
                columns: table => new
                {
                    BusinessFieldKURCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessFieldKURDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessFieldKURs", x => x.BusinessFieldKURCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessLocations",
                columns: table => new
                {
                    BusinessLocationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessLocationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessLocations", x => x.BusinessLocationCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessOwnerships",
                columns: table => new
                {
                    BusinessOwnershipCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessOwnershipDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessOwnerships", x => x.BusinessOwnershipCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessPlaceLocations",
                columns: table => new
                {
                    RfBusinessPlaceLocationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RfBusinessPlaceLocationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessPlaceLocations", x => x.RfBusinessPlaceLocationCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessPlaceTypes",
                columns: table => new
                {
                    BusinessPlaceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessPlaceTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessPlaceTypes", x => x.BusinessPlaceTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessTypes",
                columns: table => new
                {
                    BusinessTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessTypes", x => x.BusinessTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfCollateralBCs",
                columns: table => new
                {
                    CollateralCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollateralDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<bool>(type: "bit", nullable: false),
                    Building = table.Column<bool>(type: "bit", nullable: false),
                    BeaGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColllatealCatCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCollateralBCs", x => x.CollateralCode);
                });

            migrationBuilder.CreateTable(
                name: "RfCreditNatures",
                columns: table => new
                {
                    CreditNatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditNatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCreditNatures", x => x.CreditNatureCode);
                });

            migrationBuilder.CreateTable(
                name: "RfDecisionLeterTypes",
                columns: table => new
                {
                    DecisionLeterTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecisionLeterTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfDecisionLeterTypes", x => x.DecisionLeterTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfDocuments",
                columns: table => new
                {
                    DocumentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Due = table.Column<int>(type: "int", nullable: true),
                    ManDocNo = table.Column<bool>(type: "bit", nullable: true),
                    ISTBO = table.Column<bool>(type: "bit", nullable: true),
                    Mandatory = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfDocuments", x => x.DocumentCode);
                });

            migrationBuilder.CreateTable(
                name: "RfEducations",
                columns: table => new
                {
                    EducationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationCodeSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationDescSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfEducations", x => x.EducationCode);
                });

            migrationBuilder.CreateTable(
                name: "RfGenders",
                columns: table => new
                {
                    GenderCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderCodeSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderDescSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfGenders", x => x.GenderCode);
                });

            migrationBuilder.CreateTable(
                name: "RfLinkAges",
                columns: table => new
                {
                    LinkAgeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkAgeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfLinkAges", x => x.LinkAgeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfLinkAgeTypes",
                columns: table => new
                {
                    LinkAgeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkAgeTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfLinkAgeTypes", x => x.LinkAgeTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfLoanPurposes",
                columns: table => new
                {
                    LoanPurposeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanPurposeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxProd = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RfLoanPurposes", x => x.LoanPurposeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfMaritals",
                columns: table => new
                {
                    MaritalCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaritalDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithSpouse = table.Column<bool>(type: "bit", nullable: true),
                    MaritalCodeSKIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalDescSKIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfMaritals", x => x.MaritalCode);
                });

            migrationBuilder.CreateTable(
                name: "RfOwnerCategories",
                columns: table => new
                {
                    OwnerCategoryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerCategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfOwnerCategories", x => x.OwnerCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "RfParameters",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfParameters", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "RfPlacementCountries",
                columns: table => new
                {
                    PlacementCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlacementCountryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kurs = table.Column<double>(type: "float", nullable: true),
                    ShowKUR = table.Column<bool>(type: "bit", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfPlacementCountries", x => x.PlacementCountryCode);
                });

            migrationBuilder.CreateTable(
                name: "RfProducts",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefTenor = table.Column<int>(type: "int", nullable: false),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    DefIntType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefInterest = table.Column<double>(type: "float", nullable: false),
                    MinInterest = table.Column<double>(type: "float", nullable: false),
                    MaxInterest = table.Column<double>(type: "float", nullable: false),
                    DefProvPCTFee = table.Column<double>(type: "float", nullable: false),
                    DefAdminFee = table.Column<double>(type: "float", nullable: false),
                    MaxLimit = table.Column<double>(type: "float", nullable: false),
                    LimitAppR = table.Column<double>(type: "float", nullable: false),
                    MinLimit = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_RfProducts", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "RfRelationCols",
                columns: table => new
                {
                    RelationColCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RelationColDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spouse = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfRelationCols", x => x.RelationColCode);
                });

            migrationBuilder.CreateTable(
                name: "RfTargetStatuses",
                columns: table => new
                {
                    TargetStatusCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetStatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfTargetStatuses", x => x.TargetStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "RfTransportationTypes",
                columns: table => new
                {
                    TransportationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransportationTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfTransportationTypes", x => x.TransportationTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfVehCountries",
                columns: table => new
                {
                    VehCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehCountryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfVehCountries", x => x.VehCountryCode);
                });

            migrationBuilder.CreateTable(
                name: "RfVehModels",
                columns: table => new
                {
                    VehModelCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehModelDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfVehModels", x => x.VehModelCode);
                });

            migrationBuilder.CreateTable(
                name: "RfVehTypes",
                columns: table => new
                {
                    VehCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfVehTypes", x => x.VehCode);
                });

            migrationBuilder.CreateTable(
                name: "RfBusinessPlaceOwnerships",
                columns: table => new
                {
                    BusinessPlaceOwnCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessPlaceOwnDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPlaceLocationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfBusinessPlaceOwnerships", x => x.BusinessPlaceOwnCode);
                    table.ForeignKey(
                        name: "FK_RfBusinessPlaceOwnerships_RfBusinessPlaceLocations_BusinessPlaceLocationCode",
                        column: x => x.BusinessPlaceLocationCode,
                        principalTable: "RfBusinessPlaceLocations",
                        principalColumn: "RfBusinessPlaceLocationCode");
                });

            migrationBuilder.CreateTable(
                name: "RfDecisionLetters",
                columns: table => new
                {
                    DecisionLeterCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecisionLeterDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionLeterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterMatter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DecisionLeterClausal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Limit = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_RfDecisionLetters", x => x.DecisionLeterCode);
                    table.ForeignKey(
                        name: "FK_RfDecisionLetters_RfDecisionLeterTypes_DecisionLeterTypeCode",
                        column: x => x.DecisionLeterTypeCode,
                        principalTable: "RfDecisionLeterTypes",
                        principalColumn: "DecisionLeterTypeCode");
                });

            migrationBuilder.CreateTable(
                name: "RfDocumentCollaterals",
                columns: table => new
                {
                    DocumentCollateralCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollateralCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfDocumentCollaterals", x => x.DocumentCollateralCode);
                    table.ForeignKey(
                        name: "FK_RfDocumentCollaterals_RfCollateralBCs_CollateralCode",
                        column: x => x.CollateralCode,
                        principalTable: "RfCollateralBCs",
                        principalColumn: "CollateralCode");
                    table.ForeignKey(
                        name: "FK_RfDocumentCollaterals_RfDocuments_DocumentCode",
                        column: x => x.DocumentCode,
                        principalTable: "RfDocuments",
                        principalColumn: "DocumentCode");
                });

            migrationBuilder.CreateTable(
                name: "RfParameterDetails",
                columns: table => new
                {
                    ParameterDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfParameterDetails", x => x.ParameterDetailId);
                    table.ForeignKey(
                        name: "FK_RfParameterDetails_RfParameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "RfParameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfJobs",
                columns: table => new
                {
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobSCRType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCodeSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sensitive = table.Column<bool>(type: "bit", nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfJobs", x => x.JobCode);
                    table.ForeignKey(
                        name: "FK_RfJobs_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RfMappingCollaterals",
                columns: table => new
                {
                    MappingCollateralId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollateralCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfMappingCollaterals", x => x.MappingCollateralId);
                    table.ForeignKey(
                        name: "FK_RfMappingCollaterals_RfCollateralBCs_CollateralCode",
                        column: x => x.CollateralCode,
                        principalTable: "RfCollateralBCs",
                        principalColumn: "CollateralCode");
                    table.ForeignKey(
                        name: "FK_RfMappingCollaterals_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RfSubProducts",
                columns: table => new
                {
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MandNPWP = table.Column<bool>(type: "bit", nullable: true),
                    LoanPurposeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SIKPSkema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIKPParentSkema = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSubProducts", x => x.SubProductId);
                    table.ForeignKey(
                        name: "FK_RfSubProducts_RfLoanPurposes_LoanPurposeCode",
                        column: x => x.LoanPurposeCode,
                        principalTable: "RfLoanPurposes",
                        principalColumn: "LoanPurposeCode");
                    table.ForeignKey(
                        name: "FK_RfSubProducts_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RfTenors",
                columns: table => new
                {
                    TenorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenor = table.Column<int>(type: "int", nullable: true),
                    Due = table.Column<int>(type: "int", nullable: true),
                    ManDocNo = table.Column<bool>(type: "bit", nullable: true),
                    ISTBO = table.Column<bool>(type: "bit", nullable: true),
                    Mandatory = table.Column<bool>(type: "bit", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfTenors", x => x.TenorCode);
                    table.ForeignKey(
                        name: "FK_RfTenors_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RfVehClasss",
                columns: table => new
                {
                    VehClassCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehClassDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehModelCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfVehClasss", x => x.VehClassCode);
                    table.ForeignKey(
                        name: "FK_RfVehClasss_RfVehModels_VehModelCode",
                        column: x => x.VehModelCode,
                        principalTable: "RfVehModels",
                        principalColumn: "VehModelCode");
                    table.ForeignKey(
                        name: "FK_RfVehClasss_RfVehTypes_VehCode",
                        column: x => x.VehCode,
                        principalTable: "RfVehTypes",
                        principalColumn: "VehCode");
                });

            migrationBuilder.CreateTable(
                name: "RfVehMakers",
                columns: table => new
                {
                    VehMakerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehmakerDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfVehMakers", x => x.VehMakerCode);
                    table.ForeignKey(
                        name: "FK_RfVehMakers_RfVehCountries_VehCountryCode",
                        column: x => x.VehCountryCode,
                        principalTable: "RfVehCountries",
                        principalColumn: "VehCountryCode");
                    table.ForeignKey(
                        name: "FK_RfVehMakers_RfVehTypes_VehCode",
                        column: x => x.VehCode,
                        principalTable: "RfVehTypes",
                        principalColumn: "VehCode");
                });

            migrationBuilder.CreateTable(
                name: "RfScPositions",
                columns: table => new
                {
                    ScPositionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScPositionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionLeterCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfScPositions", x => x.ScPositionCode);
                    table.ForeignKey(
                        name: "FK_RfScPositions_RfDecisionLetters_DecisionLeterCode",
                        column: x => x.DecisionLeterCode,
                        principalTable: "RfDecisionLetters",
                        principalColumn: "DecisionLeterCode");
                });

            migrationBuilder.CreateTable(
                name: "RfMappingTenors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenorCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SiklusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfMappingTenors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfTenors_TenorCode",
                        column: x => x.TenorCode,
                        principalTable: "RfTenors",
                        principalColumn: "TenorCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfBusinessPlaceOwnerships_BusinessPlaceLocationCode",
                table: "RfBusinessPlaceOwnerships",
                column: "BusinessPlaceLocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfDecisionLetters_DecisionLeterTypeCode",
                table: "RfDecisionLetters",
                column: "DecisionLeterTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfDocumentCollaterals_CollateralCode",
                table: "RfDocumentCollaterals",
                column: "CollateralCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfDocumentCollaterals_DocumentCode",
                table: "RfDocumentCollaterals",
                column: "DocumentCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfJobs_ProductId",
                table: "RfJobs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingCollaterals_CollateralCode",
                table: "RfMappingCollaterals",
                column: "CollateralCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingCollaterals_ProductId",
                table: "RfMappingCollaterals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_ProductId",
                table: "RfMappingTenors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_TenorCode",
                table: "RfMappingTenors",
                column: "TenorCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfParameterDetails_ParameterId",
                table: "RfParameterDetails",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_RfScPositions_DecisionLeterCode",
                table: "RfScPositions",
                column: "DecisionLeterCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProducts_LoanPurposeCode",
                table: "RfSubProducts",
                column: "LoanPurposeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProducts_ProductId",
                table: "RfSubProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfTenors_ProductId",
                table: "RfTenors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehClasss_VehCode",
                table: "RfVehClasss",
                column: "VehCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehClasss_VehModelCode",
                table: "RfVehClasss",
                column: "VehModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_VehCode",
                table: "RfVehMakers",
                column: "VehCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_VehCountryCode",
                table: "RfVehMakers",
                column: "VehCountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfApplicationTypes");

            migrationBuilder.DropTable(
                name: "RfBusinessFieldKURs");

            migrationBuilder.DropTable(
                name: "RfBusinessLocations");

            migrationBuilder.DropTable(
                name: "RfBusinessOwnerships");

            migrationBuilder.DropTable(
                name: "RfBusinessPlaceOwnerships");

            migrationBuilder.DropTable(
                name: "RfBusinessPlaceTypes");

            migrationBuilder.DropTable(
                name: "RfBusinessTypes");

            migrationBuilder.DropTable(
                name: "RfCreditNatures");

            migrationBuilder.DropTable(
                name: "RfDocumentCollaterals");

            migrationBuilder.DropTable(
                name: "RfEducations");

            migrationBuilder.DropTable(
                name: "RfGenders");

            migrationBuilder.DropTable(
                name: "RfJobs");

            migrationBuilder.DropTable(
                name: "RfLinkAges");

            migrationBuilder.DropTable(
                name: "RfLinkAgeTypes");

            migrationBuilder.DropTable(
                name: "RfMappingCollaterals");

            migrationBuilder.DropTable(
                name: "RfMappingTenors");

            migrationBuilder.DropTable(
                name: "RfMaritals");

            migrationBuilder.DropTable(
                name: "RfOwnerCategories");

            migrationBuilder.DropTable(
                name: "RfParameterDetails");

            migrationBuilder.DropTable(
                name: "RfPlacementCountries");

            migrationBuilder.DropTable(
                name: "RfRelationCols");

            migrationBuilder.DropTable(
                name: "RfScPositions");

            migrationBuilder.DropTable(
                name: "RfSubProducts");

            migrationBuilder.DropTable(
                name: "RfTargetStatuses");

            migrationBuilder.DropTable(
                name: "RfTransportationTypes");

            migrationBuilder.DropTable(
                name: "RfVehClasss");

            migrationBuilder.DropTable(
                name: "RfVehMakers");

            migrationBuilder.DropTable(
                name: "RfBusinessPlaceLocations");

            migrationBuilder.DropTable(
                name: "RfDocuments");

            migrationBuilder.DropTable(
                name: "RfCollateralBCs");

            migrationBuilder.DropTable(
                name: "RfTenors");

            migrationBuilder.DropTable(
                name: "RfParameters");

            migrationBuilder.DropTable(
                name: "RfDecisionLetters");

            migrationBuilder.DropTable(
                name: "RfLoanPurposes");

            migrationBuilder.DropTable(
                name: "RfVehModels");

            migrationBuilder.DropTable(
                name: "RfVehCountries");

            migrationBuilder.DropTable(
                name: "RfVehTypes");

            migrationBuilder.DropTable(
                name: "RfProducts");

            migrationBuilder.DropTable(
                name: "RfDecisionLeterTypes");
        }
    }
}
