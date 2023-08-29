using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfDeviation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeviationDesc",
                table: "Deviations",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RfDeviations",
                columns: table => new
                {
                    RfDeviationId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DeviationCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DeviationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfDeviations", x => x.RfDeviationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deviations_DeviationDesc",
                table: "Deviations",
                column: "DeviationDesc");

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_RfDeviations_DeviationDesc",
                table: "Deviations",
                column: "DeviationDesc",
                principalTable: "RfDeviations",
                principalColumn: "RfDeviationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_RfDeviations_DeviationDesc",
                table: "Deviations");

            migrationBuilder.DropTable(
                name: "RfDeviations");

            migrationBuilder.DropIndex(
                name: "IX_Deviations_DeviationDesc",
                table: "Deviations");

            migrationBuilder.AlterColumn<string>(
                name: "DeviationDesc",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);
        }
    }
}
