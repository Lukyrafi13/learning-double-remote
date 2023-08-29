using NewLMS.Umkm.SIKP.Models;

namespace NewLMS.Umkm.SIKP.Interfaces
{
    public interface ISIKPService
    {
        Task<CalonDebiturResponseModel> GetCalonDebitur(string nik);
        Task<PlafonResponseModel> GetPlafon(string nik);
        Task<LimitAkadResponseModel> GetLimitAkadSkemaSektor(LimitAkadRequestModel requestModel);
        Task<PostCalonDebiturResponseModel> PostCalonDebitur(PostCalonDebiturRequestModel postCalonDebitur);
    }
}
