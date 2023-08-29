using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfSubProductJobCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfSubProductJobCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobCode = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ShowTpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    MaxPlafondPayroll = table.Column<int>(type: "int", nullable: false),
                    MaxPlafondNonPayroll = table.Column<int>(type: "int", nullable: false),
                    MaxTenorPayroll = table.Column<int>(type: "int", nullable: false),
                    MaxTenorNonPayroll = table.Column<int>(type: "int", nullable: false),
                    MinTenor = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfSubProductJobCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfSubProductJobCode_RfParameterDetails_JobCode",
                        column: x => x.JobCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfSubProductJobCode_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProductJobCode_JobCode",
                table: "RfSubProductJobCode",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProductJobCode_SubProductId",
                table: "RfSubProductJobCode",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfSubProductJobCode");
        }
    }
}
