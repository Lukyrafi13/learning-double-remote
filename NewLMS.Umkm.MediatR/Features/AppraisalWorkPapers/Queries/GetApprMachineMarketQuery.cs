using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.MachineWorkPapers;
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
    public class GetApprMachineMarketQuery : IRequest<ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>>
    {
        public Guid AppraisalGuid;
    }

    public class GetApprMachineMarketQueryHandler : IRequestHandler<GetApprMachineMarketQuery, ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprMachineTemplate> _apprMachine;
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarkets> _appr;
        private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
        private readonly IGenericRepositoryAsync<MLiquidationItem> _mItem;
        private IMapper _mapper;

        public GetApprMachineMarketQueryHandler(
            IMapper mapper,
            IGenericRepositoryAsync<ApprWorkPaperMachineMarkets> ApprMachineMarketWorkPaper,
            IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary,
            IGenericRepositoryAsync<ApprMachineTemplate> apprMachine,
            IGenericRepositoryAsync<ApprLiquidation> apprLiquidation,
            IGenericRepositoryAsync<MLiquidationItem> mItem)
        {
            _appr = ApprMachineMarketWorkPaper;
            _mapper = mapper;
            _apprSummary = apprSummary;
            _apprMachine = apprMachine;
            _apprLiquidation = apprLiquidation;
            _mItem = mItem;
        }
        public async Task<ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>> Handle(GetApprMachineMarketQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var dataVm = _mapper.Map<ApprWorkPaperMachineMarketHeaderResponse>(apprSummary);
                dataVm.MarketData = new List<ApprMachineMarketWorkPaperResponse>();
                dataVm.LiquidationData = new List<ApprLiquidationResponse>();

                var apprMachine = await _apprMachine.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprMachine == null)
                    return ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template mesin kosong, isi terlebih dahulu sebelum melanjutkan");

                var apprLiquidation = await _apprLiquidation.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, new string[] {
                    "MLiquidationItem",
                    "MLiquidationItem.MLiquidation",
                    "MLiquidationOption",
                });
                var mItemMachine = await _mItem.GetListByPredicate(x => x.TypeId == "03");

                if (apprSummary.ApprWorkPaperMachineMarkets.Count == 0 || !Array.Exists(apprSummary.ApprWorkPaperMachineMarkets.ToArray(), x => x.DataNumber == 0))
                {
                    var appr = new ApprWorkPaperMachineMarkets()
                    {
                        ApprWorkPaperMachineMarketGuid = Guid.NewGuid(),
                        ApprWorkPaperMachineMarketSummaryGuid = apprSummary.ApprWorkPaperMachineMarketSummaryGuid,
                        ApprMachineTemplateGuid = apprMachine.ApprMachineTemplateGuid,
                        DataNumber = 0,
                    };

                    await _appr.AddAsync(appr);
                }

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

                apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                foreach (var data in apprSummary.ApprWorkPaperMachineMarkets)
                {
                    if (data.DataNumber == 0)
                    {
                        var response = new ApprMachineMarketWorkPaperResponse
                        {
                            DataNumber = data?.DataNumber,
                            DataSource = data?.DataSource,
                            Address = data?.MachineTemplate?.Address,
                            Rt = data?.MachineTemplate?.Rt,
                            Rw = data?.MachineTemplate?.Rw,
                            Kelurahan = _mapper.Map<SimpleResponseWithPostCode<string>>(data?.MachineTemplate?.WilayahVillages),
                            Kecamatan = _mapper.Map<SimpleResponse<string>>(data?.MachineTemplate?.WilayahVillages?.WilayahDistricts),
                            Kota = _mapper.Map<SimpleResponse<string>>(data?.MachineTemplate?.WilayahVillages?.WilayahDistricts.WilayahRegencies),
                            Provinsi = _mapper.Map<SimpleResponse<string>>(data?.MachineTemplate?.WilayahVillages?.WilayahDistricts.WilayahRegencies.WilayahProvinces),
                            TransactionOffer = _mapper.Map<SimpleResponse<Guid>>(data?.TransactionOfferFK),
                            DataDate = data?.DataDate,
                            MachineType = data?.MachineType,
                            Merk = data?.Merk,
                            Type = data?.Type,
                            Capacity = data?.Capacity,
                            ProductionYear = data?.ProductionYear,
                            Condition = data?.Condition,
                            ManufacturerCountry = data?.ManufacturerCountry
                        };

                        dataVm.MarketData.Add(response);
                    }
                    else
                    {
                        dataVm.MarketData.Add(_mapper.Map<ApprMachineMarketWorkPaperResponse>(data));
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

                return ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperMachineMarketSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApprWorkPaperMachineMarkets",
                    "ApprWorkPaperMachineMarkets.WilayahVillages",
                    "ApprWorkPaperMachineMarkets.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperMachineMarkets.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperMachineMarkets.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperMachineMarkets.MachineTemplate",
                    "ApprWorkPaperMachineMarkets.MachineTemplate.WilayahVillages",
                    "ApprWorkPaperMachineMarkets.MachineTemplate.WilayahVillages.WilayahDistricts",
                    "ApprWorkPaperMachineMarkets.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies",
                    "ApprWorkPaperMachineMarkets.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces",
                    "ApprWorkPaperMachineMarkets.TransactionOfferFK",
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
