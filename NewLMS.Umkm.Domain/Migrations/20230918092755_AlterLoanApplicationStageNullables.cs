using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplicationStageNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStages_Roles_OwnerRoleId",
                table: "LoanApplicationStages");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStages_Users_OwnerUserId",
                table: "LoanApplicationStages");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerUserId",
                table: "LoanApplicationStages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerRoleId",
                table: "LoanApplicationStages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStages_Roles_OwnerRoleId",
                table: "LoanApplicationStages",
                column: "OwnerRoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStages_Users_OwnerUserId",
                table: "LoanApplicationStages",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStages_Roles_OwnerRoleId",
                table: "LoanApplicationStages");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStages_Users_OwnerUserId",
                table: "LoanApplicationStages");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerUserId",
                table: "LoanApplicationStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerRoleId",
                table: "LoanApplicationStages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStages_Roles_OwnerRoleId",
                table: "LoanApplicationStages",
                column: "OwnerRoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStages_Users_OwnerUserId",
                table: "LoanApplicationStages",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
