// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ApprovalHistorys;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.ApprovalHistorys.Queries
// {
//     public class ApprovalHistoryGetQuery : ApprovalHistoryFindRequestDto, IRequest<ServiceResponse<ApprovalHistoryResponseDto>>
//     {
//     }

//     public class ApprovalHistoryGetQueryHandler : IRequestHandler<ApprovalHistoryGetQuery, ServiceResponse<ApprovalHistoryResponseDto>>
//     {
//         private IGenericRepositoryAsync<ApprovalHistory> _ApprovalHistory;
//         private readonly IMapper _mapper;

//         public ApprovalHistoryGetQueryHandler(IGenericRepositoryAsync<ApprovalHistory> ApprovalHistory, IMapper mapper)
//         {
//             _ApprovalHistory = ApprovalHistory;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<ApprovalHistoryResponseDto>> Handle(ApprovalHistoryGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var data = await _ApprovalHistory.GetByIdAsync(request.Id, "Id");
//                 if (data == null)
//                     return ServiceResponse<ApprovalHistoryResponseDto>.Return404("Data ApprovalHistory not found");
//                 var response = _mapper.Map<ApprovalHistoryResponseDto>(data);
//                 return ServiceResponse<ApprovalHistoryResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<ApprovalHistoryResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }