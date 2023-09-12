using NewLMS.UMKM.FileUpload.Models;

namespace NewLMS.UMKM.FileUpload.Interfaces
{
    public interface IUploadService
    {
        Task<UploadResponseModel> Upload(UploadRequestModel request);
        Task<GenerateFileResponseModel> GenerateFile(GenerateFileRequestModel request);
    }
}
