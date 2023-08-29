using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableSCUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPWD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ResetPWD = table.Column<bool>(type: "bit", nullable: false),
                    PWDFalse = table.Column<int>(type: "int", nullable: false),
                    PWDLastFalse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PWDLastChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PWDMustChange = table.Column<bool>(type: "bit", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokeFlag = table.Column<bool>(type: "bit", nullable: false),
                    SKNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerihalSK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdFlag = table.Column<bool>(type: "bit", nullable: false),
                    LoginFlag = table.Column<bool>(type: "bit", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_SCUsers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCUsers");
        }
    }
}
