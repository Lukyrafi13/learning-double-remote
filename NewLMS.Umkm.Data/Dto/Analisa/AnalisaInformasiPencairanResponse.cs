using System;

namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaInformasiPencairanResponse : AnalisaInformasiPencairanPut
    {
        public RFCaraPengikatan CaraPenarikan { get; set; }
        public RFPengikatanKredit PengikatanKredit { get; set; }
        public RFPolaPengembalian PolaPengembalianKredit { get; set; }
        public RfBranches BookingOffice { get; set; }
    }
}
