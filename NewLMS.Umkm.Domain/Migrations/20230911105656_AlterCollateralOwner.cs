using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterCollateralOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfEducations_RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfGenders_GenderId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfJobs_JobCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_ResidenceStatusId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollateralOwners_GenderId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollateralOwners_JobCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollateralOwners_RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "JobCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "NumberOfDependents",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.RenameColumn(
                name: "ResidenceStatusId",
                table: "LoanApplicationCollateralOwners",
                newName: "RfZipCodeIdOwnerCouple");

            migrationBuilder.RenameColumn(
                name: "ResidenceLiveTime",
                table: "LoanApplicationCollateralOwners",
                newName: "RelationCollateralId");

            migrationBuilder.RenameColumn(
                name: "RelationCollateral",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleProvince");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCouplePlaceOfBirth");

            migrationBuilder.RenameColumn(
                name: "MotherName",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleNoIdentity");

            migrationBuilder.RenameColumn(
                name: "MarriageCertificateNumber",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleNeighborhoods");

            migrationBuilder.RenameColumn(
                name: "MarriageCertificateIssuer",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleName");

            migrationBuilder.RenameColumn(
                name: "MarriageCertificateDate",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleIdentityExpiredDate");

            migrationBuilder.RenameColumn(
                name: "IdentityLifetime",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleIdentityLifetime");

            migrationBuilder.RenameColumn(
                name: "IdentityExpiredDate",
                table: "LoanApplicationCollateralOwners",
                newName: "OwnerCoupleDateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplicationCollateralOwners_ResidenceStatusId",
                table: "LoanApplicationCollateralOwners",
                newName: "IX_LoanApplicationCollateralOwners_RfZipCodeIdOwnerCouple");

            migrationBuilder.AddColumn<bool>(
                name: "AddressSameAsIdentity",
                table: "LoanApplicationCollateralOwners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherRelationCollateral",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerCoupleAddress",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerCoupleCity",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerCoupleDistrict",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerCoupleJob",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerCoupleNPWP",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OwnerIsDebtor",
                table: "LoanApplicationCollateralOwners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RelationCollateralId",
                table: "LoanApplicationCollateralOwners",
                column: "RelationCollateralId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RelationCollateralId",
                table: "LoanApplicationCollateralOwners",
                column: "RelationCollateralId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfZipCodes_RfZipCodeIdOwnerCouple",
                table: "LoanApplicationCollateralOwners",
                column: "RfZipCodeIdOwnerCouple",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RelationCollateralId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfZipCodes_RfZipCodeIdOwnerCouple",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollateralOwners_RelationCollateralId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "AddressSameAsIdentity",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OtherRelationCollateral",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerCoupleAddress",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerCoupleCity",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerCoupleDistrict",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerCoupleJob",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerCoupleNPWP",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "OwnerIsDebtor",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.RenameColumn(
                name: "RfZipCodeIdOwnerCouple",
                table: "LoanApplicationCollateralOwners",
                newName: "ResidenceStatusId");

            migrationBuilder.RenameColumn(
                name: "RelationCollateralId",
                table: "LoanApplicationCollateralOwners",
                newName: "ResidenceLiveTime");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleProvince",
                table: "LoanApplicationCollateralOwners",
                newName: "RelationCollateral");

            migrationBuilder.RenameColumn(
                name: "OwnerCouplePlaceOfBirth",
                table: "LoanApplicationCollateralOwners",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleNoIdentity",
                table: "LoanApplicationCollateralOwners",
                newName: "MotherName");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleNeighborhoods",
                table: "LoanApplicationCollateralOwners",
                newName: "MarriageCertificateNumber");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleName",
                table: "LoanApplicationCollateralOwners",
                newName: "MarriageCertificateIssuer");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleIdentityLifetime",
                table: "LoanApplicationCollateralOwners",
                newName: "IdentityLifetime");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleIdentityExpiredDate",
                table: "LoanApplicationCollateralOwners",
                newName: "MarriageCertificateDate");

            migrationBuilder.RenameColumn(
                name: "OwnerCoupleDateOfBirth",
                table: "LoanApplicationCollateralOwners",
                newName: "IdentityExpiredDate");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplicationCollateralOwners_RfZipCodeIdOwnerCouple",
                table: "LoanApplicationCollateralOwners",
                newName: "IX_LoanApplicationCollateralOwners_ResidenceStatusId");

            migrationBuilder.AddColumn<string>(
                name: "GenderId",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCode",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDependents",
                table: "LoanApplicationCollateralOwners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_GenderId",
                table: "LoanApplicationCollateralOwners",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_JobCode",
                table: "LoanApplicationCollateralOwners",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners",
                column: "RfEducationEducationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfEducations_RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners",
                column: "RfEducationEducationCode",
                principalTable: "RfEducations",
                principalColumn: "EducationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfGenders_GenderId",
                table: "LoanApplicationCollateralOwners",
                column: "GenderId",
                principalTable: "RfGenders",
                principalColumn: "GenderCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfJobs_JobCode",
                table: "LoanApplicationCollateralOwners",
                column: "JobCode",
                principalTable: "RfJobs",
                principalColumn: "JobCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_ResidenceStatusId",
                table: "LoanApplicationCollateralOwners",
                column: "ResidenceStatusId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }
    }
}
