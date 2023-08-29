using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyFileUploads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace NewLMS.Umkm.MediatR.Features.SurveyFileUploads.Commands
{
    public class SurveyFileUploadPutCommand : SurveyFileUploadPutRequestDto, IRequest<ServiceResponse<SurveyFileUploadResponseDto>>
    {
    }

    public class PutSurveyFileUploadCommandHandler : IRequestHandler<SurveyFileUploadPutCommand, ServiceResponse<SurveyFileUploadResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SurveyFileUpload> _SurveyFileUpload;
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IGenericRepositoryAsync<Survey> _Survey;
        private readonly IMapper _mapper;
        private readonly IConfiguration _appConfig;

        public PutSurveyFileUploadCommandHandler(
            IGenericRepositoryAsync<SurveyFileUpload> SurveyFileUpload,
            IGenericRepositoryAsync<FileUrl> FileUrl,
            IGenericRepositoryAsync<Survey> Survey,
            IConfiguration appConfig,
            IMapper mapper)
        {
            _SurveyFileUpload = SurveyFileUpload;
            _FileUrl = FileUrl;
            _Survey = Survey;
            _appConfig = appConfig;
            _mapper = mapper;
        }

        (string root, string sub, string loanapplicationId, string documentName, string timestamp) _GetSaveDir(IFormFile file, string ForderName, string loanapplicationId, string documentName, string timestamp) => "Directory" switch
        {
            "Directory" => (_appConfig.GetValue<string>("UMKMStorage:Directory"), _GetDirByDocType(file, ForderName), loanapplicationId, documentName, timestamp),
            _ => throw new NotSupportedException()
        };

        string rootDir => "Directory" switch
        {
            "Directory" => _appConfig.GetValue<string>("UMKMStorage:Directory"),
            _ => throw new NotSupportedException()
        };

        string _GetDirByDocType(IFormFile file, string FolderName)
        {
            if (file.IsValidTypeFile())
            {
                return FolderName;
            }
            else
                return _appConfig.GetValue<string>("UMKMStorage:Folders:Default");

        }

        public async Task<ServiceResponse<SurveyFileUploadResponseDto>> Handle(SurveyFileUploadPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSurveyFileUpload = await _SurveyFileUpload.GetByIdAsync(request.Id, "Id");
                existingSurveyFileUpload.Judul = request.Judul;
                existingSurveyFileUpload.TanggalUpload = DateTime.Now;
                existingSurveyFileUpload.UploadOleh = request.UploadOleh;
                existingSurveyFileUpload.SurveyId = request.SurveyId;

                if (request.File != null)
                {
                    var includes = new string[]
                    {
                        "App",
                        "App.Prospect",
                        "App.TipeDebitur",
                        "App.Prospect.Stage",
                        "App.BookingOffice",
                    };
                    var survey = await _Survey.GetByIdAsync(request.SurveyId, "Id", includes);

                    var FolderName = "documents/" + $"{survey.App.AplikasiId}{"_"}{Regex.Replace(survey.App.Prospect.NamaCustomer, "[^A-Za-z0-9]+", "_")}";
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    
                    var FileId = Guid.NewGuid();

                    var fileURL = new FileUrl
                    {
                        Id = FileId,
                        Url = await request.File.SaveToLocal(_GetSaveDir(request.File, FolderName, survey.App.Id.ToString(), request.Judul, timestamp)),
                        FileSize = request.File.Length.ToString(),
                        FileType = await request.File.getType(_GetSaveDir(request.File, FolderName, survey.App.Id.ToString(), request.Judul, timestamp))
                    };

                    existingSurveyFileUpload.FileUrlId = FileId;
                    
                    var returnedFileUrl = await _FileUrl.AddAsync(fileURL);

                }

                await _SurveyFileUpload.UpdateAsync(existingSurveyFileUpload);

                var response = _mapper.Map<SurveyFileUploadResponseDto>(existingSurveyFileUpload);

                return ServiceResponse<SurveyFileUploadResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveyFileUploadResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}