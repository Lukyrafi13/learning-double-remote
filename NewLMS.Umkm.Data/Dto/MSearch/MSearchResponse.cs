using System;

namespace NewLMS.UMKM.Data.Dto.MSearchs
{
    public class MSearchResponse
    {
        public string TypeId { get; set; }
        public string SearchType { get; set; }
        public string SearchId { get; set; }
        public string SearchDesc { get; set; }
        public string ResultType { get; set; }
        public string AplikasiId { get; set; }
        public string Stage { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NoIdentity { get; set; }
        public string Cif { get; set; }
        public string Branch { get; set; }
        public string Npwp { get; set; }
        public string  CustType { get; set; }
        public decimal Outstanding { get; set; }
        public string LoanType { get; set; }
        public decimal Limit { get; set; }
        public string BankName { get; set; }
        public DateTime? Expired { get; set; }
        public string ReferenceNo { get; set; }

    }

    public class MSearchResponseDto{
        public string TypeId { get; set; }
        public string SearchType { get; set; }
        public string SearchId { get; set; }
        public string SearchDesc { get; set; }
        public string ResultType { get; set; }
        public string VariableSystem { get; set; }
        public string VariableFields { get; set; }
        public string VariableCondition { get; set; }
        public string ResultSystem { get; set; }
        public string ResultKey { get; set; }
        public string ResultCondition { get; set; }
        public bool Active { get; set; }
    }
}