using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.VehicleWorkPaper;
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
    public class GetApprVehicleQuery : IRequest<ServiceResponse<ApprWorkPaperVehicleHeaderResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprVehicleQueryHandler : IRequestHandler<GetApprVehicleQuery, ServiceResponse<ApprWorkPaperVehicleHeaderResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprWorkPaperVehicles> _appr;
        private readonly IGenericRepositoryAsync<ApprVehicleTemplate> _apprVehicle;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
        private readonly IGenericRepositoryAsync<MLiquidationItem> _mItem;
        private readonly IMapper _mapper;

        public GetApprVehicleQueryHandler(
            IMapper mapper,
            IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> apprSummary,
            IGenericRepositoryAsync<ApprWorkPaperVehicles> appr,
            IGenericRepositoryAsync<ApprVehicleTemplate> apprVehicle,
            IGenericRepositoryAsync<ApprLiquidation> apprLiquidation,
            IGenericRepositoryAsync<MLiquidationItem> mItem)
        {
            _apprSummary = apprSummary;
            _mapper = mapper;
            _appr = appr;
            _apprVehicle = apprVehicle;
            _apprLiquidation = apprLiquidation;
            _mItem = mItem;
        }
        public async Task<ServiceResponse<ApprWorkPaperVehicleHeaderResponse>> Handle(GetApprVehicleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var dataVm = _mapper.Map<ApprWorkPaperVehicleHeaderResponse>(apprSummary);
                dataVm.MarketData = new List<ApprVehicleResponse>();
                dataVm.LiquidationData = new List<ApprLiquidationResponse>();

                var apprVehicle = await _apprVehicle.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprVehicle == null)
                    return ServiceResponse<ApprWorkPaperVehicleHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template bangunan kosong, isi terlebih dahulu sebelum melanjutkan");
                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });
                var mItemVehicle = await _mItem.GetListByPredicate(x => x.TypeId == "03");

                if (apprSummary.ApprWorkPaperVehicles.Count == 0 || !Array.Exists(apprSummary.ApprWorkPaperVehicles.ToArray(), x => x.DataNumber == 0))
                {
                    var appr = new ApprWorkPaperVehicles()
                    {
                        ApprWorkPaperVehicleGuid = Guid.NewGuid(),
                        ApprWorkPaperVehicleSummaryGuid = apprSummary.ApprWorkPaperVehicleSummaryGuid,
                        ApprVehicleTemplateGuid = apprVehicle.ApprVehicleTemplateGuid,
                        DataNumber = 0,
                    };

                    await _appr.AddAsync(appr);
                }

                if (apprLiquidation == null || apprLiquidation.Count == 0)
                {
                    foreach (var data in mItemVehicle)
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
                    if (apprLiquidLand != null && apprLiquidLand.Count() < mItemVehicle.Count)
                    {
                        foreach (var data in mItemVehicle)
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
                foreach (var data in apprSummary.ApprWorkPaperVehicles)
                {
                    if (data.DataNumber == 0)
                    {
                        var response = new ApprVehicleResponse()
                        {
                            DataNumber = data?.DataNumber,
                            Address = data?.Address,
                            Kelurahan = _mapper.Map<SimpleResponseWithPostCode<string>>(data?.WilayahVillages),
                            Kecamatan = _mapper.Map<SimpleResponse<string>>(data?.WilayahVillages.WilayahDistricts),
                            KotaKabupaten = _mapper.Map<SimpleResponse<string>>(data?.WilayahVillages.WilayahDistricts.WilayahRegencies),
                            Provinsi = _mapper.Map<SimpleResponse<string>>(data?.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces),
                            DataType = _mapper.Map<SimpleResponse<Guid>>(data?.DataTypeFK),
                            DataSource = data?.DataSource,
                            PhoneNumber = data?.PhoneNumber,
                            Offering = data?.Offering,
                            DataDate = data?.DataDate,
                            Brand = data?.Brand,
                            BrandType = data?.BrandType,
                            Year = data?.Year,
                            Condition = data?.Condition,
                            BodyAccessories = data?.BodyAccessories,
                            Color = data?.Color,
                            DomicileCity = data?.DomicileCity,
                            Transmission = _mapper.Map<SimpleResponse<Guid>>(data?.TransmissionFK),
                            Odometer = data?.Odometer,

                        };

                        dataVm.MarketData.Add(response);
                    }
                    else
                    {
                        dataVm.MarketData.Add(_mapper.Map<ApprVehicleResponse>(data));
                    }
                }

                dataVm.MarketData = dataVm.MarketData.OrderBy(x => x.DataNumber).ToList();

                apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });

                if (apprLiquidation != null && apprLiquidation.Where(x => x.LiquidationType == "03") != null)
                    dataVm.LiquidationData = _mapper.Map<List<ApprLiquidationResponse>>(apprLiquidation.Where(x => x.LiquidationType == "03"));

                return ServiceResponse<ApprWorkPaperVehicleHeaderResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperVehicleHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        private async Task<ApprWorkPaperVehicleSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApprWorkPaperVehicles",
                    "ApprWorkPaperVehicles.WilayahVillages",
                    "ApprWorkPaperVehicles.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperVehicles.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperVehicles.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperVehicles.ApprVehicleTemplate",
                    "ApprWorkPaperVehicles.TransmissionFK"
                };
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperVehicleSummaries()
                {
                    ApprWorkPaperVehicleSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);

            }
            return apprSummary;
        }
    }
}
