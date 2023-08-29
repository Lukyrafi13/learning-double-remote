using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SupplierEntitiesAndRF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFOwnerCategoryId",
                table: "Surveys",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFRelationSurveyId",
                table: "Surveys",
                column: "RFRelationSurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFOwnerCategories_RFOwnerCategoryId",
                table: "Surveys",
                column: "RFOwnerCategoryId",
                principalTable: "RFOwnerCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFRelationSurveys_RFRelationSurveyId",
                table: "Surveys",
                column: "RFRelationSurveyId",
                principalTable: "RFRelationSurveys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFOwnerCategories_RFOwnerCategoryId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFRelationSurveys_RFRelationSurveyId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFOwnerCategoryId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFRelationSurveyId",
                table: "Surveys");
        }
    }
}
