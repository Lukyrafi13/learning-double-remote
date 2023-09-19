using System;
namespace NewLMS.Umkm.Data.Dto.SLIKRequestDebtors
{
	public class SLIKRequestDebtorRequest
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SLIKRequestId { get; set; }
        public int SLIKDebtorType { get; set; }
        public string Fullname { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public string EstablishedLocation { get; set; }
        public Guid? SLIKDocumentUrlId { get; set; }
        public string KodeRefPengguna { get; set; }
        public string TujuanPermintaan { get; set; }
        public string SLIKResult { get; set; }
        public bool RoboSlik { get; set; }
	}
}

