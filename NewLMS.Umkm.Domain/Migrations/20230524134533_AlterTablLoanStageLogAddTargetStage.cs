using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTablLoanStageLogAddTargetStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "StageId",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DispatchedTo",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TargetStage",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStageLogs_TargetStage",
                table: "LoanApplicationStageLogs",
                column: "TargetStage");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_TargetStage",
                table: "LoanApplicationStageLogs",
                column: "TargetStage",
                principalTable: "RfStages",
                principalColumn: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_TargetStage",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationStageLogs_TargetStage",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropColumn(
                name: "TargetStage",
                table: "LoanApplicationStageLogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "StageId",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DispatchedTo",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
