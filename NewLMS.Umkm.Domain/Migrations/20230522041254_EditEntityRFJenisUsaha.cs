﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditEntityRFJenisUsaha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFJenisUsahas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANL_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANL_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RFJenisUsahas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFJenisUsahas");
        }
    }
}
