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
//     public class SurveyVerifikasiPutCommand : SurveyVerifikasiPut, IRequest<ServiceResponse<SurveyVerifikasiResponse>>
//     {

//     }
//     public class SurveyVerifikasiPutCommandHandler : IRequestHandler<SurveyVerifikasiPutCommand, ServiceResponse<SurveyVerifikasiResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Survey> _Survey;
//         private readonly IMapper _mapper;

//         public SurveyVerifikasiPutCommandHandler(
//             IGenericRepositoryAsync<Survey> Survey,
//             IMapper mapper)
//         {
//             _Survey = Survey;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SurveyVerifikasiResponse>> Handle(SurveyVerifikasiPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingSurvey = await _Survey.GetByIdAsync(request.Id, "Id");

//                 existingSurvey = _mapper.Map<SurveyVerifikasiPut, Survey>(request, existingSurvey);

//                 await _Survey.UpdateAsync(existingSurvey);
                
//                 var response = _mapper.Map<SurveyVerifikasiResponse>(existingSurvey);
//                 return ServiceResponse<SurveyVerifikasiResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SurveyVerifikasiResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }