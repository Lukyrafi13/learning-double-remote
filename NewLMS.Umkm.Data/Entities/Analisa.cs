using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NewLMS.Umkm.Data
{
    public class Analisa : BaseEntity
    {
        public Guid Id { get; set; }
        
        [ForeignKey("AppId")]
        public App App { get; set; }
        [ForeignKey("PrescreeningId")]
        public Prescreening Prescreening { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

        // Informasi Usaha
        public bool? AlamatUsahaSamaDenganAplikasi { get; set; }
        [ForeignKey("RFLokasiUsahaId")]
        public RFLokasiUsaha LokasiUsaha { get; set; }
        public double? JarakLokasiUsahaDariCabang { get; set; }
        [ForeignKey("RFJenisTempatUsahaId")]
        public RFJenisTempatUsaha JenisTempatUsaha { get; set; }
        public string PerijinanYangDimiliki { get; set; }
        [ForeignKey("RFKelompokUsahaId")]
        public RFKelompokUsaha KelompokBidangUsaha { get; set; }
        [ForeignKey("RFJenisUsahaId")]
        public RFJenisUsaha JenisUsaha { get; set; }
        [ForeignKey("RFLokasiTempatUsahaId")]
        public RFLokasiTempatUsaha LokasiTempatUsaha { get; set; }
        [ForeignKey("RFKepemilikanTUId")]
        public RFKepemilikanTU KepemilikanTU { get; set; }
        [ForeignKey("RFBuktiKepemilikanId")]
        public RFBuktiKepemilikan BuktiKepemilikan { get; set; }
        public string BuktiKepemilikanLainnya { get; set; }
        public string Nomor { get; set; }
        public bool? RACMemilikiUsaha { get; set; }
        [ForeignKey("RFAspekPemasaranId")]
        public RFAspekPemasaran AspekPemasaran { get; set; }
        [ForeignKey("RFJumlahPegawaiTetapId")]
        public RFJumlahPegawai JumlahPegawaiTetap { get; set; }
        [ForeignKey("RFJumlahPegawaiHarianId")]
        public RFJumlahPegawai JumlahPegawaiHarian { get; set; }
        public int? LamaUsaha { get; set; }
        public int? LamaUsahaBidangIni { get; set; }
        public int? LamaMenempatiTempatUsaha { get; set; }
        public bool? MemilikiUsahaLain { get; set; }
        public string NamaUsahaLain { get; set; }
        public bool? UsahaTidakTermasukJenisDihindari { get; set; }
        public string AktifitasUsaha { get; set; }

        // Hubungan dengan Bank
        public bool? DPD3BulanTerakhir { get; set; }
        public string AlasanKeterlambatan { get; set; }

        // Kemampuan Membayar
        public double? PenghasilanLainnya { get; set; }
        public double? PendapatanUsaha => Survey != null ? Survey.OmsetDiambil??0 : 0;
        public double? HargaPokokPenjualan => Survey != null ? Survey.HPPNilai??0 : 0;
        public double? PengeluaranUsaha => Survey != null ? Survey.TotalBiayaUsaha??0 : 0;
        public double? TotalPengeluaranRT => Survey != null ? Survey.BiayaRumahTanggaTertinggi??0 : 0;
        public double? KeutunganUsaha => PendapatanUsaha - HargaPokokPenjualan - PengeluaranUsaha;
        public double? TotalPenghasilan => KeutunganUsaha + (PenghasilanLainnya??0);
        public double? SisaPenghasilan => TotalPenghasilan - TotalPengeluaranRT;
        public double? GPM => (PendapatanUsaha - HargaPokokPenjualan) / PendapatanUsaha * 100;
        public double? NOP => KeutunganUsaha / PendapatanUsaha * 100;
        public double? PL => (PenghasilanLainnya??0) / PendapatanUsaha * 100;
        public double? NI => SisaPenghasilan / PendapatanUsaha * 100;
        public double? PRT => TotalPengeluaranRT / TotalPenghasilan * 100;
        
        // Analisa Kemempuan Membayar Siklus
        
        [ForeignKey("RFKepemilikanUsahaId")]
        public RFKepemilikanUsaha KepemilikanTempatUsaha { get; set; }
        [ForeignKey("RFLamaUsahaLainId")]
        public RFLamaUsahaLain LamaMenempatiLokasi { get; set; }
        public bool? DibiayaiSesuaiTarget { get; set; }
        public bool? LokasiUsahaDalamRadius { get; set; }
        public bool? BerjalanLebihEnamBulan { get; set; }
        public bool? MilikCalonDebitur { get; set; }
        public bool? TidakMasukDaftarHitam { get; set; }
        public bool? KolektibilitasLancar { get; set; }
        public double? PendapatanBersihUsahaLainnya { get; set; }
        public double? TotalPendapatan => GetPendapatanSiklus();
        public double? TotalBiaya => GetBiayaSiklus();
        public double? TotalBiayaOperasional => TotalBiayaTetap + TotalBiayaVariabel;
        public double? TotalBiayaTetap => GetBiayaTetap();
        public double? TotalBiayaVariabel => GetBiayaVariabel();
        public double? SaldoAkhir => TotalPendapatan - TotalBiayaOperasional;
        public double? TotalAngsuran => GetTotalAngsuran();
        public double? RekomendasiAngsuran => GetRekomendasiAngsuran();
        public double? RCR => TotalPendapatan/TotalBiayaOperasional;
        public double? BCR => SaldoAkhir/TotalBiayaOperasional;
        public double? BEP => TotalBiayaTetap/(1 - TotalBiayaVariabel/TotalPendapatan);
        public double? DSR => (TotalAngsuran + RekomendasiAngsuran)/ (TotalPendapatan + PendapatanBersihUsahaLainnya) * 100;

        // Nilai Hasil Rekomendasi
        public double? ModalSudahDibiayai { get; set; }
        public double? PerputaranPiutangDagang => Survey != null ? (Survey.ModalKerjaPiutang??0)/(Survey.OmsetDiambil??0) *30 : 0.00;
        public double? PerputaranPersediaanBarang => Survey != null ? (Survey.ModalKerjaStokBarang??0)/(Survey.HPPNilai??0) *30 : 0.00;
        public double? PerputaranHutangDagang => Survey != null ? (Survey.ModalKerjaHutang??0)/(Survey.HPPNilai??0) *30 : 0.00;
        public double? PerputaranModalKerja => PerputaranPiutangDagang + PerputaranPersediaanBarang - PerputaranHutangDagang;
        public double? KebutuhanModalKerjaNormal => PerputaranModalKerja/30 * HargaPokokPenjualan;
        public double? MaxModalKerja => KebutuhanModalKerjaNormal - (ModalSudahDibiayai??0.00);
        public DateTime? TanggalRencanaPencairan { get; set; }
        public bool? BacaDanSetuju { get; set; }
        public string Covenant { get; set; }

        // Informasi Pencairan
        [ForeignKey("RFCaraPengikatanId")]
        public RFCaraPengikatan CaraPenarikan { get; set; }
        [ForeignKey("RFPengikatanKreditId")]
        public RFPengikatanKredit PengikatanKredit { get; set; }
        [ForeignKey("RFPolaPengembalianAngsuranId")]
        public RFPolaPengembalian PolaPengembalianKredit { get; set; }
        [ForeignKey("RFBranchesCode")]
        public RfBranches BookingOffice { get; set; }
        [ForeignKey("SlikRequestId")]
        public SlikRequest SlikRequest { get; set; }
        public double? Provisi { get; set; }
        public double? NilaiProvisi => NilaiPertanggungan * Provisi/100;
        public double? BiayaAdmin { get; set; }
        public double? NilaiPertanggungan => GetPertanggungan();
        public double? TotalBiayaAsuransi { get; set; }
        public bool? IsLossInsurance { get; set; }
        public bool? IsLifeInsurance { get; set; }
        public bool? IsCreditInsurance { get; set; }

        // Compliance Sheet
        public DateTime? PeriodeBMPK { get; set; }
        public DateTime? PeriodeSBDK { get; set; }
        public double? ModalBank { get; set; }
        public double? ModalInti { get; set; }
        public double? BMPK { get; set; }
        public double? BMPKBUMN { get; set; }
        public double? Inhouse { get; set; }
        public double? PenyediaanDanaBesar { get; set; }

        public double? HPDKKorporasi { get; set; }
        public double? HPDKRitel { get; set; }
        public double? HPDKMikro { get; set; }
        public double? HPDKKPR { get; set; }
        public double? HPDKNonKPR { get; set; }
        public double? BOKorporasi { get; set; }
        public double? BORitel { get; set; }
        public double? BOMikro { get; set; }
        public double? BOKPR { get; set; }
        public double? BONonKPR { get; set; }
        public double? MKKorporasi { get; set; }
        public double? MKRitel { get; set; }
        public double? MKMikro { get; set; }
        public double? MKKPR { get; set; }
        public double? MKNonKPR { get; set; }
        public double? SBDKKorporasi => HPDKKorporasi + BOKorporasi + MKKorporasi;
        public double? SBDKRitel => HPDKRitel + BORitel + MKRitel;
        public double? SBDKMikro => HPDKMikro + BOMikro + MKMikro;
        public double? SBDKKPR => HPDKKPR + BOKPR + MKKPR;
        public double? SBDKNonKPR => HPDKNonKPR + BONonKPR + MKNonKPR;
        public int Age => App?.Prospect?.AgeStage("5.0")??-1;

        public ICollection<AnalisaFasilitas> AnalisaFasilitass { get; set; }
        public ICollection<AnalisaPinjamanDariBank> AnalisaPinjamanDariBanks { get; set; }


        [ForeignKey("RFCSBPDetailHubunganId")]
        public RFCSBPDetail HubunganBank { get; set; }
        [ForeignKey("RFCSBPDetailPengecekanId")]
        public RFCSBPDetail PengecekanBJB { get; set; }
        [ForeignKey("RFCSBPDetailProfileId")]
        public RFCSBPDetail ProfileNasabah { get; set; }
        [ForeignKey("RFCSBPDetailBenturanId")]
        public RFCSBPDetail BenturanKepentingan { get; set; }
        public DateTime? TanggalPengecekan { get; set; }

        public Guid AppId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? SurveyId { get; set; }
        public Guid? RFLokasiUsahaId { get; set; }
        public Guid? RFJenisTempatUsahaId { get; set; }
        public Guid? RFKelompokUsahaId { get; set; }
        public Guid? RFJenisUsahaId { get; set; }
        public Guid? RFLokasiTempatUsahaId { get; set; }
        public Guid? RFKepemilikanTUId { get; set; }
        public Guid? RFBuktiKepemilikanId { get; set; }
        public Guid? RFAspekPemasaranId { get; set; }
        public Guid? RFJumlahPegawaiTetapId { get; set; }
        public Guid? RFJumlahPegawaiHarianId { get; set; }

        // Informasi Pencairan
        public Guid? RFCaraPengikatanId { get; set; }
        public Guid? RFPengikatanKreditId { get; set; }
        public Guid? RFPolaPengembalianAngsuranId { get; set; }
        public Guid? SlikRequestId { get; set; }
        public string RFBranchesCode { get; set; }

        // Compliance Sheet
        public Guid? RFCSBPDetailHubunganId { get; set; }
        public Guid? RFCSBPDetailPengecekanId { get; set; }
        public Guid? RFCSBPDetailProfileId { get; set; }
        public Guid? RFCSBPDetailBenturanId { get; set; }

        // Hasil analisa siklus
        public Guid? RFKepemilikanUsahaId {get; set;}
        public Guid? RFLamaUsahaLainId {get; set;}

        public double GetPertanggungan(){
            var nilai = 0.00;

            if (AnalisaFasilitass == null){
                return nilai;
            }

            foreach (var fasilitas in AnalisaFasilitass)
            {
                nilai += fasilitas.Fasilitas??fasilitas.AppFasilitasKredit?.PlafondYangDiajukan??0;
            }

            return nilai;
        }

        private double GetPendapatanSiklus(){
            var res = 0.00;

            if (Survey == null){
                return res;
            }

            if (Survey?.ArusKasMasuks == null){
                return res;
            }
            
            foreach (var ArusKasMasuk in Survey?.ArusKasMasuks)
            {
                res += ArusKasMasuk?.Total??0;
            }

            return res;
        }
        private double GetBiayaSiklus(){
            var res = 0.00;

            if (Survey == null){
                return res;
            }

            // Investasi
            if (Survey?.BiayaInvestasis != null){
                res += Survey?.BiayaInvestasis?.Sum(x=>x.Total)??0;
            }

            return res + (TotalBiayaOperasional??0);
        }

        private double GetBiayaVariabel(){
            var res = 0.00;

            if (Survey == null){
                return res;
            }
            // Variabel
            if (Survey?.BiayaVariabels != null){
                res += Survey?.BiayaVariabels?.Sum(x=>x.Total)??0;
            }
            // Variabel TK
            if (Survey?.BiayaVariabelTenagaKerjas != null){
                res += Survey?.BiayaVariabelTenagaKerjas?.Sum(x=>x.Total)??0;
            }

            return res;
        }

        private double GetBiayaTetap(){
            var res = 0.00;

            if (Survey == null){
                return res;
            }
            // Tetap
            if (Survey?.BiayaTetaps != null){
                res += Survey?.BiayaTetaps?.Sum(x=>x.Total)??0;
            }

            return res;
        }

        private double GetTotalAngsuran(){
            var res = 0.00;

            // Tetap
            if (AnalisaPinjamanDariBanks != null){
                res += AnalisaPinjamanDariBanks?.Sum(x=>x.Angsuran)??0;
            }

            return res;
        }

        public double GetRekomendasiAngsuran(){
            var nilai = 0.00;

            if (AnalisaFasilitass == null){
                return nilai;
            }

            foreach (var fasilitas in AnalisaFasilitass)
            {
                nilai += fasilitas.Angsuran??fasilitas.AppFasilitasKredit?.Angsuran??0;
            }

            return nilai;
        }

    }
}
