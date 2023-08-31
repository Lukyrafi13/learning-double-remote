using NewLMS.UMKM.SIKP.Models;
using Refit;

namespace NewLMS.UMKM.SIKP.Interfaces
{
    public interface IApiService
    {
        [Headers("codeApplication: 1001")]
        [Get("/calon/{nik}")]
        Task<CalonDebiturResponseModel> GetSIKPCalonDebitur(string nik);

        [Headers("codeApplication: 1001")]
        [Get("/plafon/{nik}")]
        Task<PlafonResponseModel> GetSIKPPlafon(string nik);

        [Headers("codeApplication: 1001")]
        [Post("/limit")]
        Task<LimitAkadResponseModel> GetSIKPLimitAkadSkemaSektor([Body(BodySerializationMethod.Json)] LimitAkadRequestModel limitRequest);

        [Headers("codeApplication: 1001")]
        [Post("/calon")]
        Task<PostCalonDebiturResponseModel> PostSIKPCalonDebitur([Body(BodySerializationMethod.Json)] PostCalonDebiturRequestModel postCalo);
    }
}
