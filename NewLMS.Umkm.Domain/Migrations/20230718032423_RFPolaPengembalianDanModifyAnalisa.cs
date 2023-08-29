using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFPolaPengembalianDanModifyAnalisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RFCaraPenarikanId",
                table: "Analisas");

            migrationBuilder.RenameColumn(
                name: "RFStagesId",
                table: "Analisas",
                newName: "RFPolaPengembalianAngsuranId");

            migrationBuilder.RenameColumn(
                name: "RFPolaPengambilanAngsuranId",
                table: "Analisas",
                newName: "RFCaraPengikatanId");

            migrationBuilder.AddColumn<string>(
                name: "RFBranchesCode",
                table: "Analisas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RFPolaPengembalians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PolaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RFPolaPengembalians", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFBranchesCode",
                table: "Analisas",
                column: "RFBranchesCode");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFCaraPengikatanId",
                table: "Analisas",
                column: "RFCaraPengikatanId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFPengikatanKreditId",
                table: "Analisas",
                column: "RFPengikatanKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFPolaPengembalianAngsuranId",
                table: "Analisas",
                column: "RFPolaPengembalianAngsuranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RfBranches_RFBranchesCode",
                table: "Analisas",
                column: "RFBranchesCode",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFCaraPengikatans_RFCaraPengikatanId",
                table: "Analisas",
                column: "RFCaraPengikatanId",
                principalTable: "RFCaraPengikatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFPengikatanKredits_RFPengikatanKreditId",
                table: "Analisas",
                column: "RFPengikatanKreditId",
                principalTable: "RFPengikatanKredits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFPolaPengembalians_RFPolaPengembalianAngsuranId",
                table: "Analisas",
                column: "RFPolaPengembalianAngsuranId",
                principalTable: "RFPolaPengembalians",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RfBranches_RFBranchesCode",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFCaraPengikatans_RFCaraPengikatanId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFPengikatanKredits_RFPengikatanKreditId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFPolaPengembalians_RFPolaPengembalianAngsuranId",
                table: "Analisas");

            migrationBuilder.DropTable(
                name: "RFPolaPengembalians");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFBranchesCode",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFCaraPengikatanId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFPengikatanKreditId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFPolaPengembalianAngsuranId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFBranchesCode",
                table: "Analisas");

            migrationBuilder.RenameColumn(
                name: "RFPolaPengembalianAngsuranId",
                table: "Analisas",
                newName: "RFStagesId");

            migrationBuilder.RenameColumn(
                name: "RFCaraPengikatanId",
                table: "Analisas",
                newName: "RFPolaPengambilanAngsuranId");

            migrationBuilder.AddColumn<Guid>(
                name: "RFCaraPenarikanId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
