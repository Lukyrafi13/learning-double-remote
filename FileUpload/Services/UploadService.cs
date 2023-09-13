using NewLMS.UMKM.FileUpload.Interfaces;
using NewLMS.UMKM.FileUpload.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.FileUpload.Services
{
    public class UploadService : IUploadService
    {
        private readonly IApiService _apiService;

        public UploadService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<GenerateFileResponseModel> GenerateFile(GenerateFileRequestModel request)
        {
            Stream stream = new MemoryStream(request.File);

            StreamPart streamPart = new StreamPart(stream, $"{request.FileTemplate}.pdf");
            return await _apiService.GenerateFile(request.Segment, request.DebtorName
                , request.LoanApplicationId
                , request.FileTemplate
                , streamPart);
        }

        public async Task<UploadResponseModel> Upload(UploadRequestModel request)
        {
            StreamPart streamPart = new StreamPart(request.File.OpenReadStream(), request.File.FileName);
            return await _apiService.Upload(request.Segment, request.DebtorName
                , request.LoanApplicationId
                , request.DocumentName
                , streamPart);
        }
    }
}
