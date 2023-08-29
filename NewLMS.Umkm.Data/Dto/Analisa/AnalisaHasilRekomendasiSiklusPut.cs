using System;

namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaHasilRekomendasiSiklusPut
    {
        public Guid Id { get; set; }

        public DateTime? TanggalRencanaPencairan { get; set; }
        public bool? DibiayaiSesuaiTarget { get; set; }
        public bool? LokasiUsahaDalamRadius { get; set; }
        public bool? BerjalanLebihEnamBulan { get; set; }
        public bool? MilikCalonDebitur { get; set; }
        public bool? TidakMasukDaftarHitam { get; set; }
        public bool? KolektibilitasLancar { get; set; }
        public double? PendapatanBersihUsahaLainnya { get; set; }
        
        public Guid? RFKepemilikanUsahaId {get; set;}
        public Guid? RFLamaUsahaLainId {get; set;}

    }
}
