using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addChekingReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfSandiBIGroups",
                columns: table => new
                {
                    BIGroup = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSandiBIGroups", x => x.BIGroup);
                });

            migrationBuilder.CreateTable(
                            name: "RfSandiBIs",
                            columns: table => new
                            {
                                RfSandiBIId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                                BIGroup = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                                BIType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                                BICode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                                BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                                Active = table.Column<bool>(type: "bit", nullable: false),
                                CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                LBU2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                                table.PrimaryKey("PK_RfSandiBIs", x => x.RfSandiBIId);
                                table.ForeignKey(
                                    name: "FK_RfSandiBIs_RfSandiBIGroups_BIGroup",
                                    column: x => x.BIGroup,
                                    principalTable: "RfSandiBIGroups",
                                    principalColumn: "BIGroup",
                                    onDelete: ReferentialAction.Cascade);
                            });



            migrationBuilder.CreateTable(
                            name: "RfCreditTypes",
                            columns: table => new
                            {
                                CreditTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                                CreditTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                CreditAgreement = table.Column<bool>(type: "bit", nullable: true),
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
                                table.PrimaryKey("PK_RfCreditTypes", x => x.CreditTypeCode);
                            });


            migrationBuilder.CreateIndex(
                            name: "IX_RfSandiBIs_BIGroup",
                            table: "RfSandiBIs",
                            column: "BIGroup");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                            name: "RfCreditTypes");
            migrationBuilder.DropTable(
                            name: "RfSandiBIs");
            migrationBuilder.DropTable(
                            name: "RfSandiBIGroups");
        }
    }
}
