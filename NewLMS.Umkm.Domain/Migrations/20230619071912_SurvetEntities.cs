using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SurvetEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyBuyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaBuyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisProduk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTelp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LamaHubunganTahun = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFPaymentMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SurveyBuyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyBuyers_RFPaymentMethods_RFPaymentMethodsId",
                        column: x => x.RFPaymentMethodsId,
                        principalTable: "RFPaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyBuyers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyFileUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Judul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalUpload = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadOleh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SurveyFileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyFileUploads_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyFileUploads_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveySuppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisProduk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTelp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LamaHubunganTahun = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFPaymentMethodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SurveySuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveySuppliers_RFPaymentMethods_RFPaymentMethodsId",
                        column: x => x.RFPaymentMethodsId,
                        principalTable: "RFPaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveySuppliers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyBuyers_RFPaymentMethodsId",
                table: "SurveyBuyers",
                column: "RFPaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyBuyers_SurveyId",
                table: "SurveyBuyers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyFileUploads_FileUrlId",
                table: "SurveyFileUploads",
                column: "FileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyFileUploads_SurveyId",
                table: "SurveyFileUploads",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySuppliers_RFPaymentMethodsId",
                table: "SurveySuppliers",
                column: "RFPaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySuppliers_SurveyId",
                table: "SurveySuppliers",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyBuyers");

            migrationBuilder.DropTable(
                name: "SurveyFileUploads");

            migrationBuilder.DropTable(
                name: "SurveySuppliers");
        }
    }
}
