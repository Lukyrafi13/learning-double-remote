using NewLMS.UMKM.SIKP2.Models;
using Refit;

namespace NewLMS.UMKM.SIKP2.Interfaces
{
    public interface IApiService
    {
        [Post("/rateakad")]
        Task<RateAkadResponseModel> PostSIKPRateAkad([Body(BodySerializationMethod.Json)] RateAkadRequestModel request);
    }
}
