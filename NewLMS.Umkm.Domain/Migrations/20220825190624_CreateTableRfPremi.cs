using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfPremi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfPremis",
                columns: table => new
                {
                    InsRateCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TplCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: false),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    DebiturAge = table.Column<int>(type: "int", nullable: false),
                    InsRate = table.Column<float>(type: "real", nullable: false),
                    KetreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetvehCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTtg = table.Column<float>(type: "real", nullable: false),
                    MaxTtg = table.Column<float>(type: "real", nullable: false),
                    PurposeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColusiaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BtsRiskCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfPremis", x => x.InsRateCode);
                    table.ForeignKey(
                        name: "FK_RfPremis_RfInsuranceCoverages_RiskCode",
                        column: x => x.RiskCode,
                        principalTable: "RfInsuranceCoverages",
                        principalColumn: "RiskCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfPremis_RiskCode",
                table: "RfPremis",
                column: "RiskCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfPremis");
        }
    }
}
