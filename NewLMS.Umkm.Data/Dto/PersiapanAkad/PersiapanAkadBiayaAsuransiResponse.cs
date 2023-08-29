using System;
namespace NewLMS.Umkm.Data.Dto.PersiapanAkads
{
    public class PersiapanAkadBiayaAsuransiResponse : PersiapanAkadBiayaAsuransiPut
    {
        public double? NilaiProvisi { get; set; }
        public double? NilaiPertanggungan { get; set; }
        public double? BiayaAsuransi { get; set; }
        public double? BiayaAdmin { get; set; }

    }
}
