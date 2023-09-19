using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.ShopAppartmentWorkPaper;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers;
using NewLMS.Umkm.Data.Dto;
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

namespace NewLMS.Umkm.MediatR.Features.AppraisalWorkPapers.Queries
{
    public class GetApprShopApartmentQuery : IRequest<ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprShopApartmentQueryHandler : IRequestHandler<GetApprShopApartmentQuery, ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprWorkPaperShopApartments> _appr;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
        private readonly IGenericRepositoryAsync<MLiquidationItem> _mItem;
        private readonly IMapper _mapper;

        public GetApprShopApartmentQueryHandler(
            IMapper mapper,
            IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> apprSummary,
            IGenericRepositoryAsync<ApprWorkPaperShopApartments> appr,
            IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding,
            IGenericRepositoryAsync<ApprLiquidation> apprLiquidation,
            IGenericRepositoryAsync<MLiquidationItem> mItem)
        {
            _apprSummary = apprSummary;
            _mapper = mapper;
            _appr = appr;
            _apprBuilding = apprBuilding;
            _apprLiquidation = apprLiquidation;
            _mItem = mItem;
        }
        public async Task<ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>> Handle(GetApprShopApartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var dataVm = _mapper.Map<ApprWorkPaperShopApartmentHeaderResponse>(apprSummary);
                dataVm.MarketData = new List<ApprShopApartmentResponse>();
                dataVm.LiquidationData = new List<ApprLiquidationResponse>();

                var apprBuilding = await _apprBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprBuilding == null)
                    return ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template bangunan kosong, isi terlebih dahulu sebelum melanjutkan");
                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });
                var mItemShop = await _mItem.GetListByPredicate(x => x.TypeId == "02");

                if (apprSummary.ApprWorkPaperShopApartments.Count == 0 || !Array.Exists(apprSummary.ApprWorkPaperShopApartments.ToArray(), x => x.DataNumber == 0))
                {
                    var appr = new ApprWorkPaperShopApartments()
                    {
                        ApprWorkPaperShopApartmentGuid = Guid.NewGuid(),
                        ApprWorkPaperShopApartmentSummaryGuid = apprSummary.ApprWorkPaperShopApartmentSummaryGuid,
                        ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid,
                        DataNumber = 0,
                    };

                    await _appr.AddAsync(appr);
                }

                if (apprLiquidation == null || apprLiquidation.Count == 0)
                {
                    foreach (var data in mItemShop)
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
                    var apprLiquidLand = apprLiquidation.Where(x => x.LiquidationType == "02");
                    if (apprLiquidLand != null && apprLiquidLand.Count() < mItemShop.Count)
                    {
                        foreach (var data in mItemShop)
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

                apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                foreach (var data in apprSummary.ApprWorkPaperShopApartments)
                {
                    if (data.DataNumber == 0)
                    {
                        var response = new ApprShopApartmentResponse()
                        {
                            DataNumber = data?.DataNumber,
                            DataType = _mapper.Map<SimpleResponse<Guid>>(data?.DataTypeFK),
                            DataSource = data?.DataSource,
                            PhoneNumber = data?.PhoneNumber,
                            ObjectDistance = data?.ObjectDistance,
                            RoadWidth = data?.RoadWidth,
                            DataUsage = data?.DataUsage,
                            Allotment = _mapper.Map<SimpleResponse<Guid>>(data?.AllotmentFK),
                            AreaTotalBuildingFloor = data?.AreaTotalBuildingFloor,
                            AreaActualLandControlled = data?.AreaActualLandControlled,
                            AreaFirstFloorBuilding = data?.AreaFirstFloorBuilding,
                            AreaEqualizationCoefficient = data?.AreaEqualizationCoefficient,
                            LandForm = _mapper.Map<SimpleResponse<Guid>>(data?.LandFormFK),
                            LandCondition = _mapper.Map<SimpleResponse<Guid>>(data?.LandConditionFK),
                            Ownership = _mapper.Map<SimpleResponse<Guid>>(data?.OwnershipFK),
                            FacilityInfrastructure = data?.FacilityInfrastructure,
                            CurrOffer = data?.CurrOffer,
                            CurrPriceEqualization = data?.CurrPriceEqualization,
                            PctDiscount = data?.PctDiscount,
                            CurrPriceAfterDiscount = data?.CurrPriceAfterDiscount,
                            CurrShopPriceM2 = data?.CurrShopPriceM2,
                            Remark = data?.Remark,
                        };

                        dataVm.MarketData.Add(response);
                    }
                    else
                    {
                        dataVm.MarketData.Add(_mapper.Map<ApprShopApartmentResponse>(data));
                    }
                }

                dataVm.MarketData = dataVm.MarketData.OrderBy(x => x.DataNumber).ToList();

                apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });

                if (apprLiquidation != null && apprLiquidation.Where(x => x.LiquidationType == "02") != null)
                    dataVm.LiquidationData = _mapper.Map<List<ApprLiquidationResponse>>(apprLiquidation.Where(x => x.LiquidationType == "02"));

                return ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        private async Task<ApprWorkPaperShopApartmentSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApprWorkPaperShopApartments",
                    "ApprWorkPaperShopApartments.WilayahVillages",
                    "ApprWorkPaperShopApartments.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperShopApartments.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperShopApartments.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperShopApartments.ApprBuildingTemplates",
                    "ApprWorkPaperShopApartments.ApprBuildingTemplates.ApprBuildingFloors",
                    "ApprWorkPaperShopApartments.AllotmentFK",
                    "ApprWorkPaperShopApartments.LandFormFK",
                    "ApprWorkPaperShopApartments.LandConditionFK",
                    "ApprWorkPaperShopApartments.OwnershipFK"
                };
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperShopApartmentSummaries()
                {
                    ApprWorkPaperShopApartmentSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);

            }
            return apprSummary;
        }
    }
}
