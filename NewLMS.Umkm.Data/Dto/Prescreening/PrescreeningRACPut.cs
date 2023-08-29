using System;
namespace NewLMS.Umkm.Data.Dto.Prescreenings
{
    public class PrescreeningRACPut
    {
        public Guid Id { get; set; }
        public bool? RACUsiaMin { get; set; }
        public bool? RACUsiaMax { get; set; }
        public bool? RACeKTP { get; set; }
        public bool? RACNonDaftarHitam { get; set; }
        public bool? RACKolektibilitas1 { get; set; }
        public bool? RACTidakKolektibilitas345 { get; set; }
        public bool? RACMemilikiUsaha { get; set; }
        public bool? RACTidakMemilikiFasilitasKreditLain { get; set; }
        public bool? TidakPernahMenerimaKredit { get; set; }
        public bool? PesertaBPJSTK { get; set; }
    }
}
