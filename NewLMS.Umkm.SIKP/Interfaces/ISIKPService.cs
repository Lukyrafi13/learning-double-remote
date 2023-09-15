using NewLMS.Umkm.SIKP.Models;

namespace NewLMS.Umkm.SIKP.Interfaces
{
    public interface ISIKPService
    {
        Task<CalonDebiturResponseModelHeader> GetCalonDebitur(string nik);
        Task<PlafonResponseModelHeader> GetPlafon(string nik);
        Task<LimitAkadResponseModelHeader> GetLimitAkadSkemaSektor(LimitAkadRequestModel requestModel);
        Task<PostCalonDebiturResponseModelHeader> PostCalonDebitur(PostCalonDebiturRequestModel postCalonDebitur);
        Task<RateAkadResponseModelHeader> GetRateAkad(RateAkadRequestModel request);
    }
}
