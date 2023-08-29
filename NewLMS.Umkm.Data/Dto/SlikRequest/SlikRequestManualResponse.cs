using Newtonsoft.Json;

namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestManualResponse
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("individual")]
        public Individual Individual { get; set; }
    }

    public  class Header
    {
        [JsonProperty("kodeReferensiPengguna")]
        public string KodeReferensiPengguna { get; set; }

        [JsonProperty("tanggalHasil")]
        public string TanggalHasil { get; set; }

        [JsonProperty("idPermintaan")]

        public int IdPermintaan { get; set; }

        [JsonProperty("idPenggunaPermintaan")]

        public int IdPenggunaPermintaan { get; set; }

        [JsonProperty("dibuatOleh")]
        public string DibuatOleh { get; set; }

        [JsonProperty("kodeLJKPermintaan")]

        public int KodeLjkPermintaan { get; set; }

        [JsonProperty("kodeCabangPermintaan")]
        public string KodeCabangPermintaan { get; set; }

        [JsonProperty("kodeTujuanPermintaan")]
        public string KodeTujuanPermintaan { get; set; }

        [JsonProperty("tanggalPermintaan")]
        public string TanggalPermintaan { get; set; }

        [JsonProperty("totalBagian")]

        public int TotalBagian { get; set; }

        [JsonProperty("nomorBagian")]

        public int NomorBagian { get; set; }
    }

    public  class Individual
    {
        [JsonProperty("nomorLaporan")]
        public string NomorLaporan { get; set; }

        [JsonProperty("posisiDataTerakhir")]

        public int PosisiDataTerakhir { get; set; }

        [JsonProperty("tanggalPermintaan")]
        public string TanggalPermintaan { get; set; }

        [JsonProperty("parameterPencarian")]
        public ParameterPencarian ParameterPencarian { get; set; }

        [JsonProperty("dataPokokDebitur")]
        public DataPokokDebitur[] DataPokokDebitur { get; set; }

        [JsonProperty("ringkasanFasilitas")]
        public RingkasanFasilitas RingkasanFasilitas { get; set; }

        [JsonProperty("fasilitas")]
        public Fasilitas Fasilitas { get; set; }
    }

    public  class DataPokokDebitur
    {
        [JsonProperty("namaDebitur")]
        public string NamaDebitur { get; set; }

        [JsonProperty("identitas")]

        public int Identitas { get; set; }

        [JsonProperty("noIdentitas")]
        public string NoIdentitas { get; set; }

        [JsonProperty("alamat")]
        public string Alamat { get; set; }

        [JsonProperty("jenisKelamin")]
        public string JenisKelamin { get; set; }

        [JsonProperty("jenisKelaminKet")]
        public string JenisKelaminKet { get; set; }

        [JsonProperty("npwp")]
        public string Npwp { get; set; }

        [JsonProperty("tempatLahir")]
        public string TempatLahir { get; set; }

        [JsonProperty("tanggalLahir")]

        public int TanggalLahir { get; set; }

        [JsonProperty("pelapor")]
        public string Pelapor { get; set; }

        [JsonProperty("pelaporKet")]
        public string PelaporKet { get; set; }

        [JsonProperty("tanggalDibentuk")]
        public string TanggalDibentuk { get; set; }

        [JsonProperty("tanggalUpdate")]
        public string TanggalUpdate { get; set; }

        [JsonProperty("kelurahan")]
        public string Kelurahan { get; set; }

        [JsonProperty("kecamatan")]
        public string Kecamatan { get; set; }

        [JsonProperty("kabKota")]
        public string KabKota { get; set; }

        [JsonProperty("kabKotaKet")]
        public string KabKotaKet { get; set; }

        [JsonProperty("kodePos")]

        public int KodePos { get; set; }

        [JsonProperty("negara")]
        public string Negara { get; set; }

        [JsonProperty("negaraKet")]
        public string NegaraKet { get; set; }

        [JsonProperty("pekerjaan")]
        public string Pekerjaan { get; set; }

        [JsonProperty("pekerjaanKet")]
        public string PekerjaanKet { get; set; }

        [JsonProperty("tempatBekerja")]
        public string TempatBekerja { get; set; }

        [JsonProperty("bidangUsaha")]
        public string BidangUsaha { get; set; }

        [JsonProperty("bidangUsahaKet")]
        public string BidangUsahaKet { get; set; }

        [JsonProperty("kodeGelarDebitur")]
        public string KodeGelarDebitur { get; set; }

        [JsonProperty("statusGelarDebitur")]
        public string StatusGelarDebitur { get; set; }
    }

    public  class Fasilitas
    {
        [JsonProperty("kreditPembiayan")]
        public KreditPembiayan[] KreditPembiayan { get; set; }

        [JsonProperty("lc")]
        public object[] Lc { get; set; }

        [JsonProperty("garansiYgDiberikan")]
        public object[] GaransiYgDiberikan { get; set; }

        [JsonProperty("fasilitasLain")]
        public object[] FasilitasLain { get; set; }
    }

    public  class KreditPembiayan
    {
        [JsonProperty("ljk")]
        public string Ljk { get; set; }

        [JsonProperty("ljkKet")]
        public string LjkKet { get; set; }

        [JsonProperty("cabang")]
        public string Cabang { get; set; }

        [JsonProperty("cabangKet")]
        public string CabangKet { get; set; }

        [JsonProperty("bakiDebet")]

        public int BakiDebet { get; set; }

        [JsonProperty("tanggalDibentuk")]
        public string TanggalDibentuk { get; set; }

        [JsonProperty("tanggalUpdate")]
        public string TanggalUpdate { get; set; }

        [JsonProperty("bulan")]
        public string Bulan { get; set; }

        [JsonProperty("tahun")]

        public int Tahun { get; set; }

        [JsonProperty("sifatKreditPembiayaan")]

        public int SifatKreditPembiayaan { get; set; }

        [JsonProperty("sifatKreditPembiayaanKet")]
        public string SifatKreditPembiayaanKet { get; set; }

        [JsonProperty("jenisKreditPembiayaan")]
        public string JenisKreditPembiayaan { get; set; }

        [JsonProperty("jenisKreditPembiayaanKet")]
        public string JenisKreditPembiayaanKet { get; set; }

        [JsonProperty("akadKreditPembiayaan")]
        public string AkadKreditPembiayaan { get; set; }

        [JsonProperty("akadKreditPembiayaanKet")]
        public string AkadKreditPembiayaanKet { get; set; }

        [JsonProperty("noRekening")]
        public string NoRekening { get; set; }

        [JsonProperty("frekPerpjganKreditPembiayaan")]

        public int FrekPerpjganKreditPembiayaan { get; set; }

        [JsonProperty("noAkadAwal")]
        public string NoAkadAwal { get; set; }

        [JsonProperty("tanggalAkadAwal")]
        public string TanggalAkadAwal { get; set; }

        [JsonProperty("noAkadAkhir")]
        public string NoAkadAkhir { get; set; }

        [JsonProperty("tanggalAkadAkhir")]
        public string TanggalAkadAkhir { get; set; }

        [JsonProperty("tanggalAwalKredit")]

        public int TanggalAwalKredit { get; set; }

        [JsonProperty("tanggalMulai")]

        public int TanggalMulai { get; set; }

        [JsonProperty("tanggalJatuhTempo")]

        public int TanggalJatuhTempo { get; set; }

        [JsonProperty("kategoriDebiturKode")]

        public int KategoriDebiturKode { get; set; }

        [JsonProperty("kategoriDebiturKet")]
        public string KategoriDebiturKet { get; set; }

        [JsonProperty("jenisPenggunaan")]

        public int JenisPenggunaan { get; set; }

        [JsonProperty("jenisPenggunaanKet")]
        public string JenisPenggunaanKet { get; set; }

        [JsonProperty("sektorEkonomi")]
        public string SektorEkonomi { get; set; }

        [JsonProperty("sektorEkonomiKet")]
        public string SektorEkonomiKet { get; set; }

        [JsonProperty("kreditProgramPemerintah")]
        public string KreditProgramPemerintah { get; set; }

        [JsonProperty("kreditProgramPemerintahKet")]
        public string KreditProgramPemerintahKet { get; set; }

        [JsonProperty("lokasiProyek")]
        public string LokasiProyek { get; set; }

        [JsonProperty("lokasiProyekKet")]
        public string LokasiProyekKet { get; set; }

        [JsonProperty("valutaKode")]
        public string ValutaKode { get; set; }

        [JsonProperty("sukuBungaImbalan")]
        public float SukuBungaImbalan { get; set; }

        [JsonProperty("jenisSukuBungaImbalan")]

        public int JenisSukuBungaImbalan { get; set; }

        [JsonProperty("jenisSukuBungaImbalanKet")]
        public string JenisSukuBungaImbalanKet { get; set; }

        [JsonProperty("kualitas")]

        public int Kualitas { get; set; }

        [JsonProperty("kualitasKet")]
        public string KualitasKet { get; set; }

        [JsonProperty("jumlahHariTunggakan")]

        public int JumlahHariTunggakan { get; set; }

        [JsonProperty("nilaiProyek")]
        public string NilaiProyek { get; set; }

        [JsonProperty("plafonAwal")]

        public int PlafonAwal { get; set; }

        [JsonProperty("plafon")]

        public int Plafon { get; set; }

        [JsonProperty("realisasiBulanBerjalan")]

        public int RealisasiBulanBerjalan { get; set; }

        [JsonProperty("nilaiDalamMataUangAsal")]
        public string NilaiDalamMataUangAsal { get; set; }

        [JsonProperty("kodeSebabMacet")]
        public string KodeSebabMacet { get; set; }

        [JsonProperty("sebabMacetKet")]
        public string SebabMacetKet { get; set; }

        [JsonProperty("tanggalMacet")]
        public string TanggalMacet { get; set; }

        [JsonProperty("tunggakanPokok")]

        public int TunggakanPokok { get; set; }

        [JsonProperty("tunggakanBunga")]

        public int TunggakanBunga { get; set; }

        [JsonProperty("frekuensiTunggakan")]

        public int FrekuensiTunggakan { get; set; }

        [JsonProperty("denda")]

        public int Denda { get; set; }

        [JsonProperty("frekuensiRestrukturisasi")]

        public int FrekuensiRestrukturisasi { get; set; }

        [JsonProperty("tanggalRestrukturisasiAkhir")]
        public string TanggalRestrukturisasiAkhir { get; set; }

        [JsonProperty("kodeCaraRestrukturisasi")]
        public string KodeCaraRestrukturisasi { get; set; }

        [JsonProperty("restrukturisasiKet")]
        public string RestrukturisasiKet { get; set; }

        [JsonProperty("kondisi")]
        public string Kondisi { get; set; }

        [JsonProperty("kondisiKet")]
        public string KondisiKet { get; set; }

        [JsonProperty("tanggalKondisi")]
        public string TanggalKondisi { get; set; }

        [JsonProperty("keterangan")]
        public string Keterangan { get; set; }

        [JsonProperty("tahunBulan01Ht")]
        public string TahunBulan01Ht { get; set; }

        [JsonProperty("tahunBulan01")]

        public int TahunBulan01 { get; set; }

        [JsonProperty("tahunBulan01Kol")]
        public string TahunBulan01Kol { get; set; }

        [JsonProperty("tahunBulan02Ht")]
        public string TahunBulan02Ht { get; set; }

        [JsonProperty("tahunBulan02")]

        public int TahunBulan02 { get; set; }

        [JsonProperty("tahunBulan02Kol")]
        public string TahunBulan02Kol { get; set; }

        [JsonProperty("tahunBulan03Ht")]
        public string TahunBulan03Ht { get; set; }

        [JsonProperty("tahunBulan03")]

        public int TahunBulan03 { get; set; }

        [JsonProperty("tahunBulan03Kol")]
        public string TahunBulan03Kol { get; set; }

        [JsonProperty("tahunBulan04Ht")]
        public string TahunBulan04Ht { get; set; }

        [JsonProperty("tahunBulan04")]

        public int TahunBulan04 { get; set; }

        [JsonProperty("tahunBulan04Kol")]
        public string TahunBulan04Kol { get; set; }

        [JsonProperty("tahunBulan05Ht")]
        public string TahunBulan05Ht { get; set; }

        [JsonProperty("tahunBulan05")]

        public int TahunBulan05 { get; set; }

        [JsonProperty("tahunBulan05Kol")]
        public string TahunBulan05Kol { get; set; }

        [JsonProperty("tahunBulan06Ht")]
        public string TahunBulan06Ht { get; set; }

        [JsonProperty("tahunBulan06")]

        public int TahunBulan06 { get; set; }

        [JsonProperty("tahunBulan06Kol")]
        public string TahunBulan06Kol { get; set; }

        [JsonProperty("tahunBulan07Ht")]
        public string TahunBulan07Ht { get; set; }

        [JsonProperty("tahunBulan07")]

        public int TahunBulan07 { get; set; }

        [JsonProperty("tahunBulan07Kol")]
        public string TahunBulan07Kol { get; set; }

        [JsonProperty("tahunBulan08Ht")]
        public string TahunBulan08Ht { get; set; }

        [JsonProperty("tahunBulan08")]

        public int TahunBulan08 { get; set; }

        [JsonProperty("tahunBulan08Kol")]
        public string TahunBulan08Kol { get; set; }

        [JsonProperty("tahunBulan09Ht")]
        public string TahunBulan09Ht { get; set; }

        [JsonProperty("tahunBulan09")]

        public int TahunBulan09 { get; set; }

        [JsonProperty("tahunBulan09Kol")]
        public string TahunBulan09Kol { get; set; }

        [JsonProperty("tahunBulan10Ht")]
        public string TahunBulan10Ht { get; set; }

        [JsonProperty("tahunBulan10")]

        public int TahunBulan10 { get; set; }

        [JsonProperty("tahunBulan10Kol")]
        public string TahunBulan10Kol { get; set; }

        [JsonProperty("tahunBulan11Ht")]
        public string TahunBulan11Ht { get; set; }

        [JsonProperty("tahunBulan11")]

        public int TahunBulan11 { get; set; }

        [JsonProperty("tahunBulan11Kol")]
        public string TahunBulan11Kol { get; set; }

        [JsonProperty("tahunBulan12Ht")]
        public string TahunBulan12Ht { get; set; }

        [JsonProperty("tahunBulan12")]

        public int TahunBulan12 { get; set; }

        [JsonProperty("tahunBulan12Kol")]
        public string TahunBulan12Kol { get; set; }

        [JsonProperty("tahunBulan13Ht")]
        public string TahunBulan13Ht { get; set; }

        [JsonProperty("tahunBulan13")]

        public int TahunBulan13 { get; set; }

        [JsonProperty("tahunBulan13Kol")]
        public string TahunBulan13Kol { get; set; }

        [JsonProperty("tahunBulan14Ht")]
        public string TahunBulan14Ht { get; set; }

        [JsonProperty("tahunBulan14")]

        public int TahunBulan14 { get; set; }

        [JsonProperty("tahunBulan14Kol")]
        public string TahunBulan14Kol { get; set; }

        [JsonProperty("tahunBulan15Ht")]
        public string TahunBulan15Ht { get; set; }

        [JsonProperty("tahunBulan15")]

        public int TahunBulan15 { get; set; }

        [JsonProperty("tahunBulan15Kol")]
        public string TahunBulan15Kol { get; set; }

        [JsonProperty("tahunBulan16Ht")]
        public string TahunBulan16Ht { get; set; }

        [JsonProperty("tahunBulan16")]

        public int TahunBulan16 { get; set; }

        [JsonProperty("tahunBulan16Kol")]
        public string TahunBulan16Kol { get; set; }

        [JsonProperty("tahunBulan17Ht")]

        public int TahunBulan17Ht { get; set; }

        [JsonProperty("tahunBulan17")]

        public int TahunBulan17 { get; set; }

        [JsonProperty("tahunBulan17Kol")]

        public int TahunBulan17Kol { get; set; }

        [JsonProperty("tahunBulan18Ht")]

        public int TahunBulan18Ht { get; set; }

        [JsonProperty("tahunBulan18")]

        public int TahunBulan18 { get; set; }

        [JsonProperty("tahunBulan18Kol")]

        public int TahunBulan18Kol { get; set; }

        [JsonProperty("tahunBulan19Ht")]

        public int TahunBulan19Ht { get; set; }

        [JsonProperty("tahunBulan19")]

        public int TahunBulan19 { get; set; }

        [JsonProperty("tahunBulan19Kol")]

        public int TahunBulan19Kol { get; set; }

        [JsonProperty("tahunBulan20Ht")]

        public int TahunBulan20Ht { get; set; }

        [JsonProperty("tahunBulan20")]

        public int TahunBulan20 { get; set; }

        [JsonProperty("tahunBulan20Kol")]

        public int TahunBulan20Kol { get; set; }

        [JsonProperty("tahunBulan21Ht")]

        public int TahunBulan21Ht { get; set; }

        [JsonProperty("tahunBulan21")]

        public int TahunBulan21 { get; set; }

        [JsonProperty("tahunBulan21Kol")]

        public int TahunBulan21Kol { get; set; }

        [JsonProperty("tahunBulan22Ht")]

        public int TahunBulan22Ht { get; set; }

        [JsonProperty("tahunBulan22")]

        public int TahunBulan22 { get; set; }

        [JsonProperty("tahunBulan22Kol")]

        public int TahunBulan22Kol { get; set; }

        [JsonProperty("tahunBulan23Ht")]

        public int TahunBulan23Ht { get; set; }

        [JsonProperty("tahunBulan23")]

        public int TahunBulan23 { get; set; }

        [JsonProperty("tahunBulan23Kol")]

        public int TahunBulan23Kol { get; set; }

        [JsonProperty("tahunBulan24Ht")]
        public string TahunBulan24Ht { get; set; }

        [JsonProperty("tahunBulan24")]

        public int TahunBulan24 { get; set; }

        [JsonProperty("tahunBulan24Kol")]
        public string TahunBulan24Kol { get; set; }

        [JsonProperty("agunan")]
        public Agunan[] Agunan { get; set; }

        [JsonProperty("penjamin")]
        public object[] Penjamin { get; set; }
    }

    public  class Agunan
    {
        [JsonProperty("jenisAgunanKet")]
        public string JenisAgunanKet { get; set; }

        [JsonProperty("nilaiAgunanMenurutLJK")]

        public int NilaiAgunanMenurutLjk { get; set; }

        [JsonProperty("prosentaseParipasu")]
        public string ProsentaseParipasu { get; set; }

        [JsonProperty("tanggalUpdate")]
        public string TanggalUpdate { get; set; }

        [JsonProperty("nomorAgunan")]
        public string NomorAgunan { get; set; }

        [JsonProperty("jenisPengikatan")]
        public string JenisPengikatan { get; set; }

        [JsonProperty("jenisPengikatanKet")]
        public string JenisPengikatanKet { get; set; }

        [JsonProperty("tanggalPengikatan")]

        public int TanggalPengikatan { get; set; }

        [JsonProperty("namaPemilikAgunan")]
        public string NamaPemilikAgunan { get; set; }

        [JsonProperty("alamatAgunan")]
        public string AlamatAgunan { get; set; }

        [JsonProperty("kabKotaLokasiAgunan")]
        public string KabKotaLokasiAgunan { get; set; }

        [JsonProperty("kabKotaLokasiAgunanKet")]
        public string KabKotaLokasiAgunanKet { get; set; }

        [JsonProperty("tglPenilaianPelapor")]

        public int TglPenilaianPelapor { get; set; }

        [JsonProperty("peringkatAgunan")]
        public string PeringkatAgunan { get; set; }

        [JsonProperty("kodeLembagaPemeringkat")]
        public string KodeLembagaPemeringkat { get; set; }

        [JsonProperty("lembagaPemeringkat")]
        public string LembagaPemeringkat { get; set; }

        [JsonProperty("buktiKepemilikan")]
        public string BuktiKepemilikan { get; set; }

        [JsonProperty("nilaiAgunanNjop")]

        public int NilaiAgunanNjop { get; set; }

        [JsonProperty("nilaiAgunanIndep")]
        public string NilaiAgunanIndep { get; set; }

        [JsonProperty("namaPenilaiIndep")]
        public string NamaPenilaiIndep { get; set; }

        [JsonProperty("asuransi")]
        public string Asuransi { get; set; }

        [JsonProperty("tanggalPenilaianPenilaiIndependen")]
        public string TanggalPenilaianPenilaiIndependen { get; set; }

        [JsonProperty("keterangan")]
        public string Keterangan { get; set; }
    }

    public  class ParameterPencarian
    {
        [JsonProperty("namaDebitur")]
        public string NamaDebitur { get; set; }

        [JsonProperty("jenisKelamin")]
        public string JenisKelamin { get; set; }

        [JsonProperty("jenisKelaminKet")]
        public string JenisKelaminKet { get; set; }

        [JsonProperty("noIdentitas")]
        public string NoIdentitas { get; set; }

        [JsonProperty("npwp")]
        public string Npwp { get; set; }

        [JsonProperty("tempatLahir")]
        public string TempatLahir { get; set; }

        [JsonProperty("tanggalLahir")]

        public int TanggalLahir { get; set; }
    }

    public  class RingkasanFasilitas
    {
        [JsonProperty("plafonEfektifKreditPembiayaan")]

        public int PlafonEfektifKreditPembiayaan { get; set; }

        [JsonProperty("plafonEfektifLc")]

        public int PlafonEfektifLc { get; set; }

        [JsonProperty("plafonEfektifGyd")]

        public int PlafonEfektifGyd { get; set; }

        [JsonProperty("plafonEfektifSec")]

        public int PlafonEfektifSec { get; set; }

        [JsonProperty("plafonEfektifLain")]

        public int PlafonEfektifLain { get; set; }

        [JsonProperty("plafonEfektifTotal")]

        public int PlafonEfektifTotal { get; set; }

        [JsonProperty("bakiDebetKreditPembiayaan")]

        public int BakiDebetKreditPembiayaan { get; set; }

        [JsonProperty("bakiDebetLc")]

        public int BakiDebetLc { get; set; }

        [JsonProperty("bakiDebetGyd")]

        public int BakiDebetGyd { get; set; }

        [JsonProperty("bakiDebetSec")]

        public int BakiDebetSec { get; set; }

        [JsonProperty("bakiDebetLain")]

        public int BakiDebetLain { get; set; }

        [JsonProperty("bakiDebetTotal")]

        public int BakiDebetTotal { get; set; }

        [JsonProperty("krediturBankUmum")]

        public int KrediturBankUmum { get; set; }

        [JsonProperty("krediturBPR/S")]

        public int KrediturBprS { get; set; }

        [JsonProperty("krediturLp")]

        public int KrediturLp { get; set; }

        [JsonProperty("krediturLainnya")]

        public int KrediturLainnya { get; set; }

        [JsonProperty("kualitasTerburuk")]

        public int KualitasTerburuk { get; set; }

        [JsonProperty("kualitasBulanDataTerburuk")]

        public int KualitasBulanDataTerburuk { get; set; }
    }
}