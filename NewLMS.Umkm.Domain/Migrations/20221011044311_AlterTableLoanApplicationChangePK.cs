using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationInsuranceLives_LoanApplications_LoanApplicationNo",
                table: "LoanApplicationInsuranceLives");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_LoanApplications_LoanApplicationId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationSubProgram_LoanApplications_LoanApplicationId",
                table: "LoanApplicationSubProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTermCredits_LoanApplications_LoanApplicationId",
                table: "LoanApplicationTermCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_LoanApplications_LoanApplicationId",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedFacilities_LoanApplications_FacilityId",
                table: "ReceivedFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_LoanApplications_LoanApplicationId",
                table: "SLIKRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubmittedFacilities",
                table: "SubmittedFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceivedFacilities",
                table: "ReceivedFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications");


            migrationBuilder.AlterColumn<Guid>(
                name: "SubmittedFacilityId",
                table: "SubmittedFacilities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationId",
                table: "SLIKRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "FacilityId",
                table: "ReceivedFacilities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationId",
                table: "PreviousPledges",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationId",
                table: "LoanApplicationTermCredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationId",
                table: "LoanApplicationSubProgram",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationId",
                table: "LoanApplicationStageLogs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.AlterColumn<Guid>(
                name: "LoanApplicationNo",
                table: "LoanApplicationInsuranceLives",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationInsuranceLives_LoanApplications_LoanApplicationNo",
                table: "LoanApplicationInsuranceLives",
                column: "LoanApplicationNo",
                principalTable: "LoanApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_LoanApplications_LoanApplicationId",
                table: "LoanApplicationStageLogs",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationSubProgram_LoanApplications_LoanApplicationId",
                table: "LoanApplicationSubProgram",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTermCredits_LoanApplications_LoanApplicationId",
                table: "LoanApplicationTermCredits",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_LoanApplications_LoanApplicationId",
                table: "PreviousPledges",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedFacilities_LoanApplications_FacilityId",
                table: "ReceivedFacilities",
                column: "FacilityId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequests_LoanApplications_LoanApplicationId",
                table: "SLIKRequests",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities",
                column: "SubmittedFacilityId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationInsuranceLives_LoanApplications_LoanApplicationNo",
                table: "LoanApplicationInsuranceLives");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_LoanApplications_LoanApplicationId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationSubProgram_LoanApplications_LoanApplicationId",
                table: "LoanApplicationSubProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationTermCredits_LoanApplications_LoanApplicationId",
                table: "LoanApplicationTermCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_LoanApplications_LoanApplicationId",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedFacilities_LoanApplications_FacilityId",
                table: "ReceivedFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_LoanApplications_LoanApplicationId",
                table: "SLIKRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<string>(
                name: "SubmittedFacilityId",
                table: "SubmittedFacilities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationId",
                table: "SLIKRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityId",
                table: "ReceivedFacilities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationId",
                table: "PreviousPledges",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationId",
                table: "LoanApplicationTermCredits",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationId",
                table: "LoanApplicationSubProgram",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationId",
                table: "LoanApplicationStageLogs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LoanApplicationNo",
                table: "LoanApplicationInsuranceLives",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubmittedFacilities",
                table: "SubmittedFacilities",
                column: "SubmittedFacilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceivedFacilities",
                table: "ReceivedFacilities",
                column: "FacilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationInsuranceLives_LoanApplications_LoanApplicationNo",
                table: "LoanApplicationInsuranceLives",
                column: "LoanApplicationNo",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_LoanApplications_LoanApplicationId",
                table: "LoanApplicationStageLogs",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationSubProgram_LoanApplications_LoanApplicationId",
                table: "LoanApplicationSubProgram",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationTermCredits_LoanApplications_LoanApplicationId",
                table: "LoanApplicationTermCredits",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_LoanApplications_LoanApplicationId",
                table: "PreviousPledges",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedFacilities_LoanApplications_FacilityId",
                table: "ReceivedFacilities",
                column: "FacilityId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequests_LoanApplications_LoanApplicationId",
                table: "SLIKRequests",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities",
                column: "SubmittedFacilityId",
                principalTable: "LoanApplications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}