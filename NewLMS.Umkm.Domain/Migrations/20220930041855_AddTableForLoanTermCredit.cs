using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableForLoanTermCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfTermConditions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BTB = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfTermConditions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RfTermTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TermConditionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfTermTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfTermTemplates_RfTermConditions_TermConditionCode",
                        column: x => x.TermConditionCode,
                        principalTable: "RfTermConditions",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationTermCredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RfTermTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TermAnswer = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplianceStaAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ComplianceStaBusinessLegal = table.Column<bool>(type: "bit", nullable: false),
                    ComplianceStaNo = table.Column<bool>(type: "bit", nullable: false),
                    RemarkAdmin = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    RemarkBusinessLegal = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationTermCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationTermCredits_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationTermCredits_RfTermTemplates_RfTermTemplateId",
                        column: x => x.RfTermTemplateId,
                        principalTable: "RfTermTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfSubProductTermTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubProuctId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TermTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_RfSubProductTermTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfSubProductTermTemplates_RfSubProducts_SubProuctId",
                        column: x => x.SubProuctId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                    table.ForeignKey(
                        name: "FK_RfSubProductTermTemplates_RfTermTemplates_TermTemplateId",
                        column: x => x.TermTemplateId,
                        principalTable: "RfTermTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTermCredits_LoanApplicationId",
                table: "LoanApplicationTermCredits",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationTermCredits_RfTermTemplateId",
                table: "LoanApplicationTermCredits",
                column: "RfTermTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProductTermTemplates_SubProuctId",
                table: "RfSubProductTermTemplates",
                column: "SubProuctId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProductTermTemplates_TermTemplateId",
                table: "RfSubProductTermTemplates",
                column: "TermTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RfTermTemplates_TermConditionCode",
                table: "RfTermTemplates",
                column: "TermConditionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationTermCredits");

            migrationBuilder.DropTable(
                name: "RfSubProductTermTemplates");

            migrationBuilder.DropTable(
                name: "RfTermTemplates");

            migrationBuilder.DropTable(
                name: "RfTermConditions");
        }
    }
}
