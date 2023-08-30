using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class Approval : BaseEntity
    {
        public Guid Id { get; set; }
        
        [ForeignKey("AppId")]
        public LoanApplication LoanApplication { get; set; }
        [ForeignKey("PrescreeningId")]
        public Prescreening Prescreening { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }

        [ForeignKey("SlikRequestId")]
        public SlikRequest SlikRequest { get; set; }

        public bool? BacaDanSetuju { get; set; }
        public string Covenant { get; set; }

        public Guid AppId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? SurveyId { get; set; }
        public Guid? AnalisaId { get; set; }
        public Guid? SlikRequestId { get; set; }
    }
}
