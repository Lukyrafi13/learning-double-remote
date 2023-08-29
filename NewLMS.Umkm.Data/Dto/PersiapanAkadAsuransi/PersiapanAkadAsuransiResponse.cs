using System;
namespace NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis
{
    public class PersiapanAkadAsuransiResponseDto
    {
        public Guid Id { get; set; }

        public PersiapanAkad PersiapanAkad { get; set; }
        public RFJenisAsuransi JenisAsuransi { get; set; }
        
        public double? NilaiPertanggungan { get; set; }
        public double? Premi { get; set; }
        public double? NomorPolis { get; set; }
        public int? JangkaWaktuPertanggungan { get; set; }
        public string ObjekPertanggunganJiwa { get; set; }
        public string ObjekPertanggunganLainnya { get; set; }

        public RFColLateralBC ObjekPertanggunganKerugian { get; set; }

        
        public Guid PersiapanAkadId { get; set; }
        public Guid? RFJenisAsuransiId { get; set; }
        public Guid? RFColLateralBCId { get; set; }
    }
}
