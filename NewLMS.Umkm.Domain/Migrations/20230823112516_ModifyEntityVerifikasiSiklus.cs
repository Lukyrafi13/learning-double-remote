using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyEntityVerifikasiSiklus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "BiayaVariabelTenagaKerjas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "BiayaVariabels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "BiayaTetaps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "BiayaInvestasis",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "ArusKasMasuks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BiayaVariabelTenagaKerjas_SurveyId",
                table: "BiayaVariabelTenagaKerjas",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_BiayaVariabels_SurveyId",
                table: "BiayaVariabels",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_BiayaTetaps_SurveyId",
                table: "BiayaTetaps",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_BiayaInvestasis_SurveyId",
                table: "BiayaInvestasis",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArusKasMasuks_SurveyId",
                table: "ArusKasMasuks",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArusKasMasuks_Surveys_SurveyId",
                table: "ArusKasMasuks",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiayaInvestasis_Surveys_SurveyId",
                table: "BiayaInvestasis",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiayaTetaps_Surveys_SurveyId",
                table: "BiayaTetaps",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiayaVariabels_Surveys_SurveyId",
                table: "BiayaVariabels",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiayaVariabelTenagaKerjas_Surveys_SurveyId",
                table: "BiayaVariabelTenagaKerjas",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArusKasMasuks_Surveys_SurveyId",
                table: "ArusKasMasuks");

            migrationBuilder.DropForeignKey(
                name: "FK_BiayaInvestasis_Surveys_SurveyId",
                table: "BiayaInvestasis");

            migrationBuilder.DropForeignKey(
                name: "FK_BiayaTetaps_Surveys_SurveyId",
                table: "BiayaTetaps");

            migrationBuilder.DropForeignKey(
                name: "FK_BiayaVariabels_Surveys_SurveyId",
                table: "BiayaVariabels");

            migrationBuilder.DropForeignKey(
                name: "FK_BiayaVariabelTenagaKerjas_Surveys_SurveyId",
                table: "BiayaVariabelTenagaKerjas");

            migrationBuilder.DropIndex(
                name: "IX_BiayaVariabelTenagaKerjas_SurveyId",
                table: "BiayaVariabelTenagaKerjas");

            migrationBuilder.DropIndex(
                name: "IX_BiayaVariabels_SurveyId",
                table: "BiayaVariabels");

            migrationBuilder.DropIndex(
                name: "IX_BiayaTetaps_SurveyId",
                table: "BiayaTetaps");

            migrationBuilder.DropIndex(
                name: "IX_BiayaInvestasis_SurveyId",
                table: "BiayaInvestasis");

            migrationBuilder.DropIndex(
                name: "IX_ArusKasMasuks_SurveyId",
                table: "ArusKasMasuks");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "BiayaVariabelTenagaKerjas");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "BiayaVariabels");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "BiayaTetaps");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "BiayaInvestasis");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "ArusKasMasuks");
        }
    }
}
