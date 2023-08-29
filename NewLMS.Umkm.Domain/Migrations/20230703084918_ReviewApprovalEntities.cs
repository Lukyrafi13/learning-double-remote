using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ReviewApprovalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approvals_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Approvals_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approvals_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_AnalisaId",
                table: "Approvals",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_AppId",
                table: "Approvals",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_PrescreeningId",
                table: "Approvals",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_SurveyId",
                table: "Approvals",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AnalisaId",
                table: "Reviews",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppId",
                table: "Reviews",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PrescreeningId",
                table: "Reviews",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SurveyId",
                table: "Reviews",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
