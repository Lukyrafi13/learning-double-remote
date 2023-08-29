using NewLMS.Umkm.SIKP.Models;
using Refit;

namespace NewLMS.Umkm.SIKP.Interfaces
{
    public interface IApiService
    {
        [Get("/calon/{nik}")]
        Task<CalonDebiturResponseModel> GetSIKPCalonDebitur(string nik);

        [Get("/plafon/{nik}")]
        Task<PlafonResponseModel> GetSIKPPlafon(string nik);

        [Post("/limitakad")]
        Task<LimitAkadResponseModel> GetSIKPLimitAkadSkemaSektor([Body(BodySerializationMethod.Json)] LimitAkadRequestModel limitRequest);

        [Post("/calon")]
        Task<PostCalonDebiturResponseModel> PostSIKPCalonDebitur([Body(BodySerializationMethod.Json)] PostCalonDebiturRequestModel postCalo);
    }
}
