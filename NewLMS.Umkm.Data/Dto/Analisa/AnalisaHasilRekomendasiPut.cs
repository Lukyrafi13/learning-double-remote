using System;

namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaHasilRekomendasiPut
    {
        public Guid Id { get; set; }

        public DateTime? TanggalRencanaPencairan { get; set; }
        public double ModalSudahDibiayai { get; set; }
        public bool? BacaDanSetuju { get; set; }
        public string Covenant { get; set; }
    }
}
