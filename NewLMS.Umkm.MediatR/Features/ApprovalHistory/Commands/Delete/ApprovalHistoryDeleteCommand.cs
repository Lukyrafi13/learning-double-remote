// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ApprovalHistorys;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.ApprovalHistorys.Commands
// {
//     public class ApprovalHistoryDeleteCommand : ApprovalHistoryFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteApprovalHistoryCommandHandler : IRequestHandler<ApprovalHistoryDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<ApprovalHistory> _ApprovalHistory;
//         private readonly IMapper _mapper;

//         public DeleteApprovalHistoryCommandHandler(IGenericRepositoryAsync<ApprovalHistory> ApprovalHistory, IMapper mapper)
//         {
//             _ApprovalHistory = ApprovalHistory;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(ApprovalHistoryDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _ApprovalHistory.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _ApprovalHistory.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }