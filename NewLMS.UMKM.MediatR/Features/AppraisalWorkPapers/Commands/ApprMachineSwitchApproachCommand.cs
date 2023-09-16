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

namespace NewLMS.UMKM.MediatR.Features.AppraisalWorkPapers.Commands
{
    public class ApprMachineSwitchApproachCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
        public Guid ApproachTypeGuid { get; set; }
    }

    public class ApprMachineSwitchApproachCommandHandler : IRequestHandler<ApprMachineSwitchApproachCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;

        public ApprMachineSwitchApproachCommandHandler(
        IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary, IGenericRepositoryAsync<ApprLiquidation> apprLiquidation)
        {
            _apprSummary = apprSummary;
            _apprLiquidation = apprLiquidation;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprMachineSwitchApproachCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid && x.LiquidationType == "03" && !x.IsDeleted);

                if (apprLiquidation != null && apprLiquidation.Count > 0)
                {
                    foreach (var data in apprLiquidation)
                    {
                        data.LiquidationOption = null;
                        data.LiquidationScore = null;

                        await _apprLiquidation.UpdateAsync(data);
                    }
                }

                if (apprSummary != null)
                {
                    apprSummary.ApproachType = request.ApproachTypeGuid;

                    await _apprSummary.UpdateAsync(apprSummary);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperMachineMarketSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                "ApprWorkPaperMachineMarkets"
            });
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperMachineMarketSummaries()
                {
                    ApprWorkPaperMachineMarketSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                    "ApprWorkPaperMachineMarkets"
                });

            }
            return apprSummary;
        }
    }
}
