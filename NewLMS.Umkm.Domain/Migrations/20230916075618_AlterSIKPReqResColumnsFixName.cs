using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPReqResColumnsFixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtorCompanyEstablishmentDeedNumber",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyEstablishmentDeedNumber",
                table: "SIKPRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPResponses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorCompanyEstablishmentDeedNumber",
                table: "SIKPResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorCompanyEstablishmentDeedNumber",
                table: "SIKPRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
