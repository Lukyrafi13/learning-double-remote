using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddRFNegaraPenempatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFLoanPurpose_RFLoanPurposeId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFSifatKredits_RFSifatKreditId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFSubProducts_RFSubProductId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFTenors_RFTenorId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropColumn(
                name: "RFLoanPurpose",
                table: "AppFasilitasKredits");

            migrationBuilder.DropColumn(
                name: "RFSifatKredit",
                table: "AppFasilitasKredits");

            migrationBuilder.DropColumn(
                name: "RFSubProduct",
                table: "AppFasilitasKredits");

            migrationBuilder.RenameColumn(
                name: "RFTenor",
                table: "AppFasilitasKredits",
                newName: "RFNegaraPenempatanId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFTenorId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RFSubProductId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RFSifatKreditId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RFLoanPurposeId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RFNegaraPenempatans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NegaraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NegaraDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kurs = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_RFNegaraPenempatans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                column: "RFNegaraPenempatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFLoanPurpose_RFLoanPurposeId",
                table: "AppFasilitasKredits",
                column: "RFLoanPurposeId",
                principalTable: "RFLoanPurpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                column: "RFNegaraPenempatanId",
                principalTable: "RFNegaraPenempatans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFSifatKredits_RFSifatKreditId",
                table: "AppFasilitasKredits",
                column: "RFSifatKreditId",
                principalTable: "RFSifatKredits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFSubProducts_RFSubProductId",
                table: "AppFasilitasKredits",
                column: "RFSubProductId",
                principalTable: "RFSubProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFTenors_RFTenorId",
                table: "AppFasilitasKredits",
                column: "RFTenorId",
                principalTable: "RFTenors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFLoanPurpose_RFLoanPurposeId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFSifatKredits_RFSifatKreditId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFSubProducts_RFSubProductId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFTenors_RFTenorId",
                table: "AppFasilitasKredits");

            migrationBuilder.DropTable(
                name: "RFNegaraPenempatans");

            migrationBuilder.DropIndex(
                name: "IX_AppFasilitasKredits_RFNegaraPenempatanId",
                table: "AppFasilitasKredits");

            migrationBuilder.RenameColumn(
                name: "RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                newName: "RFTenor");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFTenorId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFSubProductId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFSifatKreditId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFLoanPurposeId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RFLoanPurpose",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RFSifatKredit",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RFSubProduct",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFLoanPurpose_RFLoanPurposeId",
                table: "AppFasilitasKredits",
                column: "RFLoanPurposeId",
                principalTable: "RFLoanPurpose",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFSifatKredits_RFSifatKreditId",
                table: "AppFasilitasKredits",
                column: "RFSifatKreditId",
                principalTable: "RFSifatKredits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFSubProducts_RFSubProductId",
                table: "AppFasilitasKredits",
                column: "RFSubProductId",
                principalTable: "RFSubProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFTenors_RFTenorId",
                table: "AppFasilitasKredits",
                column: "RFTenorId",
                principalTable: "RFTenors",
                principalColumn: "Id");
        }
    }
}
