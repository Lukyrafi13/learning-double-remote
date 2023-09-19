using System;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Data.Dto.DebtorCompanyLegal;

namespace NewLMS.Umkm.Data.Dto.DebtorCompany
{
    public class DebtorCompanyResponse : BaseResponse
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhoods { get; set; }
        public int? ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual DebtorCompanyLegalResponse DebtorCompanyLegal { get; set; }
        public virtual RfZipCodeResponse RfZipCode { get; set; }
    }

    public class DebtorCompanySimpleResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

