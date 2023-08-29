using System;
namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaKemampuanMembayarResponse : AnalisaKemampuanMembayarPut
    {
        
        public double? PendapatanUsaha { get; set; }
        public double? HargaPokokPenjualan { get; set; }
        public double? PengeluaranUsaha { get; set; }
        public double? TotalPengeluaranRT { get; set; }
        public double? TotalAngsuranPinjaman { get; set; }
        public double? KeutunganUsaha { get; set; }
        public double? TotalPenghasilan { get; set; }
        public double? SisaPenghasilan { get; set; }
        public double? RekomendasiAngsuran { get; set; }
        public double? DisposableIncome { get; set; }
        public double? IDIR { get; set; }
        public double? GPM { get; set; }
        public double? NOP { get; set; }
        public double? PL { get; set; }
        public double? NI { get; set; }
        public double? PRT { get; set; }
    }
}
