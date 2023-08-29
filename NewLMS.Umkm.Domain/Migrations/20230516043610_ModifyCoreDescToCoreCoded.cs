using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyCoreDescToCoreCoded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOSCORINGAGUNAN",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOSALDOREKRATA",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCORiwayatKreditBJBs",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOREPUTASITEMPATTINGGAL",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOPENGELOLAKEUANGAN",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOMUTASIPERBULAN",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOLOKTEMPATUSAHA",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOHUTANGPIHAKLAIN",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOHUBUNGANPERBANKAN",
                newName: "CORE_CODE");

            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFEDUCATION",
                newName: "CORE_CODE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOSCORINGAGUNAN",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOSALDOREKRATA",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCORiwayatKreditBJBs",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOREPUTASITEMPATTINGGAL",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOPENGELOLAKEUANGAN",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOMUTASIPERBULAN",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOLOKTEMPATUSAHA",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOHUTANGPIHAKLAIN",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOHUBUNGANPERBANKAN",
                newName: "CORE_DESC");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFEDUCATION",
                newName: "CORE_DESC");
        }
    }
}
