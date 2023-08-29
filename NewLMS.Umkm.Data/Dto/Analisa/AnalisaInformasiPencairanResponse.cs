using System;

namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaInformasiPencairanResponse : AnalisaInformasiPencairanPut
    {
        public RFCaraPengikatan CaraPenarikan { get; set; }
        public RFPengikatanKredit PengikatanKredit { get; set; }
        public RFPolaPengembalian PolaPengembalianKredit { get; set; }
        public RfBranch BookingOffice { get; set; }
    }
}
