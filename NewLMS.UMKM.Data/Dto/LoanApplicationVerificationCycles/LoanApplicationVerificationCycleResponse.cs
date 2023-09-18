using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationVerificationCycles
{
    public class LoanApplicationVerificationCycleResponse : BaseResponse
    {
        public Guid Id { get; set; }

        //Informasi Omset
        public int? BusinessLandFormCode { get; set; }

        public int? BusinessLandAreaCode { get; set; }

        public double LandArea { get; set; }

        public int? BusinessCapacityCode { get; set; }

        public double BusinessLandCapacity { get; set; }

        public double AnnualSales { get; set; }
        public double NetWorthOfPlaceBusiness { get; set; }

        public virtual RfParameterDetailSimpleResponse BusinessLandForm { get; set; }
        public virtual RfParameterDetailSimpleResponse BusinessLandArea { get; set; }
        public virtual RfParameterDetailSimpleResponse BusinessCapacity { get; set; }
    }
}
