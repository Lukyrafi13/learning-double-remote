using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationFieldSurvey : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey(nameof(LoanApplication))]
        public Guid Id { get; set; }

        public DateTime? SurveyDate { get; set; }

        public string SurveyorName { get; set; }
        
        public string VerifierName { get; set; }
        
        public string Informan { get; set; }

        [ForeignKey(nameof(RelationsWithDebtors))]
        public int? RelationsWithDebtorsId { get; set; }
        
        //Bentuk Badan Usaha
        [ForeignKey(nameof(OwnerCategory))]
        public int? OwnerCategoryId { get; set; }

        public string BusinessName { get; set; }
        
        public string BusinessPhone { get; set; }

        [ForeignKey(nameof(BusinessLocationStatus))]
        public int? BusinessLocationStatusId { get; set; }
        
        public int? YearStandingBusiness { get; set; }
        public int? MonthStandingBusiness { get; set; }
        public int? NumberOfEmployees { get; set; }
        public int? NumberOfBranches { get; set; }
        //Bidang Usaha
        [ForeignKey(nameof(BusinessFieldKUR))]
        public string BusinessFieldKURId { get; set; }
        
        public bool AddressSameAsDebtor { get; set; }

        public string SurveyAddress { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int? ZipCodeId { get; set; }
        
        public string ConclusionVerification { get; set; }
        
        
        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfParameterDetail RelationsWithDebtors { get; set; }
        public virtual RfParameterDetail OwnerCategory { get; set; }
        public virtual RfParameterDetail BusinessLocationStatus { get; set; }
        public virtual RfBusinessFieldKUR BusinessFieldKUR { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
        
        /*public virtual ICollection<SurveySupplier> SurveySupplier { get; set; }
        public virtual ICollection<SurveyBuyer> SurveyBuyer { get; set; }*/
        //public virtual ICollection<Document> Document { get; set; }
    }
}
