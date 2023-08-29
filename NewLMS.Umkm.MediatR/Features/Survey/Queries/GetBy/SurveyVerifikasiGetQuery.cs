// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Surveys;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.Surveys.Queries
// {
//     public class SurveyVerifikasiGetQuery : SurveyFind, IRequest<ServiceResponse<SurveyVerifikasiResponse>>
//     {
//     }

//     public class SurveyVerifikasiGetQueryQueryHandler : IRequestHandler<SurveyVerifikasiGetQuery, ServiceResponse<SurveyVerifikasiResponse>>
//     {
//         private IGenericRepositoryAsync<Survey> _Survey;
//         private readonly IMapper _mapper;

//         public SurveyVerifikasiGetQueryQueryHandler(IGenericRepositoryAsync<Survey> Survey, IMapper mapper)
//         {
//             _Survey = Survey;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SurveyVerifikasiResponse>> Handle(SurveyVerifikasiGetQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "App",
//                 "KepemilikanTempatUsaha",
//                 "LamaMenempatiLokasi",
//             };

//             var data = await _Survey.GetByIdAsync(request.Id, "Id", includes);

//             var response = _mapper.Map<SurveyVerifikasiResponse>(data);

//             return ServiceResponse<SurveyVerifikasiResponse>.ReturnResultWith200(response);
//         }
//     }
// }