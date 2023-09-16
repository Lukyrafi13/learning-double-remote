using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.MachineWorkPapers;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers;
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

namespace NewLMS.UMKM.MediatR.Features.AppraisalWorkPapers.Queries
{
    public class GetApprMachineCostQuery : IRequest<ServiceResponse<ApprWorkPaperMachineCostResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprMachineCostQueryHandler : IRequestHandler<GetApprMachineCostQuery, ServiceResponse<ApprWorkPaperMachineCostResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _apprMachine;
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineCost> _appr;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
        private readonly IGenericRepositoryAsync<MLiquidationItem> _mItem;
        private readonly IMapper _mapper;

        public GetApprMachineCostQueryHandler(
            IGenericRepositoryAsync<ApprMachineTemplate> apprMachine,
            IMapper mapper,
            IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary,
            IGenericRepositoryAsync<ApprWorkPaperMachineCost> appr,
            IGenericRepositoryAsync<ApprLiquidation> apprLiquidation,
            IGenericRepositoryAsync<MLiquidationItem> mItem)
        {
            _apprMachine = apprMachine;
            _mapper = mapper;
            _apprSummary = apprSummary;
            _appr = appr;
            _apprLiquidation = apprLiquidation;
            _mItem = mItem;
        }
        public async Task<ServiceResponse<ApprWorkPaperMachineCostResponse>> Handle(GetApprMachineCostQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var summaryData = await GetWorkPaperSummary(request.AppraisalGuid);

                var apprMachine = await _apprMachine.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprMachine == null)
                    return ServiceResponse<ApprWorkPaperMachineCostResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template mesin kosong, isi terlebih dahulu sebelum melanjutkan");

                var dataVm = _mapper.Map<ApprWorkPaperMachineCostResponse>(summaryData?.ApprWorkPaperMachineCosts?.FirstOrDefault());

                dataVm ??= new ApprWorkPaperMachineCostResponse();
                dataVm.LiquidationData = new List<ApprLiquidationResponse>();

                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });
                var mItemMachine = await _mItem.GetListByPredicate(x => x.TypeId == "03");

                if (apprLiquidation == null || apprLiquidation.Count == 0)
                {
                    foreach (var data in mItemMachine)
                    {
                        var item1 = new ApprLiquidation()
                        {
                            LiquidationGuid = Guid.NewGuid(),
                            AppraisalGuid = request.AppraisalGuid,
                            LiquidationType = data.TypeId,
                            LiquidationItem = data.ItemId
                        };
                        await _apprLiquidation.AddAsync(item1);
                    }
                }
                else
                {
                    var apprLiquidLand = apprLiquidation.Where(x => x.LiquidationType == "03");
                    if (apprLiquidLand != null && apprLiquidLand.Count() < mItemMachine.Count)
                    {
                        foreach (var data in mItemMachine)
                        {
                            if (!Array.Exists(apprLiquidLand.ToArray(), x => x.LiquidationType == data.TypeId && x.LiquidationItem == data.ItemId))
                            {
                                var item = new ApprLiquidation()
                                {
                                    LiquidationGuid = Guid.NewGuid(),
                                    AppraisalGuid = request.AppraisalGuid,
                                    LiquidationType = data.TypeId,
                                    LiquidationItem = data.ItemId
                                };
                                await _apprLiquidation.AddAsync(item);
                            }
                        }
                    }
                }

                if (summaryData.ApprWorkPaperMachineCosts.Count == 0)
                {
                    await _appr.AddAsync(new ApprWorkPaperMachineCost
                    {
                        ApprWorkPaperMachineCostGuid = Guid.NewGuid(),
                        ApprWorkPaperMachineMarketSummaryGuid = summaryData.ApprWorkPaperMachineMarketSummaryGuid,
                        ApprMachineTemplateGuid = apprMachine.ApprMachineTemplateGuid
                    });

                    var machineCost = await _appr.GetByPredicate(x => x.ApprWorkPaperMachineMarketSummaryGuid == summaryData.ApprWorkPaperMachineMarketSummaryGuid && !x.IsDeleted);
                    dataVm = _mapper.Map<ApprWorkPaperMachineCostResponse>(machineCost);
                }
                else if (summaryData.ApprWorkPaperMachineCosts.FirstOrDefault().ApprMachineTemplateGuid == null)
                {
                    var machineCost = summaryData.ApprWorkPaperMachineCosts.FirstOrDefault();
                    machineCost.ApprMachineTemplateGuid = apprMachine.ApprMachineTemplateGuid;
                    await _appr.UpdateAsync(machineCost);

                    machineCost = await _appr.GetByPredicate(x => x.ApprWorkPaperMachineMarketSummaryGuid == summaryData.ApprWorkPaperMachineMarketSummaryGuid && !x.IsDeleted);
                    dataVm = _mapper.Map<ApprWorkPaperMachineCostResponse>(machineCost);
                }

                apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });

                if (apprLiquidation != null && apprLiquidation.Where(x => x.LiquidationType == "03") != null)
                {
                    dataVm.LiquidationData = _mapper.Map<List<ApprLiquidationResponse>>(apprLiquidation.Where(x => x.LiquidationType == "03"));
                    dataVm.PctLiquidationCostValue = summaryData.PctLiquidationCostValue;
                }

                return ServiceResponse<ApprWorkPaperMachineCostResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperMachineCostResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperMachineMarketSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApprWorkPaperMachineCosts",
                    "ApprWorkPaperMachineCosts.MachineTemplate",
                    "ApprWorkPaperMachineCosts.MachineTemplate.WilayahVillages",
                    "ApprWorkPaperMachineCosts.MachineTemplate.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperMachineCosts.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperMachineCosts.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces"
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
