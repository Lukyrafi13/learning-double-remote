using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Approvals;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Approvals.Queries
{
    public class ApprovalApprovalGetQuery : ApprovalFind, IRequest<ServiceResponse<ApprovalApprovalResponse>>
    {
    }

    public class ApprovalApprovalGetQueryHandler : IRequestHandler<ApprovalApprovalGetQuery, ServiceResponse<ApprovalApprovalResponse>>
    {
        private readonly IGenericRepositoryAsync<Approval> _Approval;
        private readonly IMapper _mapper;

        public ApprovalApprovalGetQueryHandler(IGenericRepositoryAsync<Approval> Approval, IMapper mapper)
        {
            _Approval = Approval;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprovalApprovalResponse>> Handle(ApprovalApprovalGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _Approval.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<ApprovalApprovalResponse>.Return404("Data Approval not found");
                var response = _mapper.Map<ApprovalApprovalResponse>(data);
                return ServiceResponse<ApprovalApprovalResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprovalApprovalResponse>.ReturnException(ex);
            }
        }
    }
}