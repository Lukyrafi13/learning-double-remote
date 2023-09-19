using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.MachineWorkPapers;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AppraisalWorkPapers.Commands
{
    public class ApprMachineCostPostCommand : ApprWorkPaperMachineCostRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
    }

    public class ApprMachineCostPostCommandHandler : IRequestHandler<ApprMachineCostPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineCost> _machineCost;
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _machineTemplate;
        private readonly IMapper _mapper;

        public ApprMachineCostPostCommandHandler(
        IMapper mapper,
        IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary,
        IGenericRepositoryAsync<ApprWorkPaperMachineCost> machineCost,
        IGenericRepositoryAsync<ApprMachineTemplate> machineTemplate)
        {
            _mapper = mapper;
            _apprSummary = apprSummary;
            _machineCost = machineCost;
            _machineTemplate = machineTemplate;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprMachineCostPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var machineTemplate = await _machineTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (machineTemplate == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template mesin kosong, isi terlebih dahulu sebelum melanjutkan");

                var machineCosts = apprSummary.ApprWorkPaperMachineCosts;
                var machineCostMapped = _mapper.Map<ApprWorkPaperMachineCost>(machineCosts.FirstOrDefault());
                if (machineCosts != null && machineCosts.Count > 0)
                {
                    var machineCost = machineCosts.FirstOrDefault();
                    machineCostMapped.ApprWorkPaperMachineCostGuid = machineCost.ApprWorkPaperMachineCostGuid;
                    machineCostMapped.ApprWorkPaperMachineMarketSummaryGuid = machineCost.ApprWorkPaperMachineMarketSummaryGuid;
                    machineCostMapped.ApprMachineTemplateGuid = machineCost.ApprMachineTemplateGuid;
                    machineCostMapped = HelperGeneral.UpdateBaseEntityTime(machineCostMapped, machineCost);

                    await _machineCost.UpdateAsync(machineCostMapped);
                }
                else
                {
                    machineCostMapped.ApprWorkPaperMachineCostGuid = Guid.NewGuid();
                    machineCostMapped.ApprWorkPaperMachineMarketSummaryGuid = apprSummary.ApprWorkPaperMachineMarketSummaryGuid;
                    machineCostMapped.ApprMachineTemplateGuid = machineTemplate.ApprMachineTemplateGuid;

                    await _machineCost.AddAsync(machineCostMapped);
                }

                apprSummary.ApproachType = Guid.Parse("0453985B-B6F8-4508-A443-F4FE67D3C3A1");
                apprSummary.CurrMarketCostValue = request.CurrMarketCostValue;
                apprSummary.PctLiquidationCostValue = request.PctLiquidationCostValue;
                apprSummary.LiquidationCostValue = request.LiquidationCostValue;
                await _apprSummary.UpdateAsync(apprSummary);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperMachineMarketSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                "ApprWorkPaperMachineCosts"
            };
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperMachineMarketSummaries()
                {
                    ApprWorkPaperMachineMarketSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);

            }
            return apprSummary;
        }
    }
}
