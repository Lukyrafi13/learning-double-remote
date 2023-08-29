using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class StagingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFStages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GroupStage = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_RFStages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "ProspectStageLogs",
                columns: table => new
                {
                    LoanApplicationStageLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutedBy = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
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
                    table.PrimaryKey("PK_ProspectStageLogs", x => x.LoanApplicationStageLogId);
                    table.ForeignKey(
                        name: "FK_ProspectStageLogs_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProspectStageLogs_RFStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RFStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProspectStageLogs_ProspectId",
                table: "ProspectStageLogs",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectStageLogs_StageId",
                table: "ProspectStageLogs",
                column: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProspectStageLogs");

            migrationBuilder.DropTable(
                name: "RFStages");
        }
    }
}
