using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
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
    public class ApprMachineMarketPostCommand : ApprMachineMarketSummaryRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
    }

    public class ApprMachineMarketPostCommandHandler : IRequestHandler<ApprMachineMarketPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarkets> _appr;
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _apprMachine;
        private readonly IMapper _mapper;

        public ApprMachineMarketPostCommandHandler(IGenericRepositoryAsync<ApprWorkPaperMachineMarkets> appr,
        IMapper mapper,
        IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary,
        IGenericRepositoryAsync<ApprMachineTemplate> apprMachine)
        {
            _appr = appr;
            _mapper = mapper;
            _apprSummary = apprSummary;
            _apprMachine = apprMachine;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprMachineMarketPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var apprMachine = await _apprMachine.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprMachine == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template mesin kosong, isi terlebih dahulu sebelum melanjutkan");

                for (int i = 0; i < request.BaseData.Count; i++)
                {
                    var appr = await _appr.GetByPredicate(x => x.ApprWorkPaperMachineMarketSummaryGuid == apprSummary.ApprWorkPaperMachineMarketSummaryGuid && x.DataNumber == request.BaseData[i].DataNumber);
                    var apprMapped = _mapper.Map<ApprWorkPaperMachineMarkets>(request.BaseData[i]);
                    if (appr == null)
                    {
                        apprMapped.ApprWorkPaperMachineMarketGuid = Guid.NewGuid();
                        apprMapped.ApprWorkPaperMachineMarketSummaryGuid = apprSummary.ApprWorkPaperMachineMarketSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprMachineTemplateGuid = apprMachine.ApprMachineTemplateGuid;
                        }

                        await _appr.AddAsync(apprMapped);
                    }
                    else
                    {
                        apprMapped.ApprWorkPaperMachineMarketGuid = appr.ApprWorkPaperMachineMarketGuid;
                        apprMapped.ApprWorkPaperMachineMarketSummaryGuid = apprSummary.ApprWorkPaperMachineMarketSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprMachineTemplateGuid = apprMachine.ApprMachineTemplateGuid;
                        }
                        apprMapped = HelperGeneral.UpdateBaseEntityTime(apprMapped, appr);

                        await _appr.UpdateAsync(apprMapped);
                    }
                }

                var apprSummaryMapped = _mapper.Map<ApprWorkPaperMachineMarketSummaries>(request);
                apprSummaryMapped.ApprWorkPaperMachineMarketSummaryGuid = apprSummary.ApprWorkPaperMachineMarketSummaryGuid;
                apprSummaryMapped.AppraisalGuid = apprSummary.AppraisalGuid;
                apprSummaryMapped.ApproachType = Guid.Parse("F25F917B-EFA3-46AB-8A59-70FF5E4ED541");
                apprSummaryMapped = HelperGeneral.UpdateBaseEntityTime(apprSummaryMapped, apprSummary);
                await _apprSummary.UpdateAsync(apprSummaryMapped);

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
