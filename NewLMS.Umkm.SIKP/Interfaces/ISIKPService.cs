using NewLMS.UMKM.SIKP.Models;

namespace NewLMS.UMKM.SIKP.Interfaces
{
    public interface ISIKPService
    {
        Task<CalonDebiturResponseModel> GetCalonDebitur(string nik);
        Task<PlafonResponseModel> GetPlafon(string nik);
        Task<LimitAkadResponseModel> GetLimitAkadSkemaSektor(LimitAkadRequestModel requestModel);
        Task<PostCalonDebiturResponseModel> PostCalonDebitur(PostCalonDebiturRequestModel postCalonDebitur);
    }
}
