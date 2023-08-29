using System;

namespace NewLMS.UMKM.Data.Dto.BiayaVariabels
{
    public class BiayaVariabelPostRequestDto
    {
        public string Keterangan { get; set; }
        public string Satuan { get; set; }
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public int Total { get; set; }
        public Guid? SurveyId { get; set; }
    }
}
