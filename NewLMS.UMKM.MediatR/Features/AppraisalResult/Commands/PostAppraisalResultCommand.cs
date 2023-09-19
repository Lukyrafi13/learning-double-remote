using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalResults;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AppraisalResult.Commands
{
    public class PostAppraisalResultCommand : AppraisalResultRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid LoanApplicationGuid;
    }

    public class PostAppraisalResultCommandHandler : IRequestHandler<PostAppraisalResultCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AppraisalResults> _appraisalResult;
        private readonly IMapper _mapper;

        public PostAppraisalResultCommandHandler(IMapper mapper, IGenericRepositoryAsync<AppraisalResults> appraisalResult)
        {
            _appraisalResult = appraisalResult;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostAppraisalResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appraisalResult = await _appraisalResult.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid");
                if (appraisalResult != null)
                {
                    appraisalResult.Remark = request.Remark;

                    await _appraisalResult.UpdateAsync(appraisalResult);
                }
                else
                {
                    appraisalResult = new AppraisalResults
                    {
                        AppraisalResultGuid = Guid.NewGuid(),
                        LoanApplicationGuid = request.LoanApplicationGuid,
                        Remark = request.Remark
                    };

                    await _appraisalResult.AddAsync(appraisalResult);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
