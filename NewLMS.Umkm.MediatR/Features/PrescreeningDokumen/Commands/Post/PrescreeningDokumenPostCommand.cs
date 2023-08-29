// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PrescreeningDokumens;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;
// using Microsoft.Extensions.Configuration;
// using Microsoft.AspNetCore.Http;
// using System.Collections.Generic;
// using System.Text.RegularExpressions;
// using System.IO;
// using System.Linq;

// namespace NewLMS.UMKM.MediatR.Features.PrescreeningDokumens.Commands
// {
//     public class PrescreeningDokumenPostCommand : PrescreeningDokumenPostRequestDto, IRequest<ServiceResponse<PrescreeningDokumenResponseDto>>
//     {

//     }
//     public class PrescreeningDokumenPostCommandHandler : IRequestHandler<PrescreeningDokumenPostCommand, ServiceResponse<PrescreeningDokumenResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
//         private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
//         private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
//         private readonly IGenericRepositoryAsync<FileDokumen> _FileDokumen;
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IConfiguration _appConfig;
//         private readonly IMapper _mapper;

//         public PrescreeningDokumenPostCommandHandler(
//             IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen,
//             IGenericRepositoryAsync<Prescreening> Prescreening,
//             IGenericRepositoryAsync<FileUrl> FileUrl,
//             IGenericRepositoryAsync<FileDokumen> FileDokumen,
//             IGenericRepositoryAsync<App> App,
//             IConfiguration appConfig,
//             IMapper mapper)
//         {
//             _PrescreeningDokumen = PrescreeningDokumen;
//             _Prescreening = Prescreening;
//             _FileUrl = FileUrl;
//             _FileDokumen = FileDokumen;
//             _App = App;
//             _appConfig = appConfig;
//             _mapper = mapper;
//         }
        

//         (string root, string sub, string loanapplicationId, string documentName, string timestamp) _GetSaveDir(IFormFile file, string ForderName, string loanapplicationId, string documentName, string timestamp) => "Directory" switch
//         {
//             "Directory" => (_appConfig.GetValue<string>("UMKMStorage:Directory"), _GetDirByDocType(file, ForderName), loanapplicationId, documentName, timestamp),
//             _ => throw new NotSupportedException()
//         };

//         string rootDir => "Directory" switch
//         {
//             "Directory" => _appConfig.GetValue<string>("UMKMStorage:Directory"),
//             _ => throw new NotSupportedException()
//         };

//         string _GetDirByDocType(IFormFile file, string FolderName)
//         {
//             if (file.IsValidTypeFile())
//             {
//                 return FolderName;
//             }
//             else
//                 return _appConfig.GetValue<string>("UMKMStorage:Folders:Default");

//         }

//         public async Task<ServiceResponse<PrescreeningDokumenResponseDto>> Handle(PrescreeningDokumenPostCommand request, CancellationToken cancellationToken)
//         {

//             if (request.DocumentSubTypes != null && request.DocumentSubTypes.Count != request.Files.Count)
//             {
//                 return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Jumlah input data sub dokumen tidak sama dengan jumlah data file");
//             }

//             try
//             {
//                 var PrescreeningDokumen = _mapper.Map<PrescreeningDokumen>(request);

//                 var returnedPrescreeningDokumen = await _PrescreeningDokumen.AddAsync(PrescreeningDokumen);

//                 // var response = _mapper.Map<PrescreeningDokumenResponseDto>(returnedPrescreeningDokumen);

//                 var documentFileUrls = new List<FileDokumen>();
//                 var fileUrls = new List<FileUrl>();

//                 if (request.Files != null)
//                 {

//                     var includes = new string[]
//                     {
//                         "App",
//                         "App.Prospect",
//                         "App.TipeDebitur",
//                         "App.Prospect.Stage",
//                         "App.BookingOffice",
//                     };
//                     var Prescreening = await _Prescreening.GetByIdAsync(request.PrescreeningId, "Id", includes);
//                     var App = Prescreening.App;

//                     var FolderName = "documents/" + $"{App.AplikasiId}{"_"}{Regex.Replace(App.Prospect.NamaCustomer, "[^A-Za-z0-9]+", "_")}";

//                     var dir = Path.Combine(rootDir, FolderName).Replace(@"\", @"/").Replace(@"\\", @"/");

//                     if (!Directory.Exists(dir))
//                     {
//                         Directory.CreateDirectory(dir.ToString());
//                     }

//                     foreach (var item in request.Files.ToList().Select((value, index) => (value, index)))
//                     {
//                         var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
//                         var FileId = Guid.NewGuid();

//                         fileUrls.Add(new FileUrl
//                         {
//                             Id = FileId,
//                             Url = await item.value.SaveToLocal(_GetSaveDir(item.value, FolderName, App.Id.ToString(), request.NomorDokumen, timestamp)),
//                             FileSize = item.value.Length.ToString(),
//                             FileType = await item.value.getType(_GetSaveDir(item.value, FolderName, App.Id.ToString(), request.NomorDokumen, timestamp))

//                         });

//                         documentFileUrls.Add(new FileDokumen
//                         {
//                             Id = Guid.NewGuid(),
//                             PrescreeningDokumenId = returnedPrescreeningDokumen.Id,
//                             FileUrlId = FileId,
//                             DocumentSubType = request.DocumentSubTypes != null
//                                 ? request.DocumentSubTypes.ElementAt(item.index) : null,
//                         });
//                     }

//                     await _FileUrl.AddRangeAsync(fileUrls.ToList());
//                     await _FileDokumen.AddRangeAsync(documentFileUrls.ToList());

//                     returnedPrescreeningDokumen.LastUploadDate = DateTime.Now;
//                     await _PrescreeningDokumen.UpdateAsync(returnedPrescreeningDokumen);
//                 }

//                 var response = _mapper.Map<PrescreeningDokumenResponseDto>(returnedPrescreeningDokumen);
                
//                 return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }