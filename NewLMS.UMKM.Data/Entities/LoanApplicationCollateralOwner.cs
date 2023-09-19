using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationCollateralOwner : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplicationCollateral))]
        [Required]
        public Guid Id { get; set; }

        public bool OwnerIsDebtor { get; set; }

        [ForeignKey(nameof(RfRelationCollateral))]
        public int? RelationCollateralId { get; set; }

        public string OtherRelationCollateral { get; set; }

        public string OwnerName { get; set; }
        public string OwnerNoIdentity { get; set; }
        public string OwnerPlaceOfBirth { get; set; }
        public DateTime? OwnerDateOfBirth { get; set; }
        public bool OwnerIdentityLifetime { get; set; }
        public DateTime? OwnerIdentityExpireDate { get; set; }
        public bool AddressSameAsIdentity { get; set; }
        public string Address { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }

        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }

        [ForeignKey(nameof(RfMarital))]
        public string? OwnerMaritalId { get; set; }

        public string OwnerEmergencyName { get; set; }
        public string OwnerEmegencyNumber { get; set; }

        //Data Pasangan
        public string OwnerCoupleName { get; set; }
        public string OwnerCouplePlaceOfBirth { get; set; }
        public DateTime? OwnerCoupleDateOfBirth { get; set; }
        public string OwnerCoupleNoIdentity { get; set; }
        public DateTime? OwnerCoupleIdentityExpiredDate { get; set; }
        public bool? OwnerCoupleIdentityLifetime { get; set; }
        public string OwnerCoupleAddress { get; set; }
        public string OwnerCoupleProvince { get; set; }
        public string OwnerCoupleCity { get; set; }
        public string OwnerCoupleDistrict { get; set; }
        public string OwnerCoupleNeighborhoods { get; set; }

        [ForeignKey(nameof(RfZipCodeOwnerCouple))]
        public int? RfZipCodeIdOwnerCouple { get; set; }

        public string OwnerCoupleNPWP { get; set; }
        public string OwnerCoupleJob { get; set; }
        

        public virtual LoanApplicationCollateral LoanApplicationCollateral { get; set; }
        public virtual RfParameterDetail RfRelationCollateral { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
        public virtual RfMarital RfMarital { get; set; }
        public virtual RfZipCode RfZipCodeOwnerCouple { get; set; }
        
    }
}

