using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class PersiapanAkadAsuransi : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("PersiapanAkadId")]
        public PersiapanAkad PersiapanAkad { get; set; }

        [ForeignKey("RFJenisAsuransiId")]
        public RFJenisAsuransi JenisAsuransi { get; set; }

        public double? NilaiPertanggungan { get; set; }
        public double? Premi { get; set; }
        public double? NomorPolis { get; set; }
        public int? JangkaWaktuPertanggungan { get; set; }
        public string ObjekPertanggunganJiwa { get; set; }
        public string ObjekPertanggunganLainnya { get; set; }

        [ForeignKey("RFColLateralBCId")]
        public RFColLateralBC ObjekPertanggunganKerugian { get; set; }

        
        public Guid PersiapanAkadId { get; set; }
        public Guid? RFJenisAsuransiId { get; set; }
        public Guid? RFColLateralBCId { get; set; }
    }
}
