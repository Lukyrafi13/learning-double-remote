// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Queries
// {
//     public class SlikRequestSummaryGetQuery : SlikRequestFind, IRequest<ServiceResponse<SlikRequestSummaryResponse>>
//     {
//     }

//     public class SlikRequestSummaryGetQueryHandler : IRequestHandler<SlikRequestSummaryGetQuery, ServiceResponse<SlikRequestSummaryResponse>>
//     {
//         private IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IMapper _mapper;

//         public SlikRequestSummaryGetQueryHandler(IGenericRepositoryAsync<SlikRequest> SlikRequest, IMapper mapper)
//         {
//             _SlikRequest = SlikRequest;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<SlikRequestSummaryResponse>> Handle(SlikRequestSummaryGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "App",
//                     "SlikCreditHistorys",
//                     "SlikCreditHistorys.RfSandiBIApplicationTypeClass",
//                     "SlikCreditHistorys.RfCreditType",
//                 };

//                 var data = await _SlikRequest.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<SlikRequestSummaryResponse>.Return404("Data SlikRequest not found");
//                 var response = _mapper.Map<SlikRequestSummaryResponse>(data);
//                 return ServiceResponse<SlikRequestSummaryResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SlikRequestSummaryResponse>.ReturnException(ex);
//             }
//         }
//     }
// }