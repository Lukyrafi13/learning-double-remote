using NewLMS.Umkm.SIKP.Models;
using Refit;

namespace NewLMS.Umkm.SIKP.Interfaces
{
    public interface IApiService
    {

        [Get("/calon/{nik}")]
        Task<CalonDebiturResponseModelHeader> GetSIKPCalonDebitur(string nik, [Header("codeApplication")] string codeApplication);

        [Get("/plafon/{nik}")]
        Task<PlafonResponseModelHeader> GetSIKPPlafon(string nik, [Header("codeApplication")] string codeApplication);

        [Post("/limitakad")]
        Task<LimitAkadResponseModelHeader> GetSIKPLimitAkadSkemaSektor([Body(BodySerializationMethod.Json)] LimitAkadRequestModel limitRequest, [Header("codeApplication")] string codeApplication);

        [Post("/calon")]
        Task<PostCalonDebiturResponseModelHeader> PostSIKPCalonDebitur([Body(BodySerializationMethod.Json)] PostCalonDebiturRequestModel postCalo, [Header("codeApplication")] string codeApplication);
        
        [Post("/rateakad")]
        Task<RateAkadResponseModelHeader> PostSIKPRateAkad([Body(BodySerializationMethod.Json)] RateAkadRequestModel request, [Header("codeApplication")] string codeApplication);
    }
}
