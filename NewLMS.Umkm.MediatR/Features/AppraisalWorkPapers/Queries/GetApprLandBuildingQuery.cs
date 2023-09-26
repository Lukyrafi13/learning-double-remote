using AutoMapper;
using MediatR;
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
    public class GetApprLandBuildingQuery : IRequest<ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprLandBuildingQueryHandler : IRequestHandler<GetApprLandBuildingQuery, ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprWorkPaperLandBuildings> _appr;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private readonly IGenericRepositoryAsync<ApprLandTemplates> _apprLand;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
        private readonly IGenericRepositoryAsync<MLiquidationItem> _mItem;
        private readonly IGenericRepositoryAsync<ApprBuildingFloors> _apprBuildingFloor;
        private readonly IMapper _mapper;

        public GetApprLandBuildingQueryHandler(
            IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> apprSummary, 
            IMapper mapper, 
            IGenericRepositoryAsync<ApprWorkPaperLandBuildings> appr, 
            IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding, 
            IGenericRepositoryAsync<ApprLandTemplates> apprLand, 
            IGenericRepositoryAsync<ApprLiquidation> apprLiquidation, 
            IGenericRepositoryAsync<MLiquidationItem> mItem,
            IGenericRepositoryAsync<ApprBuildingFloors> apprbuildingFloor
            )
        {
            _apprSummary = apprSummary;
            _mapper = mapper;
            _appr = appr;
            _apprBuilding = apprBuilding;
            _apprLand = apprLand;
            _apprLiquidation = apprLiquidation;
            _mItem = mItem;
            _apprBuildingFloor = apprbuildingFloor;
        }
        public async Task<ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>> Handle(GetApprLandBuildingQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var dataVm = _mapper.Map<ApprWorkPaperLandBuildingHeaderResponse>(apprSummary);
                dataVm.MarketData = new List<ApprLandBuildingResponse>();
                dataVm.LiquidationData = new ApprLiquidationLandBuildingResponse
                {
                    LandLiquidationValue = new List<ApprLiquidationResponse>(),
                    BuildingLiquidationValue = new List<ApprLiquidationResponse>(),
                };

                var apprBuilding = await _apprBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprBuilding == null)
                    return ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template bangunan kosong, isi terlebih dahulu sebelum melanjutkan");
                var apprLand = await _apprLand.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprLand == null)
                    return ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template tanah kosong, isi terlebih dahulu sebelum melanjutkan");
                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });
                var mItemLand = await _mItem.GetListByPredicate(x => x.TypeId == "01");
                var mItemBuilding = await _mItem.GetListByPredicate(x => x.TypeId == "03");

                if (apprSummary.ApprWorkPaperLandBuildings.Count == 0 || !Array.Exists(apprSummary.ApprWorkPaperLandBuildings.ToArray(), x => x.DataNumber == 0))
                {
                    var appr = new ApprWorkPaperLandBuildings()
                    {
                        ApprWorkPaperLandBuildingGuid = Guid.NewGuid(),
                        ApprWorkPaperLandBuildingSummaryGuid = apprSummary.ApprWorkPaperLandBuildingSummaryGuid,
                        ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid,
                        ApprLandTemplateGuid = apprLand.ApprLandTemplateGuid,
                        DataNumber = 0,
                    };

                    await _appr.AddAsync(appr);
                }

                if (apprLiquidation == null || apprLiquidation.Count == 0)
                {
                    foreach (var data in mItemLand.Concat(mItemBuilding))
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
                    var apprLiquidLand = apprLiquidation.Where(x => x.LiquidationType == "01");
                    if (apprLiquidLand != null && apprLiquidLand.Count() < mItemLand.Count)
                    {
                        foreach (var data in mItemLand)
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

                    var apprLiquidBuilding = apprLiquidation.Where(x => x.LiquidationType == "03");
                    if (apprLiquidBuilding != null && apprLiquidBuilding.Count() < mItemBuilding.Count)
                    {
                        foreach (var data in mItemBuilding)
                        {
                            if (!Array.Exists(apprLiquidBuilding.ToArray(), x => x.LiquidationType == data.TypeId && x.LiquidationItem == data.ItemId))
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

                //Get Total Building Area
                var apprBuildingFloor = await _apprBuildingFloor.GetListByPredicate(x => x.ApprBuildingTemplateGuid == apprBuilding.ApprEnvironmentGuid);
                double? buildingArea = 0;
                if (apprBuildingFloor != null && apprBuildingFloor.Any())
                {
                    foreach (var apprBF in apprBuildingFloor)
                    {
                        if (apprBF.TotalArea.HasValue) 
                        {
                            buildingArea += apprBF.TotalArea;
                        }
                            
                    }
                }

                apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                foreach (var data in apprSummary.ApprWorkPaperLandBuildings)
                {
                    if (data.DataNumber == 0)
                    {
                        var response = new ApprLandBuildingResponse()
                        {
                            DataNumber = data?.DataNumber,
                            PropertyType = data?.ApprLandTemplates?.ObjectType,
                            Address = data?.ApprLandTemplates?.Address,
                            Rt = data?.ApprLandTemplates?.Rt,
                            Rw = data?.ApprLandTemplates?.Rw,
                            Kelurahan = _mapper.Map<SimpleResponseWithPostCode<string>>(data?.ApprLandTemplates?.WilayahVillages),
                            Kecamatan = _mapper.Map<SimpleResponse<string>>(data?.ApprLandTemplates?.WilayahVillages?.WilayahDistricts),
                            KotaKabupaten = _mapper.Map<SimpleResponse<string>>(data?.ApprLandTemplates?.WilayahVillages?.WilayahDistricts?.WilayahRegencies),
                            Provinsi = _mapper.Map<SimpleResponse<string>>(data?.ApprLandTemplates?.WilayahVillages?.WilayahDistricts?.WilayahRegencies?.WilayahProvinces),
                            DataSource = data?.DataSource,
                            PhoneNumber = data?.PhoneNumber,

                            BuildingCategory = _mapper.Map<SimpleResponse<Guid>>(data?.BuildingCategoryFK),
                            EconomicalAge = data?.EconomicalAge,

                            BuildingArea = buildingArea,
                            YearBuilt = data?.ApprBuildingTemplates?.YearBuilt,
                            RenovatedYear = data?.ApprBuildingTemplates?.RenovatedYear,
                            PctRenovationAdjustment = data?.PctRenovationAdjustment,
                            PctDepreciationAdjustment = data?.PctDepreciationAdjustment,
                            CurrBuildingValue = data?.CurrBuildingValue,

                            LandArea = data?.ApprLandTemplates?.LandAreaValue,
                            FrontageWidth = data?.FrontageWidth,
                            RoadWidth = data?.RoadWidth,
                            LandPosition = _mapper.Map<SimpleResponse<Guid>>(data?.LandPositionFK),
                            Allotment = data?.Allotment,
                        };

                        // if (data.ApprBuildingTemplates != null && data.ApprBuildingTemplates.ApprBuildingFloors.Count > 0)
                        // {
                        //     response.BuildingArea = data.ApprBuildingTemplates.ApprBuildingFloors.Select(x => x.TotalArea).Sum();
                        // }
                        dataVm.MarketData.Add(response);
                    }
                    else
                    {
                        dataVm.MarketData.Add(_mapper.Map<ApprLandBuildingResponse>(data));
                    }
                }

                dataVm.MarketData = dataVm.MarketData.OrderBy(x => x.DataNumber).ToList();

                apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });

                if (apprLiquidation != null && apprLiquidation.Where(x => x.LiquidationType == "01") != null)
                    dataVm.LiquidationData.LandLiquidationValue = _mapper.Map<List<ApprLiquidationResponse>>(apprLiquidation.Where(x => x.LiquidationType == "01"));

                if (apprLiquidation != null && apprLiquidation.Where(x => x.LiquidationType == "03") != null)
                    dataVm.LiquidationData.BuildingLiquidationValue = _mapper.Map<List<ApprLiquidationResponse>>(apprLiquidation.Where(x => x.LiquidationType == "03"));

                return ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        private async Task<ApprWorkPaperLandBuildingSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApprWorkPaperLandBuildings",
                    "ApprWorkPaperLandBuildings.WilayahVillages",
                    "ApprWorkPaperLandBuildings.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperLandBuildings.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperLandBuildings.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperLandBuildings.ApprBuildingTemplates",
                    "ApprWorkPaperLandBuildings.ApprBuildingTemplates.ApprBuildingFloors",
                    "ApprWorkPaperLandBuildings.ApprLandTemplates",
                    "ApprWorkPaperLandBuildings.ApprLandTemplates.WilayahVillages",
                    "ApprWorkPaperLandBuildings.ApprLandTemplates.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperLandBuildings.ApprLandTemplates.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperLandBuildings.ApprLandTemplates.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperLandBuildings.OfferFK",
                    "ApprWorkPaperLandBuildings.BuildingCategoryFK",
                    "ApprWorkPaperLandBuildings.LandDocumentFK",
                    "ApprWorkPaperLandBuildings.LandFormFK",
                    "ApprWorkPaperLandBuildings.LandPositionFK",
                    "ApprWorkPaperLandBuildings.LandConditionFK",
                    "ApprWorkPaperLandBuildings.TopografiFK"
                };
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperLandBuildingSummaries()
                {
                    ApprWorkPaperLandBuildingSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);

            }
            return apprSummary;
        }
    }
}
