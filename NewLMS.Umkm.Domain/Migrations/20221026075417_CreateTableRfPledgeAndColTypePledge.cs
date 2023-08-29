using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfPledgeAndColTypePledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfPledges",
                columns: table => new
                {
                    PledgeId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PledgeTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfPledges", x => x.PledgeId);
                });

            migrationBuilder.CreateTable(
                name: "RfColTypePledges",
                columns: table => new
                {
                    RfColTypePledgeId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PledgeTypeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfColTypePledges", x => x.RfColTypePledgeId);
                    table.ForeignKey(
                        name: "FK_RfColTypePledges_RfPledges_PledgeTypeCode",
                        column: x => x.PledgeTypeCode,
                        principalTable: "RfPledges",
                        principalColumn: "PledgeId");
                });

            migrationBuilder.CreateTable(
                name: "RfPledgeTypes",
                columns: table => new
                {
                    RfPledgeTypeId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PledgeTypeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PledgeTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
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
                    table.PrimaryKey("PK_RfPledgeTypes", x => x.RfPledgeTypeId);
                    table.ForeignKey(
                        name: "FK_RfPledgeTypes_RfCollateral_CollateralCode",
                        column: x => x.CollateralCode,
                        principalTable: "RfCollateral",
                        principalColumn: "CollateralCode");
                    table.ForeignKey(
                        name: "FK_RfPledgeTypes_RfPledges_PledgeTypeCode",
                        column: x => x.PledgeTypeCode,
                        principalTable: "RfPledges",
                        principalColumn: "PledgeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfColTypePledges_PledgeTypeCode",
                table: "RfColTypePledges",
                column: "PledgeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfPledgeTypes_CollateralCode",
                table: "RfPledgeTypes",
                column: "CollateralCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfPledgeTypes_PledgeTypeCode",
                table: "RfPledgeTypes",
                column: "PledgeTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfColTypePledges");

            migrationBuilder.DropTable(
                name: "RfPledgeTypes");

            migrationBuilder.DropTable(
                name: "RfPledges");
        }
    }
}
