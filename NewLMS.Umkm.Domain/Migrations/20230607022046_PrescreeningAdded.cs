using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescreenings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RACUsiaMin = table.Column<bool>(type: "bit", nullable: true),
                    RACUsiaMax = table.Column<bool>(type: "bit", nullable: true),
                    RACeKTP = table.Column<bool>(type: "bit", nullable: true),
                    RACNonDaftarHitam = table.Column<bool>(type: "bit", nullable: true),
                    RACKolektibilitas1 = table.Column<bool>(type: "bit", nullable: true),
                    RACTidakKolektibilitas345 = table.Column<bool>(type: "bit", nullable: true),
                    RACMemilikiUsaha = table.Column<bool>(type: "bit", nullable: true),
                    RACTidakMemilikiFasilitasKreditLain = table.Column<bool>(type: "bit", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Prescreenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescreenings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescreenings_AppId",
                table: "Prescreenings",
                column: "AppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescreenings");
        }
    }
}
