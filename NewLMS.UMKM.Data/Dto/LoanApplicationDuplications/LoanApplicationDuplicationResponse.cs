using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationDuplication
{
    public class LoanApplicationDuplicationResponse
    {
        public LoanApplicationDuplicateLMSResponse Internal { get; set; }
        public LoanApplicationDuplicateLMSResponse Core { get; set; }
        public LoanApplicationDuplicateLMSResponse DHN { get; set; }
    }

    public class LoanApplicationDuplicateDetailResponse
    {
        public bool IsDuplicate { get; set; }
        public List<LoanApplicationDetailResponse> MSearch { get; set; }
    }

    public class LoanApplicationDuplicateLMSResponse : LoanApplicationDuplicateDetailResponse
    {

    }
    public class LoanApplicationDuplicateCoreResponse : LoanApplicationDuplicateDetailResponse
    {

    }
    public class LoanApplicationDuplicateDHNResponse : LoanApplicationDuplicateDetailResponse
    {

    }

    public class LoanApplicationDetailResponse
    {
        public Guid Id { get; set; }
        public string TypeId { get; set; }
        public string SearchType { get; set; }
        public string SearchId { get; set; }
        public string SearchDesc { get; set; }
        public string ResultType { get; set; }
        public string ApplicationNo { get; set; }
        public string Stage { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NoIdentity { get; set; }
        public string Cif { get; set; }
        public string Branch { get; set; }
        public string NPWP { get; set; }
        public string CustType { get; set; }
        public decimal Outstanding { get; set; }
        public string LoanType { get; set; }
        public decimal Limit { get; set; }
        public string BankName { get; set; }
        public DateTime? Expired { get; set; }
        public string ReferenceNo { get; set; }

    }
}
