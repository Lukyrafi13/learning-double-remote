using NewLMS.Umkm.SIKP2.Models;

namespace NewLMS.Umkm.SIKP2.Interfaces
{
    public interface ISIKPService2
    {
        Task<RateAkadResponseModel> GetRateAkad(RateAkadRequestModel request);
    }
}
