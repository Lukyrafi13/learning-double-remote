using System;

namespace NewLMS.Umkm.Data.Dto.Surveys
{
    public class SurveyVerifikasiPut
    {
        public Guid Id { get; set; }
        public double? OmsetWawancara { get; set; }
        public double? OmsetObservasi { get; set; }
        public double? OmsetData { get; set; }
        public double? OmsetDiambil { get; set; }
        public double? PenjualanTahunan { get; set; }
        public double? KekayaanBersihDiluarTempatUsaha { get; set; }
        public string DasarPertimbangan { get; set; }
        public double? GPMWawancara { get; set; }
        public double? GPMObservasi { get; set; }
        public double? GPMStandar { get; set; }
        public double? BiayaTenagaKerja { get; set; }
        public double? BiayaListrik { get; set; }
        public double? BiayaAir { get; set; }
        public double? BiayaTelpon { get; set; }
        public double? BiayaHP { get; set; }
        public double? BiayaOperasional { get; set; }
        public double? BiayaRumahTanggaWawancara { get; set; }
        public double? BiayaRumahTanggaHasilVerifikasi { get; set; }
        public double? ModalKerjaStokBarang { get; set; }
        public double? ModalKerjaPiutang { get; set; }
        public double? ModalKerjaHutang { get; set; }
        public bool? SesuaiTargetMarket { get; set; }
        public bool? MasukRadiusCabang { get; set; }
        public bool? UsahaMilikSendiri { get; set; }
        public string KesimpulanHasil { get; set; }
        
        public Guid? RFKepemilikanUsahaId { get; set; }
        public Guid? RFLamaUsahaLainId { get; set; }
    }
}
