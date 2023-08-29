using NewLMS.UMKM.SIKP2.Models;

namespace NewLMS.UMKM.SIKP2.Interfaces
{
    public interface ISIKPService2
    {
        Task<RateAkadResponseModel> GetRateAkad(RateAkadRequestModel request);
    }
}
