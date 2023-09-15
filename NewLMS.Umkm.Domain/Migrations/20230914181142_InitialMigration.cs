using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FileUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginAudits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoteIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Callsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NLog", x => x.Id);
                });

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
                name: "RfConditions",
                columns: table => new
                {
                    ConditionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConditionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfConditions", x => x.ConditionCode);
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
                name: "RfCreditTypes",
                columns: table => new
                {
                    CreditTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditAgreement = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfCreditTypes", x => x.CreditTypeCode);
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
                name: "RfDecisionMakers",
                columns: table => new
                {
                    DecisionMakerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecisionMakerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfDecisionMakers", x => x.DecisionMakerCode);
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
                name: "RfInstallmentTypes",
                columns: table => new
                {
                    InstallmentTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstallmentTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfInstallmentTypes", x => x.InstallmentTypeCode);
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
                name: "RfSandiBIGroups",
                columns: table => new
                {
                    BIGroup = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSandiBIGroups", x => x.BIGroup);
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
                name: "RfStages",
                columns: table => new
                {
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupStage = table.Column<int>(type: "int", nullable: false),
                    GroupStageDigiloan = table.Column<int>(type: "int", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowInTracking = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfStages", x => x.StageId);
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
                name: "ThridParties",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ClientSecret = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UrlCallback = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
                    table.PrimaryKey("PK_ThridParties", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeCabang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaCabang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeInduk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaInduk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeKanwil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaKanwil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePenempatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosisiPenempatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFungsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FungsiTambahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitDebet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitKredit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UimId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTokenExpiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUseUim = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "RfSandiBIs",
                columns: table => new
                {
                    RfSandiBIId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BIGroup = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BIType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BICode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LBU2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSandiBIs", x => x.RfSandiBIId);
                    table.ForeignKey(
                        name: "FK_RfSandiBIs_RfSandiBIGroups_BIGroup",
                        column: x => x.BIGroup,
                        principalTable: "RfSandiBIGroups",
                        principalColumn: "BIGroup",
                        onDelete: ReferentialAction.Cascade);
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
                name: "RfVehMakers",
                columns: table => new
                {
                    VehMakerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehmakerDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CollateralCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_RfVehMakers_RfCollateralBCs_CollateralCode",
                        column: x => x.CollateralCode,
                        principalTable: "RfCollateralBCs",
                        principalColumn: "CollateralCode");
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
                name: "DebtorCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogSendCallbackThirdParty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThridPartyName = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_LogSendCallbackThirdParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogSendCallbackThirdParty_ThridParties_ThridPartyName",
                        column: x => x.ThridPartyName,
                        principalTable: "ThridParties",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actions_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actions_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailSMTPSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnableSSL = table.Column<bool>(type: "bit", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_EmailSMTPSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailSMTPSettings_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailSMTPSettings_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailSMTPSettings_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pages_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pages_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFungsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAllowedIPs",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAllowedIPs", x => new { x.UserId, x.IPAddress });
                    table.ForeignKey(
                        name: "FK_UserAllowedIPs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    UserDeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(8,6)", precision: 8, scale: 6, nullable: false),
                    Langitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
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
                    table.PrimaryKey("PK_UserDevices", x => x.UserDeviceId);
                    table.ForeignKey(
                        name: "FK_UserDevices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "RfCompanyTypes",
                columns: table => new
                {
                    CompanyTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyGroupId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RfCompanyTypes", x => x.CompanyTypeId);
                    table.ForeignKey(
                        name: "FK_RfCompanyTypes_RfParameterDetails_CompanyGroupId",
                        column: x => x.CompanyGroupId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    ResidenceStatusId = table.Column<int>(type: "int", nullable: true),
                    ResidenceLiveTime = table.Column<int>(type: "int", nullable: true),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MarriageCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriageCertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarriageCertificateIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Debtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debtors_RfEducations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfGenders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfJobs_JobCode",
                        column: x => x.JobCode,
                        principalTable: "RfJobs",
                        principalColumn: "JobCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfMaritals_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfParameterDetails_ResidenceStatusId",
                        column: x => x.ResidenceStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Debtors_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RfMappingTenors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenorCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SiklusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoanPurposeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParamApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_RfMappingTenors_RfLoanPurposes_LoanPurposeCode",
                        column: x => x.LoanPurposeCode,
                        principalTable: "RfLoanPurposes",
                        principalColumn: "LoanPurposeCode");
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfParameterDetails_ParamApplicationTypeId",
                        column: x => x.ParamApplicationTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                    table.ForeignKey(
                        name: "FK_RfMappingTenors_RfTenors_TenorCode",
                        column: x => x.TenorCode,
                        principalTable: "RfTenors",
                        principalColumn: "TenorCode");
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
                name: "RfVehClasss",
                columns: table => new
                {
                    VehClassCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehClassDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehModelCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehMakerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_RfVehClasss_RfVehMakers_VehMakerCode",
                        column: x => x.VehMakerCode,
                        principalTable: "RfVehMakers",
                        principalColumn: "VehMakerCode");
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
                name: "DebtorCompanyLegals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentDeedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDeedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestDeedChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIUPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIUPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDPDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SKNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SKDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SKDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_DebtorCompanyLegals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorCompanyLegals_DebtorCompanies_Id",
                        column: x => x.Id,
                        principalTable: "DebtorCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageActions_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageActions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageActions_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageActions_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtorCouples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAddressSameAsDebtor = table.Column<bool>(type: "bit", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorCouples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorCouples_Debtors_Id",
                        column: x => x.Id,
                        principalTable: "Debtors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtorCouples_RfJobs_JobCode",
                        column: x => x.JobCode,
                        principalTable: "RfJobs",
                        principalColumn: "JobCode");
                    table.ForeignKey(
                        name: "FK_DebtorCouples_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
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
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    SameAsIdentity = table.Column<bool>(type: "bit", nullable: true),
                    PlaceAddress = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PlaceProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceNeighborhoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlaceZipCodeId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    SectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    InstituteCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetPlafond = table.Column<long>(type: "bigint", nullable: true),
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
                    CompanyTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCardAddress = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Prospects_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Prospects_RfCompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "RfCompanyTypes",
                        principalColumn: "CompanyTypeId");
                    table.ForeignKey(
                        name: "FK_Prospects_RfGenders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_Prospects_RfInstituteCode_InstituteCode",
                        column: x => x.InstituteCode,
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

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DebtorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OwnerCategoryId = table.Column<int>(type: "int", nullable: false),
                    DecisionMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsBusinessCycle = table.Column<bool>(type: "bit", nullable: true),
                    BusinessCycleId = table.Column<int>(type: "int", nullable: true),
                    BusinessCycleMonth = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    BookingBranchId = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    DuplicationsVerified = table.Column<bool>(type: "bit", nullable: false),
                    RfSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_DebtorCompanies_DebtorCompanyId",
                        column: x => x.DebtorCompanyId,
                        principalTable: "DebtorCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfBranches_BookingBranchId",
                        column: x => x.BookingBranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfParameterDetails_BusinessCycleId",
                        column: x => x.BusinessCycleId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfParameterDetails_OwnerCategoryId",
                        column: x => x.OwnerCategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfSectorLBU3_RfSectorLBU3Code",
                        column: x => x.RfSectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_DecisionMakerId",
                        column: x => x.DecisionMakerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtorEmergencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorEmergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorEmergencies_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtorEmergencies_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: true),
                    TBODate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TBODesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_RfDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "RfDocuments",
                        principalColumn: "DocumentCode");
                    table.ForeignKey(
                        name: "FK_Documents_RfParameterDetails_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Documents_RfParameterDetails_DocumentType",
                        column: x => x.DocumentType,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCollaterals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollateralBCId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentPublisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    LanArea = table.Column<double>(type: "float", nullable: true),
                    BuildingPermit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NJOPPBBNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingArea = table.Column<double>(type: "float", nullable: true),
                    VehMakerCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehClassCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YearProduction = table.Column<int>(type: "int", nullable: true),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehModelCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameMarketLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementLetterNumberImageSituation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementLetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeigborhoodDocumentCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictDocumentCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDocumentCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceDocumentCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCollateralHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangkingHT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateMeasurementLetterNumber = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EastBoundaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WestBoundaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SouthBoundaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NorthBoundaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_LoanApplicationCollaterals_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfCollateralBCs_CollateralBCId",
                        column: x => x.CollateralBCId,
                        principalTable: "RfCollateralBCs",
                        principalColumn: "CollateralCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfDocuments_DocumentCode",
                        column: x => x.DocumentCode,
                        principalTable: "RfDocuments",
                        principalColumn: "DocumentCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfTransportationTypes_TransportationTypeCode",
                        column: x => x.TransportationTypeCode,
                        principalTable: "RfTransportationTypes",
                        principalColumn: "TransportationTypeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfVehClasss_VehClassCode",
                        column: x => x.VehClassCode,
                        principalTable: "RfVehClasss",
                        principalColumn: "VehClassCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfVehMakers_VehMakerCode",
                        column: x => x.VehMakerCode,
                        principalTable: "RfVehMakers",
                        principalColumn: "VehMakerCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfVehModels_VehModelCode",
                        column: x => x.VehModelCode,
                        principalTable: "RfVehModels",
                        principalColumn: "VehModelCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditScorings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoResidentialReputationId = table.Column<int>(type: "int", nullable: false),
                    ScoBankRelationId = table.Column<int>(type: "int", nullable: false),
                    ScoBJBCreditHistoryId = table.Column<int>(type: "int", nullable: false),
                    ScoTransacMethodId = table.Column<int>(type: "int", nullable: false),
                    ScoAverageAccBalanceId = table.Column<int>(type: "int", nullable: false),
                    ScoNeedLevelId = table.Column<int>(type: "int", nullable: false),
                    ScoFinanceManagerId = table.Column<int>(type: "int", nullable: false),
                    ScoBusinesLocationId = table.Column<int>(type: "int", nullable: false),
                    ScoOtherPartyDebtId = table.Column<int>(type: "int", nullable: false),
                    ScoCollateralId = table.Column<int>(type: "int", nullable: false),
                    ScoMonthlyMutationId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCreditScorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoAverageAccBalanceId",
                        column: x => x.ScoAverageAccBalanceId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBankRelationId",
                        column: x => x.ScoBankRelationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBJBCreditHistoryId",
                        column: x => x.ScoBJBCreditHistoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBusinesLocationId",
                        column: x => x.ScoBusinesLocationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoCollateralId",
                        column: x => x.ScoCollateralId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoFinanceManagerId",
                        column: x => x.ScoFinanceManagerId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoMonthlyMutationId",
                        column: x => x.ScoMonthlyMutationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoNeedLevelId",
                        column: x => x.ScoNeedLevelId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoOtherPartyDebtId",
                        column: x => x.ScoOtherPartyDebtId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoResidentialReputationId",
                        column: x => x.ScoResidentialReputationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoTransacMethodId",
                        column: x => x.ScoTransacMethodId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: false),
                    PlacementCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoanPurposeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmittedPlafond = table.Column<long>(type: "bigint", nullable: false),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenorCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FacilityPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    NatureOfCreditId = table.Column<int>(type: "int", nullable: false),
                    PrincipalInstallment = table.Column<long>(type: "bigint", nullable: false),
                    InterestInstallment = table.Column<long>(type: "bigint", nullable: false),
                    SectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfLoanPurposes_LoanPurposeId",
                        column: x => x.LoanPurposeId,
                        principalTable: "RfLoanPurposes",
                        principalColumn: "LoanPurposeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfParameterDetails_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfParameterDetails_NatureOfCreditId",
                        column: x => x.NatureOfCreditId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfPlacementCountries_PlacementCountryCode",
                        column: x => x.PlacementCountryCode,
                        principalTable: "RfPlacementCountries",
                        principalColumn: "PlacementCountryCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfSectorLBU3_SectorLBU3Code",
                        column: x => x.SectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfTenors_TenorCode",
                        column: x => x.TenorCode,
                        principalTable: "RfTenors",
                        principalColumn: "TenorCode");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationKeyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LifetimeIdentity = table.Column<bool>(type: "bit", nullable: false),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_LoanApplicationKeyPersons_RfEducations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfMaritals_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationRACs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumAge = table.Column<bool>(type: "bit", nullable: true),
                    MaximumAge = table.Column<bool>(type: "bit", nullable: true),
                    IdentityCard = table.Column<bool>(type: "bit", nullable: true),
                    NationalBlacklist = table.Column<bool>(type: "bit", nullable: true),
                    BICollectibility = table.Column<bool>(type: "bit", nullable: true),
                    NotCollectibility = table.Column<bool>(type: "bit", nullable: true),
                    HasAge = table.Column<bool>(type: "bit", nullable: true),
                    HasNoCreditFacilities = table.Column<bool>(type: "bit", nullable: true),
                    NeverReceivedCredit = table.Column<bool>(type: "bit", nullable: true),
                    BPJSTKParticipants = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationRACs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationRACs_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Processed = table.Column<bool>(type: "bit", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStages_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStages_RfStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStages_Roles_OwnerRoleId",
                        column: x => x.OwnerRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStages_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStages_Users_ProcessedBy",
                        column: x => x.ProcessedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                name: "SLIKRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReadAndUnderstand = table.Column<bool>(type: "bit", nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminVerified = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalCreditCard = table.Column<double>(type: "float", nullable: false),
                    TotalLimitSlik = table.Column<double>(type: "float", nullable: false),
                    TotalOtherUses = table.Column<double>(type: "float", nullable: false),
                    TotalWorkingCapital = table.Column<double>(type: "float", nullable: false),
                    InquiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SLIKRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SLIKRequests_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SLIKRequests_RfBranches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "DocumentFileUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_DocumentFileUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFileUrls_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentFileUrls_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCollateralOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerIsDebtor = table.Column<bool>(type: "bit", nullable: false),
                    RelationCollateralId = table.Column<int>(type: "int", nullable: true),
                    OtherRelationCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerIdentityLifetime = table.Column<bool>(type: "bit", nullable: false),
                    OwnerIdentityExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressSameAsIdentity = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    OwnerNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerMaritalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OwnerEmergencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmegencyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCouplePlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerCoupleNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleIdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerCoupleIdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    OwnerCoupleAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeIdOwnerCouple = table.Column<int>(type: "int", nullable: true),
                    OwnerCoupleNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerCoupleJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCollateralOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_LoanApplicationCollaterals_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplicationCollaterals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfMaritals_OwnerMaritalId",
                        column: x => x.OwnerMaritalId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RelationCollateralId",
                        column: x => x.RelationCollateralId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfZipCodes_RfZipCodeIdOwnerCouple",
                        column: x => x.RfZipCodeIdOwnerCouple,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateTable(
                name: "SLIKRequestDebtors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKDebtorType = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstablishedLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLIKDocumentUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KodeRefPengguna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TujuanPermintaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLIKResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoboSlik = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SLIKRequestDebtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_FileUrls_SLIKDocumentUrlId",
                        column: x => x.SLIKDocumentUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_RfParameterDetails_SLIKDebtorType",
                        column: x => x.SLIKDebtorType,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                        column: x => x.SLIKRequestId,
                        principalTable: "SLIKRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CreatedBy",
                table: "Actions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_DeletedBy",
                table: "Actions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ModifiedBy",
                table: "Actions",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_ZipCodeId",
                table: "DebtorCompanies",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCouples_JobCode",
                table: "DebtorCouples",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCouples_ZipCodeId",
                table: "DebtorCouples",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_ZipCodeId",
                table: "DebtorEmergencies",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_EducationId",
                table: "Debtors",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_GenderId",
                table: "Debtors",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_JobCode",
                table: "Debtors",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_MaritalStatusId",
                table: "Debtors",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_ResidenceStatusId",
                table: "Debtors",
                column: "ResidenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_ZipCodeId",
                table: "Debtors",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFileUrls_DocumentId",
                table: "DocumentFileUrls",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFileUrls_FileUrlId",
                table: "DocumentFileUrls",
                column: "FileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentId",
                table: "Documents",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentStatusId",
                table: "Documents",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentType",
                table: "Documents",
                column: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LoanApplicationId",
                table: "Documents",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailSMTPSettings_CreatedBy",
                table: "EmailSMTPSettings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmailSMTPSettings_DeletedBy",
                table: "EmailSMTPSettings",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmailSMTPSettings_ModifiedBy",
                table: "EmailSMTPSettings",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_OwnerMaritalId",
                table: "LoanApplicationCollateralOwners",
                column: "OwnerMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RelationCollateralId",
                table: "LoanApplicationCollateralOwners",
                column: "RelationCollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RfZipCodeIdOwnerCouple",
                table: "LoanApplicationCollateralOwners",
                column: "RfZipCodeIdOwnerCouple");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_ZipCodeId",
                table: "LoanApplicationCollateralOwners",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_CollateralBCId",
                table: "LoanApplicationCollaterals",
                column: "CollateralBCId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_DocumentCode",
                table: "LoanApplicationCollaterals",
                column: "DocumentCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_LoanApplicationId",
                table: "LoanApplicationCollaterals",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_TransportationTypeCode",
                table: "LoanApplicationCollaterals",
                column: "TransportationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehClassCode",
                table: "LoanApplicationCollaterals",
                column: "VehClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehMakerCode",
                table: "LoanApplicationCollaterals",
                column: "VehMakerCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehModelCode",
                table: "LoanApplicationCollaterals",
                column: "VehModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_ZipCodeId",
                table: "LoanApplicationCollaterals",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoAverageAccBalanceId",
                table: "LoanApplicationCreditScorings",
                column: "ScoAverageAccBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBankRelationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBankRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBJBCreditHistoryId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBJBCreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBusinesLocationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBusinesLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoCollateralId",
                table: "LoanApplicationCreditScorings",
                column: "ScoCollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoFinanceManagerId",
                table: "LoanApplicationCreditScorings",
                column: "ScoFinanceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoMonthlyMutationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoNeedLevelId",
                table: "LoanApplicationCreditScorings",
                column: "ScoNeedLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoOtherPartyDebtId",
                table: "LoanApplicationCreditScorings",
                column: "ScoOtherPartyDebtId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoResidentialReputationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoResidentialReputationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoTransacMethodId",
                table: "LoanApplicationCreditScorings",
                column: "ScoTransacMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_ApplicationTypeId",
                table: "LoanApplicationFacilities",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_LoanApplicationId",
                table: "LoanApplicationFacilities",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_LoanPurposeId",
                table: "LoanApplicationFacilities",
                column: "LoanPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_NatureOfCreditId",
                table: "LoanApplicationFacilities",
                column: "NatureOfCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_PlacementCountryCode",
                table: "LoanApplicationFacilities",
                column: "PlacementCountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_SectorLBU3Code",
                table: "LoanApplicationFacilities",
                column: "SectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_SubProductId",
                table: "LoanApplicationFacilities",
                column: "SubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_TenorCode",
                table: "LoanApplicationFacilities",
                column: "TenorCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_EducationId",
                table: "LoanApplicationKeyPersons",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_LoanApplicationId",
                table: "LoanApplicationKeyPersons",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_MaritalStatusId",
                table: "LoanApplicationKeyPersons",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_ZipCodeId",
                table: "LoanApplicationKeyPersons",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BookingBranchId",
                table: "LoanApplications",
                column: "BookingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BranchId",
                table: "LoanApplications",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BusinessCycleId",
                table: "LoanApplications",
                column: "BusinessCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorCompanyId",
                table: "LoanApplications",
                column: "DebtorCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorId",
                table: "LoanApplications",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DecisionMakerId",
                table: "LoanApplications",
                column: "DecisionMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerCategoryId",
                table: "LoanApplications",
                column: "OwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProductId",
                table: "LoanApplications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfSectorLBU3Code",
                table: "LoanApplications",
                column: "RfSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_StageId",
                table: "LoanApplications",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStages_LoanApplicationId",
                table: "LoanApplicationStages",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStages_OwnerRoleId",
                table: "LoanApplicationStages",
                column: "OwnerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStages_OwnerUserId",
                table: "LoanApplicationStages",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStages_ProcessedBy",
                table: "LoanApplicationStages",
                column: "ProcessedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStages_StageId",
                table: "LoanApplicationStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_LogSendCallbackThirdParty_ThridPartyName",
                table: "LogSendCallbackThirdParty",
                column: "ThridPartyName");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_ActionId",
                table: "PageActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_CreatedBy",
                table: "PageActions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_DeletedBy",
                table: "PageActions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_ModifiedBy",
                table: "PageActions",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_PageId",
                table: "PageActions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_CreatedBy",
                table: "Pages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DeletedBy",
                table: "Pages",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ModifiedBy",
                table: "Pages",
                column: "ModifiedBy");

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
                name: "IX_Prospects_InstituteCode",
                table: "Prospects",
                column: "InstituteCode");

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
                name: "IX_Prospects_ZipCodeId",
                table: "Prospects",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfBusinessPlaceOwnerships_BusinessPlaceLocationCode",
                table: "RfBusinessPlaceOwnerships",
                column: "BusinessPlaceLocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfCompanyTypes_CompanyGroupId",
                table: "RfCompanyTypes",
                column: "CompanyGroupId");

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
                name: "IX_RfMappingTenors_LoanPurposeCode",
                table: "RfMappingTenors",
                column: "LoanPurposeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_ParamApplicationTypeId",
                table: "RfMappingTenors",
                column: "ParamApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_ProductId",
                table: "RfMappingTenors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_SubProductId",
                table: "RfMappingTenors",
                column: "SubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingTenors_TenorCode",
                table: "RfMappingTenors",
                column: "TenorCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfParameterDetails_ParameterId",
                table: "RfParameterDetails",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSandiBIs_BIGroup",
                table: "RfSandiBIs",
                column: "BIGroup");

            migrationBuilder.CreateIndex(
                name: "IX_RfScPositions_DecisionLeterCode",
                table: "RfScPositions",
                column: "DecisionLeterCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU2_RfSectorLBU1Code",
                table: "RfSectorLBU2",
                column: "RfSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_RfSectorLBU3_RfSectorLBU2Code",
                table: "RfSectorLBU3",
                column: "RfSectorLBU2Code");

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
                name: "IX_RfVehClasss_VehMakerCode",
                table: "RfVehClasss",
                column: "VehMakerCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehClasss_VehModelCode",
                table: "RfVehClasss",
                column: "VehModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_CollateralCode",
                table: "RfVehMakers",
                column: "CollateralCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_VehCode",
                table: "RfVehMakers",
                column: "VehCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_VehCountryCode",
                table: "RfVehMakers",
                column: "VehCountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ActionId",
                table: "RoleClaims",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_PageId",
                table: "RoleClaims",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedBy",
                table: "Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedBy",
                table: "Roles",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedBy",
                table: "Roles",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKDebtorType",
                table: "SLIKRequestDebtors",
                column: "SLIKDebtorType");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKDocumentUrlId",
                table: "SLIKRequestDebtors",
                column: "SLIKDocumentUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKRequestId",
                table: "SLIKRequestDebtors",
                column: "SLIKRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequests_BranchCode",
                table: "SLIKRequests",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ActionId",
                table: "UserClaims",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_PageId",
                table: "UserClaims",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevices_UserId",
                table: "UserDevices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "DebtorCompanyLegals");

            migrationBuilder.DropTable(
                name: "DebtorCouples");

            migrationBuilder.DropTable(
                name: "DebtorEmergencies");

            migrationBuilder.DropTable(
                name: "DocumentFileUrls");

            migrationBuilder.DropTable(
                name: "EmailSMTPSettings");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "LoanApplicationCollateralOwners");

            migrationBuilder.DropTable(
                name: "LoanApplicationCreditScorings");

            migrationBuilder.DropTable(
                name: "LoanApplicationFacilities");

            migrationBuilder.DropTable(
                name: "LoanApplicationKeyPersons");

            migrationBuilder.DropTable(
                name: "LoanApplicationRACs");

            migrationBuilder.DropTable(
                name: "LoanApplicationStages");

            migrationBuilder.DropTable(
                name: "LoginAudits");

            migrationBuilder.DropTable(
                name: "LogSendCallbackThirdParty");

            migrationBuilder.DropTable(
                name: "NLog");

            migrationBuilder.DropTable(
                name: "PageActions");

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
                name: "RfConditions");

            migrationBuilder.DropTable(
                name: "RfCreditNatures");

            migrationBuilder.DropTable(
                name: "RfCreditTypes");

            migrationBuilder.DropTable(
                name: "RfDecisionMakers");

            migrationBuilder.DropTable(
                name: "RfDocumentCollaterals");

            migrationBuilder.DropTable(
                name: "RfInstallmentTypes");

            migrationBuilder.DropTable(
                name: "RfLinkAgeTypes");

            migrationBuilder.DropTable(
                name: "RfMappingCollaterals");

            migrationBuilder.DropTable(
                name: "RfMappingTenors");

            migrationBuilder.DropTable(
                name: "RfRelationCols");

            migrationBuilder.DropTable(
                name: "RfSandiBIs");

            migrationBuilder.DropTable(
                name: "RfScPositions");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SIKPRequests");

            migrationBuilder.DropTable(
                name: "SIKPResponses");

            migrationBuilder.DropTable(
                name: "SLIKRequestDebtors");

            migrationBuilder.DropTable(
                name: "UserAllowedIPs");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserDevices");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LoanApplicationCollaterals");

            migrationBuilder.DropTable(
                name: "RfPlacementCountries");

            migrationBuilder.DropTable(
                name: "ThridParties");

            migrationBuilder.DropTable(
                name: "RfBusinessPlaceLocations");

            migrationBuilder.DropTable(
                name: "RfSubProducts");

            migrationBuilder.DropTable(
                name: "RfTenors");

            migrationBuilder.DropTable(
                name: "RfSandiBIGroups");

            migrationBuilder.DropTable(
                name: "RfDecisionLetters");

            migrationBuilder.DropTable(
                name: "RfLinkAges");

            migrationBuilder.DropTable(
                name: "SIKPs");

            migrationBuilder.DropTable(
                name: "FileUrls");

            migrationBuilder.DropTable(
                name: "SLIKRequests");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RfDocuments");

            migrationBuilder.DropTable(
                name: "RfTransportationTypes");

            migrationBuilder.DropTable(
                name: "RfVehClasss");

            migrationBuilder.DropTable(
                name: "RfLoanPurposes");

            migrationBuilder.DropTable(
                name: "RfDecisionLeterTypes");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "RfVehMakers");

            migrationBuilder.DropTable(
                name: "RfVehModels");

            migrationBuilder.DropTable(
                name: "DebtorCompanies");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "RfStages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RfCollateralBCs");

            migrationBuilder.DropTable(
                name: "RfVehCountries");

            migrationBuilder.DropTable(
                name: "RfVehTypes");

            migrationBuilder.DropTable(
                name: "RfEducations");

            migrationBuilder.DropTable(
                name: "RfJobs");

            migrationBuilder.DropTable(
                name: "RfMaritals");

            migrationBuilder.DropTable(
                name: "RfBranches");

            migrationBuilder.DropTable(
                name: "RfCompanyTypes");

            migrationBuilder.DropTable(
                name: "RfGenders");

            migrationBuilder.DropTable(
                name: "RfInstituteCode");

            migrationBuilder.DropTable(
                name: "RfSectorLBU3");

            migrationBuilder.DropTable(
                name: "RfZipCodes");

            migrationBuilder.DropTable(
                name: "RfProducts");

            migrationBuilder.DropTable(
                name: "RfParameterDetails");

            migrationBuilder.DropTable(
                name: "RfSectorLBU2");

            migrationBuilder.DropTable(
                name: "RfParameters");

            migrationBuilder.DropTable(
                name: "RfSectorLBU1");
        }
    }
}
