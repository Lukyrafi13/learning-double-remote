using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfScoringParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusCreditValue",
                table: "RfScoringStatusCredits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServicePeriodValue",
                table: "RfScoringServicePeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResidenceStatusValue",
                table: "RfScoringResidenceStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDepent",
                table: "RfScoringNumberOfDepents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatusValue",
                table: "RfScoringMaritalStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatusValue",
                table: "RfScoringEmployeeStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DebtorTypeValue",
                table: "RfScoringDebtorTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BICheckingValue",
                table: "RFScoringBICheckings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "RfScoringBetas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "RfScoringBetas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RfScoringParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfScoringParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfScoringParamDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RfScoringParamId = table.Column<int>(type: "int", nullable: false),
                    WhereClause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfScoringParamDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfScoringParamDetails_RfScoringParams_RfScoringParamId",
                        column: x => x.RfScoringParamId,
                        principalTable: "RfScoringParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfScoringParamDetails_RfScoringParamId",
                table: "RfScoringParamDetails",
                column: "RfScoringParamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfScoringParamDetails");

            migrationBuilder.DropTable(
                name: "RfScoringParams");

            migrationBuilder.DropColumn(
                name: "StatusCreditValue",
                table: "RfScoringStatusCredits");

            migrationBuilder.DropColumn(
                name: "ServicePeriodValue",
                table: "RfScoringServicePeriods");

            migrationBuilder.DropColumn(
                name: "ResidenceStatusValue",
                table: "RfScoringResidenceStatuses");

            migrationBuilder.DropColumn(
                name: "NumberOfDepent",
                table: "RfScoringNumberOfDepents");

            migrationBuilder.DropColumn(
                name: "MaritalStatusValue",
                table: "RfScoringMaritalStatuses");

            migrationBuilder.DropColumn(
                name: "EmployeeStatusValue",
                table: "RfScoringEmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "DebtorTypeValue",
                table: "RfScoringDebtorTypes");

            migrationBuilder.DropColumn(
                name: "BICheckingValue",
                table: "RFScoringBICheckings");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "RfScoringBetas");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "RfScoringBetas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
