using System;
namespace NewLMS.UMKM.Data.Dto.PersiapanAkads
{
    public class PersiapanAkadBiayaAsuransiPut
    {
        public Guid Id { get; set; }
        public string NamaBroker { get; set; }
        public string JenisCoverage { get; set; }
        public double? PremiAsuransi { get; set; }
        public double? Provisi { get; set; }
    }
}
