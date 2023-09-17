using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addApprTTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprChecklistReviews",
                columns: table => new
                {
                    ApprChecklistReviewGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yesno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprChecklistReviews", x => x.ApprChecklistReviewGuid);
                    table.ForeignKey(
                        name: "FK_ApprChecklistReviews_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprReceivableVerifications",
                columns: table => new
                {
                    ApprReceivableVerificationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppraisalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectStatus = table.Column<bool>(type: "bit", nullable: false),
                    VerificationBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprReceivableVerifications", x => x.ApprReceivableVerificationGuid);
                    table.ForeignKey(
                        name: "FK_ApprReceivableVerifications_LoanApplicationAppraisals_AppraisalGuid",
                        column: x => x.AppraisalGuid,
                        principalTable: "LoanApplicationAppraisals",
                        principalColumn: "AppraisalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprVehicleNotes",
                columns: table => new
                {
                    VehicleNoteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprVehicleTemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ApprVehicleNotes", x => x.VehicleNoteGuid);
                    table.ForeignKey(
                        name: "FK_ApprVehicleNotes_ApprVehicleTemplate_ApprVehicleTemplateGuid",
                        column: x => x.ApprVehicleTemplateGuid,
                        principalTable: "ApprVehicleTemplate",
                        principalColumn: "ApprVehicleTemplateGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprChecklistReviews_AppraisalGuid",
                table: "ApprChecklistReviews",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprReceivableVerifications_AppraisalGuid",
                table: "ApprReceivableVerifications",
                column: "AppraisalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApprVehicleNotes_ApprVehicleTemplateGuid",
                table: "ApprVehicleNotes",
                column: "ApprVehicleTemplateGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprChecklistReviews");

            migrationBuilder.DropTable(
                name: "ApprReceivableVerifications");

            migrationBuilder.DropTable(
                name: "ApprVehicleNotes");
        }
    }
}
