using System;

namespace NewLMS.Umkm.Data.Dto.SPPKs
{
    public class SPPKHalamanUtamaPut
    {
        public Guid Id { get; set; }

        public string NomorRekeningEksternalDebitur { get; set; }
        public string NomorRekeningInternalDebitur { get; set; }
        public string NomorCIFDebitur { get; set; }
        public string AtasNamaDebitur { get; set; }
        public string NomorRekeningEksternalPencairan { get; set; }
        public string NomorRekeningInternalPencairan { get; set; }
        public string NomorCIFPencairan { get; set; }
        public string AtasNamaPencairan { get; set; }
        public double? TotalPlafond { get; set; }
        public double? TotalBiayaBiaya { get; set; }
        public double? NominalYangDicairkan { get; set; }
        public string NomorRekeningEksternalBunga { get; set; }
        public string NomorRekeningInternalBunga { get; set; }
        public string NomorCIFBunga { get; set; }
        public string AtasNamaBunga { get; set; }
        public string NomorRekeningEksternalPokok { get; set; }
        public string NomorRekeningInternalPokok { get; set; }
        public string NomorCIFPokok { get; set; }
        public string AtasNamaPokok { get; set; }
        public string CatatanLainnya { get; set; }
        public string AccountOfficeCode { get; set; }
        public string NoSKK { get; set; }
        public DateTime? TanggalSKK { get; set; }
        public string NamaPejabatSKK1 { get; set; }
        public string NamaPejabatSKK2 { get; set; }
        public string NoSPPK { get; set; }
        public DateTime? TanggalSPPK { get; set; }
        public string NamaPejabatSPPK1 { get; set; }
        public string NamaPejabatSPPK2 { get; set; }
        public string NoMKK { get; set; }
        public DateTime? TanggalMKK { get; set; }
        public string NamaPejabatMKK1 { get; set; }
        public string NamaPejabatMKK2 { get; set; }
        public string NamaPejabatMKK3 { get; set; }
        public string NamaPejabatMKK4 { get; set; }
        public string NamaPejabatMKK5 { get; set; }

        public Guid? RFJabatanSKK1Id { get; set; }
        public Guid? RFJabatanSKK2Id { get; set; }
        public Guid? RFJabatanSPPK1Id { get; set; }
        public Guid? RFJabatanSPPK2Id { get; set; }
        public Guid? RFJabatanMKK1Id { get; set; }
        public Guid? RFJabatanMKK2Id { get; set; }
        public Guid? RFJabatanMKK3Id { get; set; }
        public Guid? RFJabatanMKK4Id { get; set; }
        public Guid? RFJabatanMKK5Id { get; set; }
    }
}
