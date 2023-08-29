using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;
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
using System.IO;
using System.Linq;

namespace NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Commands
{
    public class PrescreeningDokumenPutCommand : PrescreeningDokumenPutRequestDto, IRequest<ServiceResponse<PrescreeningDokumenResponseDto>>
    {
    }

    public class PutPrescreeningDokumenCommandHandler : IRequestHandler<PrescreeningDokumenPutCommand, ServiceResponse<PrescreeningDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IGenericRepositoryAsync<FileDokumen> _FileDokumen;
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IConfiguration _appConfig;
        private readonly IMapper _mapper;

        public PutPrescreeningDokumenCommandHandler(
            IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen,
            IGenericRepositoryAsync<Prescreening> Prescreening,
            IGenericRepositoryAsync<FileUrl> FileUrl,
            IGenericRepositoryAsync<FileDokumen> FileDokumen,
            IGenericRepositoryAsync<App> App,
            IConfiguration appConfig,
            IMapper mapper)
        {
            _PrescreeningDokumen = PrescreeningDokumen;
            _Prescreening = Prescreening;
            _FileUrl = FileUrl;
            _FileDokumen = FileDokumen;
            _App = App;
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

        public async Task<ServiceResponse<PrescreeningDokumenResponseDto>> Handle(PrescreeningDokumenPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingPrescreeningDokumen = await _PrescreeningDokumen.GetByIdAsync(request.Id, "Id");
                existingPrescreeningDokumen.DokumenLainnya = request.DokumenLainnya;
                existingPrescreeningDokumen.NomorDokumen = request.NomorDokumen;
                existingPrescreeningDokumen.TanggalKadaluarsa = request.TanggalKadaluarsa;
                existingPrescreeningDokumen.TanggalTBO = request.TanggalTBO;
                existingPrescreeningDokumen.DeskripsiTBO = request.DeskripsiTBO;
                existingPrescreeningDokumen.Justifikasi = request.Justifikasi;
                existingPrescreeningDokumen.VerifiedByAdmin = request.VerifiedByAdmin;
                existingPrescreeningDokumen.PrescreeningId = request.PrescreeningId;
                existingPrescreeningDokumen.RFDocumentId = request.RFDocumentId;
                existingPrescreeningDokumen.RFTipeDokumenId = request.RFTipeDokumenId;
                existingPrescreeningDokumen.RFStatusDokumenId = request.RFStatusDokumenId;
                existingPrescreeningDokumen.RFCollateralBCId = request.RFCollateralBCId;

                var documentFileUrls = new System.Collections.Generic.List<FileDokumen>();
                var fileUrls = new System.Collections.Generic.List<FileUrl>();

                if (request.Files != null)
                {

                    var includes = new string[]
                    {
                        "App",
                        "App.Prospect",
                        "App.TipeDebitur",
                        "App.Prospect.Stage",
                        "App.BookingOffice",
                    };

                    var Prescreening = await _Prescreening.GetByIdAsync(request.PrescreeningId, "Id", includes);
                    var App = Prescreening.App;
                    var FolderName = "documents/" + $"{App.AplikasiId}{"_"}{Regex.Replace(App.Prospect.NamaCustomer, "[^A-Za-z0-9]+", "_")}";
                    
                    var dir = Path.Combine(rootDir, FolderName).Replace(@"\", @"/").Replace(@"\\", @"/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir.ToString());
                    }

                    request.Files.ToList().ForEach(async f =>
                    {
                        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                        var fileUrlId = Guid.NewGuid();

                        documentFileUrls.Add(new FileDokumen
                        {
                            PrescreeningDokumenId = request.Id,
                            FileUrlId = fileUrlId,
                        });

                        fileUrls.Add(new FileUrl
                        {
                            Id = fileUrlId,
                            Url = await f.SaveToLocal(_GetSaveDir(f, FolderName, App.Id.ToString(), request.NomorDokumen, timestamp)),
                            FileSize = f.Length.ToString(),
                            FileType = await f.getType(_GetSaveDir(f, FolderName, App.Id.ToString(), request.NomorDokumen, timestamp)),
                        });
                    });
                    
                    existingPrescreeningDokumen.LastUploadDate = DateTime.Now;
                }

                await _PrescreeningDokumen.UpdateAsync(existingPrescreeningDokumen);
                if (fileUrls.Count > 0)
                {
                    await _FileUrl.AddRangeAsync(fileUrls.ToList());

                    if (documentFileUrls.Count > 0)
                    {
                        await _FileDokumen.AddRangeAsync(documentFileUrls.ToList());

                    }
                }

                var response = _mapper.Map<PrescreeningDokumenResponseDto>(existingPrescreeningDokumen);

                return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}