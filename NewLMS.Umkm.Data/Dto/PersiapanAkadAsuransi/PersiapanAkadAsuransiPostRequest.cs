using System;

namespace NewLMS.UMKM.Data.Dto.PersiapanAkadAsuransis
{
    public class PersiapanAkadAsuransiPostRequestDto
    {
        public double? NilaiPertanggungan { get; set; }
        public double? Premi { get; set; }
        public double? NomorPolis { get; set; }
        public int? JangkaWaktuPertanggungan { get; set; }
        public string ObjekPertanggunganJiwa { get; set; }
        public string ObjekPertanggunganLainnya { get; set; }
        
        public Guid PersiapanAkadId { get; set; }
        public Guid? RFJenisAsuransiId { get; set; }
        public Guid? RFColLateralBCId { get; set; }
    }
}
