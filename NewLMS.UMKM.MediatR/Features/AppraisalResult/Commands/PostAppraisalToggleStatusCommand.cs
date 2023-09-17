using MediatR;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.AppraisalResult.Commands
{
    public class PostAppraisalToggleStatusCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class PostAppraisalToggleStatusCommandHandler : IRequestHandler<PostAppraisalToggleStatusCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;

        public PostAppraisalToggleStatusCommandHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal
        )
        {
            _appraisal = appraisal;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostAppraisalToggleStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appraisal = await _appraisal.GetByPredicate(x => x.AppraisalId == request.AppraisalGuid);
                if (appraisal != null)
                {
                    if (appraisal.AppraisalStatus == null || appraisal.AppraisalStatus == "In Progress")
                    {
                        appraisal.AppraisalStatus = "Done";
                    }
                    else
                    {
                        appraisal.AppraisalStatus = "In Progress";
                    }

                    await _appraisal.UpdateAsync(appraisal);
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
