using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalReceivable;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetApprReceivableVerificationQuery : IRequest<ServiceResponse<ApprReceivableVerificationResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprReceivableVerificationQueryHandler : IRequestHandler<GetApprReceivableVerificationQuery, ServiceResponse<ApprReceivableVerificationResponse>>
    {
        private IGenericRepositoryAsync<ApprReceivableVerification> _apprReceivableVerification;
        private IMapper _mapper;

        public GetApprReceivableVerificationQueryHandler(IGenericRepositoryAsync<ApprReceivableVerification> ApprReceivableVerification, IMapper mapper)
        {
            _apprReceivableVerification = ApprReceivableVerification;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprReceivableVerificationResponse>> Handle(GetApprReceivableVerificationQuery request, CancellationToken cancellationToken)
        {
            var data = await _apprReceivableVerification.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid", null);
            var dataVm = _mapper.Map<ApprReceivableVerificationResponse>(data);

            return ServiceResponse<ApprReceivableVerificationResponse>.ReturnResultWith200(dataVm);
        }
    }
}
