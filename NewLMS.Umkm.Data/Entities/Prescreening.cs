using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class Prescreening : BaseEntity
    {
        public Guid Id { get; set; }
        
        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        [ForeignKey("SlikRequestId")]
        public SlikRequest SlikRequest { get; set; }

        public bool? RACUsiaMin { get; set; }
        public bool? RACUsiaMax { get; set; }
        public bool? RACeKTP { get; set; }
        public bool? RACNonDaftarHitam { get; set; }
        public bool? RACKolektibilitas1 { get; set; }
        public bool? RACTidakKolektibilitas345 { get; set; }
        public bool? RACMemilikiUsaha { get; set; }
        public bool? RACTidakMemilikiFasilitasKreditLain { get; set; }
        public bool? TidakPernahMenerimaKredit { get; set; }
        public bool? PesertaBPJSTK { get; set; }

        public Guid LoanApplicationId { get; set; }
        public Guid? SlikRequestId { get; set; }
    }
}
