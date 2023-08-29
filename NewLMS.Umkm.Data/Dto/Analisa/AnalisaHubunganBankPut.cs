using System;
namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaHubunganBankPut
    {
        public Guid Id { get; set; }
        
        public bool? DPD3BulanTerakhir { get; set; }
        public string AlasanKeterlambatan { get; set; }

    }
}
