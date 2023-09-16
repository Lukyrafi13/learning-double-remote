using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Domain.Context;
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
    public class LiquidationCalculateCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
        public string LiquidationType { get; set; }
        public string WorkPaperTypeId { get; set; } // 01 = TanahBangunan, 02 = MesinPasar, 03 = Ruko, 04 = Kendaraan, 05 = MesinBiaya
    }

    public class LiquidationCalculateCommandHandler : IRequestHandler<LiquidationCalculateCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprLiquidation> _liquidation;
        private readonly IGenericRepositoryAsync<MLiquidationCondition> _condition;
        private readonly IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> _apprLandBuilding;
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprMachineMarket;
        private readonly IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> _apprShopApartment;
        private readonly IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> _apprVehicle;
        private readonly UserContext _dbContext;
        private readonly IMapper _mapper;

        public LiquidationCalculateCommandHandler(
            IGenericRepositoryAsync<ApprLiquidation> liquidation,
            IMapper mapper,
            IGenericRepositoryAsync<MLiquidationCondition> condition,
            UserContext dbContext,
            IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> apprLandBuilding,
            IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprMachineMarket,
            IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> apprShopApartment,
            IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> apprVehicle)
        {
            _liquidation = liquidation;
            _mapper = mapper;
            _condition = condition;
            _dbContext = dbContext;
            _apprLandBuilding = apprLandBuilding;
            _apprMachineMarket = apprMachineMarket;
            _apprShopApartment = apprShopApartment;
            _apprVehicle = apprVehicle;
        }

        public async Task<ServiceResponse<Unit>> Handle(LiquidationCalculateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mCondition = await _condition.GetListByPredicate(x => x.TypeId == request.LiquidationType);
                var liquidationData = await _liquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid && x.LiquidationType == request.LiquidationType,
                new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption"
                });

                MLiquidationCondition selected = null;
                double sumScore = 0.0;
                if (liquidationData != null && liquidationData.Count > 0)
                {
                    foreach (var liquidation in liquidationData)
                    {
                        sumScore += liquidation?.LiquidationScore == null ? 0 : (double)liquidation?.LiquidationScore;
                    }

                    foreach (var condition in mCondition)
                    {
                        //var checkCondition = _dbContext
                        //    .MLiquidationCondition
                        //    .FromSqlRaw(
                        //        "select * from [MLiquidationCondition] where TypeId = {0} and {1} " + condition.Condition, request.LiquidationType, sumScore
                        //    ).FirstOrDefault();

                        //if (checkCondition != null)
                        //{
                        //    selected = condition;
                        //    break;
                        //}
                    }
                }

                switch (request.WorkPaperTypeId)
                {
                    case "01":
                        if (request.LiquidationType == "01")
                        {
                            var landSumm = await _apprLandBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                            if (landSumm != null)
                            {
                                landSumm.PctLandLiquidationValue = selected?.Result;
                                // landSumm.LandLiquidationValue = (decimal)sumScore;
                                await _apprLandBuilding.UpdateAsync(landSumm);
                            }
                        }
                        else if (request.LiquidationType == "03")
                        {
                            var buildingSumm = await _apprLandBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                            if (buildingSumm != null)
                            {
                                buildingSumm.PctBuildingLiquidationValue = selected?.Result;
                                // buildingSumm.BuildingLiquidationValue = (decimal)sumScore;
                                await _apprLandBuilding.UpdateAsync(buildingSumm);
                            }
                        }
                        break;
                    case "02":
                        var machineSumm = await _apprMachineMarket.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                        if (machineSumm != null)
                        {
                            machineSumm.PctLiquidationValue = selected?.Result;
                            // machineSumm.LiquidationValue = (decimal)sumScore;
                            await _apprMachineMarket.UpdateAsync(machineSumm);
                        }
                        break;
                    case "03":
                        var shopSumm = await _apprShopApartment.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                        if (shopSumm != null)
                        {
                            shopSumm.PctLiquidationValue = selected?.Result;
                            // shopSumm.LiquidationValue = (decimal)sumScore;
                            await _apprShopApartment.UpdateAsync(shopSumm);
                        }
                        break;
                    case "04":
                        var vehicleSumm = await _apprVehicle.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                        if (vehicleSumm != null)
                        {
                            vehicleSumm.PctLiquidationValue = selected?.Result;
                            // vehicleSumm.LiquidationValue = (decimal)sumScore;
                            await _apprVehicle.UpdateAsync(vehicleSumm);
                        }
                        break;
                    case "05":
                        var machineCostSumm = await _apprMachineMarket.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                        if (machineCostSumm != null)
                        {
                            machineCostSumm.PctLiquidationCostValue = selected?.Result;
                            // vehicleSumm.LiquidationValue = (decimal)sumScore;
                            await _apprMachineMarket.UpdateAsync(machineCostSumm);
                        }
                        break;
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
