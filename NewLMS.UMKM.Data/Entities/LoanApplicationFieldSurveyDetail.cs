using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationFieldSurveyDetail : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string FieldSurveyDetail { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProductType { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; }

        public int StandingBusiness { get; set; }


        public virtual RfParameterDetail PaymentMethod { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}
