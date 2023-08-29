using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RfCollateralCode",
                table: "DebtorCollaterals",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RfCollateral",
                columns: table => new
                {
                    CollateralCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<int>(type: "int", nullable: false),
                    BeaGroup = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfCollateral", x => x.CollateralCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCollaterals_RfCollateralCode",
                table: "DebtorCollaterals",
                column: "RfCollateralCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCollaterals_RfCollateral_RfCollateralCode",
                table: "DebtorCollaterals",
                column: "RfCollateralCode",
                principalTable: "RfCollateral",
                principalColumn: "CollateralCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCollaterals_RfCollateral_RfCollateralCode",
                table: "DebtorCollaterals");

            migrationBuilder.DropTable(
                name: "RfCollateral");

            migrationBuilder.DropIndex(
                name: "IX_DebtorCollaterals_RfCollateralCode",
                table: "DebtorCollaterals");

            migrationBuilder.DropColumn(
                name: "RfCollateralCode",
                table: "DebtorCollaterals");
        }
    }
}
