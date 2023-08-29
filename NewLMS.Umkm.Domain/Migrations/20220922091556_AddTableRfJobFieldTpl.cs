using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfJobFieldTpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfJobFieldTpls",
                columns: table => new
                {
                    SHOW_TPL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GOLONGAN = table.Column<bool>(type: "bit", nullable: true),
                    MASAJABATAN = table.Column<bool>(type: "bit", nullable: true),
                    TGLPENSIUN = table.Column<bool>(type: "bit", nullable: true),
                    SISAPENSIUN = table.Column<bool>(type: "bit", nullable: true),
                    GAJIBERSIH = table.Column<bool>(type: "bit", nullable: true),
                    GAJIPOKOK = table.Column<bool>(type: "bit", nullable: true),
                    TUNJANGAN = table.Column<bool>(type: "bit", nullable: true),
                    KARPEG = table.Column<bool>(type: "bit", nullable: true),
                    SKCPNS = table.Column<bool>(type: "bit", nullable: true),
                    SKPEG = table.Column<bool>(type: "bit", nullable: true),
                    SKPANGKAT = table.Column<bool>(type: "bit", nullable: true),
                    SKBERKALA = table.Column<bool>(type: "bit", nullable: true),
                    SKPENSIUN = table.Column<bool>(type: "bit", nullable: true),
                    SKKARIP = table.Column<bool>(type: "bit", nullable: true),
                    SKTASPEN = table.Column<bool>(type: "bit", nullable: true),
                    SKPENGANGKATAN = table.Column<bool>(type: "bit", nullable: true),
                    MAXTHNSBLMPENSIUN = table.Column<bool>(type: "bit", nullable: true),
                    SHOW_TPLDESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KODEDINAS = table.Column<bool>(type: "bit", nullable: true),
                    LAMAKERJA = table.Column<bool>(type: "bit", nullable: true),
                    NIK = table.Column<bool>(type: "bit", nullable: true),
                    GAJIATBJB = table.Column<bool>(type: "bit", nullable: true),
                    SKTERAKHIR = table.Column<bool>(type: "bit", nullable: true),
                    GRD_CODE = table.Column<bool>(type: "bit", nullable: false),
                    SKASABRI = table.Column<bool>(type: "bit", nullable: true),
                    NIK_FIELDNAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PENSIUNTHT = table.Column<bool>(type: "bit", nullable: true),
                    NRP = table.Column<bool>(type: "bit", nullable: true),
                    TGLPENGANGKATAN = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfJobFieldTpls", x => x.SHOW_TPL);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfJobFieldTpls");
        }
    }
}
