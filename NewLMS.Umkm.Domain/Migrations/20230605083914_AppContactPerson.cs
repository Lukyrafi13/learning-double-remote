using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppContactPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppContactPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorHandphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFRelationColId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AppContactPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppContactPersons_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppContactPersons_RFGenders_RFGenderId",
                        column: x => x.RFGenderId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppContactPersons_RFRelationCols_RFRelationColId",
                        column: x => x.RFRelationColId,
                        principalTable: "RFRelationCols",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppContactPersons_AppId",
                table: "AppContactPersons",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppContactPersons_RFGenderId",
                table: "AppContactPersons",
                column: "RFGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppContactPersons_RFRelationColId",
                table: "AppContactPersons",
                column: "RFRelationColId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppContactPersons");
        }
    }
}
