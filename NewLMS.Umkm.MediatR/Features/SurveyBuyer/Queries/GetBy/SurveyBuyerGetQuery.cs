// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SurveyBuyers;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.SurveyBuyers.Queries
// {
//     public class SurveyBuyerGetQuery : SurveyBuyerFindRequestDto, IRequest<ServiceResponse<SurveyBuyerResponseDto>>
//     {
//     }

//     public class SurveyBuyerGetQueryHandler : IRequestHandler<SurveyBuyerGetQuery, ServiceResponse<SurveyBuyerResponseDto>>
//     {
//         private IGenericRepositoryAsync<SurveyBuyer> _SurveyBuyer;
//         private readonly IMapper _mapper;

//         public SurveyBuyerGetQueryHandler(IGenericRepositoryAsync<SurveyBuyer> SurveyBuyer, IMapper mapper)
//         {
//             _SurveyBuyer = SurveyBuyer;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<SurveyBuyerResponseDto>> Handle(SurveyBuyerGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "Survey",
//                     "MetodePembayaran"
//                 };

//                 var data = await _SurveyBuyer.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<SurveyBuyerResponseDto>.Return404("Data SurveyBuyer not found");
//                 var response = _mapper.Map<SurveyBuyerResponseDto>(data);
//                 return ServiceResponse<SurveyBuyerResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SurveyBuyerResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }