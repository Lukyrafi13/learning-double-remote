using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IntegrasiSLIK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SlikRequestId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SlikRequestId",
                table: "Prescreenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SlikRequestId",
                table: "Approvals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SlikRequestId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SlikRequestId",
                table: "Reviews",
                column: "SlikRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescreenings_SlikRequestId",
                table: "Prescreenings",
                column: "SlikRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_SlikRequestId",
                table: "Approvals",
                column: "SlikRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_SlikRequestId",
                table: "Analisas",
                column: "SlikRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_SlikRequests_SlikRequestId",
                table: "Analisas",
                column: "SlikRequestId",
                principalTable: "SlikRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_SlikRequests_SlikRequestId",
                table: "Approvals",
                column: "SlikRequestId",
                principalTable: "SlikRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescreenings_SlikRequests_SlikRequestId",
                table: "Prescreenings",
                column: "SlikRequestId",
                principalTable: "SlikRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_SlikRequests_SlikRequestId",
                table: "Reviews",
                column: "SlikRequestId",
                principalTable: "SlikRequests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_SlikRequests_SlikRequestId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_SlikRequests_SlikRequestId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescreenings_SlikRequests_SlikRequestId",
                table: "Prescreenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_SlikRequests_SlikRequestId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_SlikRequestId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Prescreenings_SlikRequestId",
                table: "Prescreenings");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_SlikRequestId",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_SlikRequestId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SlikRequestId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "SlikRequestId",
                table: "Prescreenings");

            migrationBuilder.DropColumn(
                name: "SlikRequestId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "SlikRequestId",
                table: "Analisas");
        }
    }
}
