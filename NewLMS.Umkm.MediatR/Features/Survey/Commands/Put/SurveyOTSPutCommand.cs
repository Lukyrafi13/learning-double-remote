// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Surveys;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Surveys.Commands
// {
//     public class SurveyOTSPutCommand : SurveyOTSPut, IRequest<ServiceResponse<SurveyOTSResponse>>
//     {

//     }
//     public class SurveyOTSPutCommandHandler : IRequestHandler<SurveyOTSPutCommand, ServiceResponse<SurveyOTSResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Survey> _Survey;
//         private readonly IMapper _mapper;

//         public SurveyOTSPutCommandHandler(
//             IGenericRepositoryAsync<Survey> Survey,
//             IMapper mapper)
//         {
//             _Survey = Survey;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SurveyOTSResponse>> Handle(SurveyOTSPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingSurvey = await _Survey.GetByIdAsync(request.Id, "Id");

//                 existingSurvey.TanggalSurvey = request.TanggalSurvey;
//                 existingSurvey.NamaSurveyor = request.NamaSurveyor;
//                 existingSurvey.NamaVerifikator = request.NamaVerifikator;
//                 existingSurvey.OrangDitemui = request.OrangDitemui;
//                 existingSurvey.NamaPerusahaan = request.NamaPerusahaan;
//                 existingSurvey.NoTelpPerusahaan = request.NoTelpPerusahaan;
//                 existingSurvey.LamaTahunBerdiri = request.LamaTahunBerdiri;
//                 existingSurvey.LamaBulanBerdiri = request.LamaBulanBerdiri;
//                 existingSurvey.JumlahKaryawan = request.JumlahKaryawan;
//                 existingSurvey.JumlahCabang = request.JumlahCabang;
//                 existingSurvey.AlamatSamaDenganDebitur = request.AlamatSamaDenganDebitur;
//                 existingSurvey.AlamatSurveyor = request.AlamatSurveyor;
//                 existingSurvey.ProvinsiSurveyor = request.ProvinsiSurveyor;
//                 existingSurvey.KabupatenKotaSurveyor = request.KabupatenKotaSurveyor;
//                 existingSurvey.KecamatanSurveyor = request.KecamatanSurveyor;
//                 existingSurvey.KelurahanSurveyor = request.KelurahanSurveyor;
//                 existingSurvey.KesimpulanHasil = request.KesimpulanHasil;
//                 existingSurvey.RFRelationSurveyId = request.RFRelationSurveyId;
//                 existingSurvey.RfOwnerCategoryId = request.RfOwnerCategoryId;
//                 existingSurvey.RFOwnerOTSId = request.RFOwnerOTSId;
//                 // existingSurvey.RFBusinessTypeId = request.RFBusinessTypeId;
//                 existingSurvey.RfZipCodeId = request.RfZipCodeId;
//                 existingSurvey.RFBidangUsahaKURId = request.RFBidangUsahaKURId;

//                 await _Survey.UpdateAsync(existingSurvey);
                
//                 var response = _mapper.Map<SurveyOTSResponse>(existingSurvey);
//                 return ServiceResponse<SurveyOTSResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SurveyOTSResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }