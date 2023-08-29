// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Approvals;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Approvals.Commands
// {
//     public class ApprovalApprovalPutCommand : ApprovalApprovalPutRequestDto, IRequest<ServiceResponse<ApprovalApprovalResponse>>
//     {
//     }

//     public class ApprovalApprovalPutCommandHandler : IRequestHandler<ApprovalApprovalPutCommand, ServiceResponse<ApprovalApprovalResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Approval> _Approval;
//         private readonly IMapper _mapper;

//         public ApprovalApprovalPutCommandHandler(IGenericRepositoryAsync<Approval> Approval, IMapper mapper)
//         {
//             _Approval = Approval;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<ApprovalApprovalResponse>> Handle(ApprovalApprovalPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingApproval = await _Approval.GetByIdAsync(request.Id, "Id");

//                 existingApproval = _mapper.Map<ApprovalApprovalPutRequestDto, Approval>(request, existingApproval);

//                 await _Approval.UpdateAsync(existingApproval);

//                 var response = _mapper.Map<ApprovalApprovalResponse>(existingApproval);

//                 return ServiceResponse<ApprovalApprovalResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<ApprovalApprovalResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }