using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterTableSLIKRequestDebtors_AddSupportForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishedDate",
                table: "SLIKRequestDebtors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstablishedLocation",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoanApplicationApplicationStage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Processed = table.Column<bool>(type: "bit", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationApplicationStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationApplicationStage_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationApplicationStage_Roles_OwnerRoleId",
                        column: x => x.OwnerRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationApplicationStage_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationApplicationStage_Users_ProcessedBy",
                        column: x => x.ProcessedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationApplicationStage_LoanApplicationId",
                table: "LoanApplicationApplicationStage",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationApplicationStage_OwnerRoleId",
                table: "LoanApplicationApplicationStage",
                column: "OwnerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationApplicationStage_OwnerUserId",
                table: "LoanApplicationApplicationStage",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationApplicationStage_ProcessedBy",
                table: "LoanApplicationApplicationStage",
                column: "ProcessedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents",
                column: "DocumentType",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "LoanApplicationApplicationStage");

            migrationBuilder.DropColumn(
                name: "EstablishedDate",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "EstablishedLocation",
                table: "SLIKRequestDebtors");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents",
                column: "DocumentType",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }
    }
}
