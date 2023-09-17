/*using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalResults;
using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.AppraisalResult.Queries
{
    public class GetAppraisalResultQuery : IRequest<ServiceResponse<AppraisalResultResponse>>
    {
        public Guid LoanApplicationGuid;
    }

    public class GetAppraisalResultQueryHandler : IRequestHandler<GetAppraisalResultQuery, ServiceResponse<AppraisalResultResponse>>
    {
        private readonly IGenericRepositoryAsync<AppraisalResults> _appraisalResult;
        private readonly IMapper _mapper;

        public GetAppraisalResultQueryHandler(
            IGenericRepositoryAsync<AppraisalResults> appraisalResult,
            IMapper mapper
        )
        {
            _appraisalResult = appraisalResult;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppraisalResultResponse>> Handle(GetAppraisalResultQuery request, CancellationToken cancellationToken)
        {
            var dataVm = new AppraisalResultResponse()
            {
                CollateralAppraisalList = new List<AppraisalResultCollateralAppraisalResponse>(),
                CollateralBindingList = new List<AppraisalResultCollateralBindingResponse>(),
                CollateralCoverageFixedList = new List<AppraisalResultCollateralCoverageFixedResponse>(),
                TotalFixedAssetAndDeposito = null,
                CollateralCoverageLoanList = new List<AppraisalResultCollateralCoverageLoanResponse>(),
                TotalLoanAndStock = null,
                TotalCollateral = null,
                TotalCoverageList = new List<AppraisalResultTotalCoverageResponse>(),
                Remark = null
            };

            try
            {
                var appraisalResult = await GetAppraisalResult(request.LoanApplicationGuid);

                if (appraisalResult != null)
                {
                    var validasiArray = new string[] { "10", "20", "23", "31", "310", "32", "320", "33", "40", "41", "410" };
                    var landBuildingArray = new string[] { "176", "189", "113", "187" };
                    var machineArray = new string[] { "108", "210", "208", "230" };
                    var shopAppartmentArray = new string[] { "110", "109", "103", "102", "21", "11" };
                    var vehicleArray = new string[] { "204" };
                    var collateralAppraisals = appraisalResult?.LoanApplications?.Debtors?.DebtorCollaterals?.Where(x => !x.IsDeleted);
                    var collateralInsurance = appraisalResult?.LoanApplications?.Debtors?.DebtorCollaterals?.FirstOrDefault()?.CollateralInsurances?.FirstOrDefault();
                    if (collateralAppraisals != null && collateralAppraisals.Count() > 0)
                    {
                        foreach (var data in collateralAppraisals)
                        {
                            var collateralAppraisal = new AppraisalResultCollateralAppraisalResponse
                            {
                                DebtorCollateralGuid = data.DebtorCollateralGuid,
                                AppraisalGuid = data?.Appraisals?.Count == 0 ? null : data.Appraisals.FirstOrDefault().AppraisalGuid,
                                CollateralCode = new SimpleResponse<string> { Id = data?.RfCollateral?.CollateralCode, Description = data?.RfCollateral?.Description },
                                PledgeType = new SimpleResponse<string> { Id = data?.RfPledge?.PledgeId, Description = data?.RfPledge?.PledgeTypeDesc },
                                NoOwnershipProof = data?.NoOwnershipProof,
                                MarketInternalValue = 0,
                                LiquidasiInternalValue = 0,
                                MarketExternalValue = 0,
                                LiquidasiExternalValue = 0,
                                CollateralInsurance = collateralInsurance?.EstimatePremi == null ? 0 : collateralInsurance?.EstimatePremi,
                                AppraisalStatus = data?.Appraisals?.FirstOrDefault()?.AppraisalStatus == null || data?.Appraisals?.FirstOrDefault()?.AppraisalStatus == "In Progress" ? "In Progress" : "Done"
                            };
                            if (Array.Exists(validasiArray, e => e == data.RfCollateralCode))
                            {
                                var validasiVerifikasiAgunan = data.Appraisals.Count == 0 ? null : data.Appraisals.FirstOrDefault().ApprReceivableVerifications.Count == 0 ? null : data.Appraisals.FirstOrDefault().ApprReceivableVerifications.FirstOrDefault();
                                if (validasiVerifikasiAgunan != null)
                                {
                                    if (data.Appraisals.FirstOrDefault().isInternal)
                                    {
                                        collateralAppraisal.MarketInternalValue = Convert.ToDecimal(validasiVerifikasiAgunan.Population);
                                        collateralAppraisal.LiquidasiInternalValue = Convert.ToDecimal(validasiVerifikasiAgunan.Population);
                                    }
                                    else
                                    {
                                        collateralAppraisal.MarketExternalValue = Convert.ToDecimal(validasiVerifikasiAgunan.Population);
                                        collateralAppraisal.LiquidasiExternalValue = Convert.ToDecimal(validasiVerifikasiAgunan.Population);
                                    }
                                }
                            }
                            else if (Array.Exists(landBuildingArray, e => e == data.RfCollateralCode))
                            {
                                var workPaper = data?.Appraisals?.FirstOrDefault()?.ApprWorkPaperLandBuildingSummaries?.FirstOrDefault();
                                if (workPaper != null)
                                {
                                    if (data.Appraisals.FirstOrDefault().isInternal)
                                    {
                                        collateralAppraisal.MarketInternalValue = workPaper.CurrAssetMarketValue;
                                        collateralAppraisal.LiquidasiInternalValue = workPaper.LandLiquidationValue;
                                    }
                                    else
                                    {
                                        collateralAppraisal.MarketExternalValue = workPaper.CurrAssetMarketValue;
                                        collateralAppraisal.LiquidasiExternalValue = workPaper.LandLiquidationValue;
                                    }
                                }
                            }
                            else if (Array.Exists(machineArray, e => e == data.RfCollateralCode))
                            {
                                var workPaper = data?.Appraisals?.FirstOrDefault()?.ApprWorkPaperMachineMarketSummaries?.FirstOrDefault();
                                if (workPaper != null)
                                {
                                    if (data.Appraisals.FirstOrDefault().isInternal)
                                    {
                                        collateralAppraisal.MarketInternalValue = workPaper.CurrMarketValue;
                                        collateralAppraisal.LiquidasiInternalValue = workPaper.LiquidationValue;
                                    }
                                    else
                                    {
                                        collateralAppraisal.MarketExternalValue = workPaper.CurrMarketValue;
                                        collateralAppraisal.LiquidasiExternalValue = workPaper.LiquidationValue;
                                    }
                                }
                            }
                            else if (Array.Exists(shopAppartmentArray, e => e == data.RfCollateralCode))
                            {
                                var workPaper = data?.Appraisals?.FirstOrDefault()?.ApprWorkPaperShopApartmentSummaries?.FirstOrDefault();
                                if (workPaper != null)
                                {
                                    if (data.Appraisals.FirstOrDefault().isInternal)
                                    {
                                        collateralAppraisal.MarketInternalValue = workPaper.CurrShopMarketValue;
                                        collateralAppraisal.LiquidasiInternalValue = workPaper.LiquidationValue;
                                    }
                                    else
                                    {
                                        collateralAppraisal.MarketExternalValue = workPaper.CurrShopMarketValue;
                                        collateralAppraisal.LiquidasiExternalValue = workPaper.LiquidationValue;
                                    }
                                }
                            }
                            else if (Array.Exists(vehicleArray, e => e == data.RfCollateralCode))
                            {
                                var workPaper = data?.Appraisals?.FirstOrDefault()?.ApprWorkPaperVehicleSummaries?.FirstOrDefault();
                                if (workPaper != null)
                                {
                                    if (data.Appraisals.FirstOrDefault().isInternal)
                                    {
                                        collateralAppraisal.MarketInternalValue = workPaper.CurrShopValue;
                                        collateralAppraisal.LiquidasiInternalValue = workPaper.LiquidationValue;
                                    }
                                    else
                                    {
                                        collateralAppraisal.MarketExternalValue = workPaper.CurrShopValue;
                                        collateralAppraisal.LiquidasiExternalValue = workPaper.LiquidationValue;
                                    }
                                }
                            }
                            dataVm.CollateralAppraisalList.Add(collateralAppraisal);
                        }
                    }

                    var collateralbindings = appraisalResult.AppraisalResultCollateralBindings.Where(x => !x.IsDeleted).ToList();
                    var collateralBindingMapped = _mapper.Map<List<AppraisalResultCollateralBindingResponse>>(collateralbindings);
                    dataVm.CollateralBindingList = collateralBindingMapped;
                    // for (int i = 0; i < collateralBindingMapped.Count; i++)
                    // {
                    //     collateralBindingMapped[i].FacilityGuid = collateralbindings[i]?.LoanFacilities == null
                    //         ? null : new SimpleResponse<Guid>
                    //         {
                    //             Id = collateralbindings[i].LoanFacilities.LoanFacilityGuid,
                    //             Description = $"{collateralbindings[i].LoanFacilities.RFCreditSubProducts.CreditSubProductName} (${collateralbindings[i].LoanFacilities.Plafond})"
                    //         };
                    //     dataVm.CollateralBindingList.Add(collateralBindingMapped[i]);
                    // }

                    var fixedAssets = appraisalResult?.AppraisalResultCollateralBindings?.Where(x => x.RFCollaterals.CollateralTypeId == 3 && !x.IsDeleted)?.ToList();
                    // var fixedAssetsMapped = _mapper.Map<List<AppraisalResultCollateralCoverageFixedResponse>>(fixedAssets);
                    // dataVm.CollateralCoverageFixedList = fixedAssetsMapped;
                    if (fixedAssets != null && fixedAssets.Count() > 0)
                    {
                        for (int i = 0; i < fixedAssets.Count(); i++)
                        {
                            var mapped = _mapper.Map<AppraisalResultCollateralCoverageFixedResponse>(fixedAssets[i]);
                            if (fixedAssets[i]?.LoanFacilities != null)
                            {
                                mapped.PctCoverage = fixedAssets[i]?.BindingValue == null ? null : (double)((decimal)fixedAssets[i].BindingValue / (decimal)fixedAssets[i].LoanFacilities.Plafond);
                                dataVm.CollateralCoverageFixedList.Add(mapped);
                            }
                        }
                    }

                    var nonFixedAssets = appraisalResult?.AppraisalResultCollateralBindings?.Where(x => x.RFCollaterals.CollateralTypeId == 5 && !x.IsDeleted)?.ToList();
                    // var nonFixedAssetsMapped = _mapper.Map<List<AppraisalResultCollateralCoverageLoanResponse>>(nonFixedAssets);
                    // dataVm.CollateralCoverageLoanList = nonFixedAssetsMapped;
                    if (nonFixedAssets != null && nonFixedAssets.Count() > 0)
                    {
                        for (int i = 0; i < nonFixedAssets.Count(); i++)
                        {
                            var mapped = _mapper.Map<AppraisalResultCollateralCoverageLoanResponse>(nonFixedAssets[i]);
                            if (nonFixedAssets[i]?.LoanFacilities != null)
                            {
                                mapped.PctCoverage = nonFixedAssets[i]?.BindingValue == null ? null : (double)((decimal)nonFixedAssets[i].BindingValue / (decimal)nonFixedAssets[i].LoanFacilities.Plafond);
                                dataVm.CollateralCoverageLoanList.Add(mapped);
                            }
                        }
                    }

                    var totalCoverages = appraisalResult?.LoanApplications?.LoanFacilities?.Where(x => !x.IsDeleted).ToList();
                    if (totalCoverages != null && totalCoverages.Count() > 0)
                    {
                        for (int i = 0; i < totalCoverages.Count(); i++)
                        {
                            double? pct = 0;
                            var facilityRelavantFixed = dataVm.CollateralCoverageFixedList?.Where(x => x?.LoanFacility?.Id == totalCoverages[i].LoanFacilityGuid);
                            var facilityRelavantNonFixed = dataVm.CollateralCoverageLoanList?.Where(x => x?.LoanFacility?.Id == totalCoverages[i].LoanFacilityGuid);

                            pct += facilityRelavantFixed?.Select(x => x.PctCoverage)?.Sum() == null ? 0 : facilityRelavantFixed?.Select(x => x.PctCoverage)?.Sum();
                            pct += facilityRelavantNonFixed?.Select(x => x.PctCoverage).Sum() == null ? 0 : facilityRelavantNonFixed?.Select(x => x.PctCoverage).Sum();

                            var totalCoverage = new AppraisalResultTotalCoverageResponse
                            {
                                LoanFacility = _mapper.Map<SimpleResponseWithCurrency<Guid>>(totalCoverages[i]),
                                PctTotalCoverage = pct,
                                PctTotalFacilityCoverage = pct
                            };
                            dataVm.TotalCoverageList.Add(totalCoverage);
                        }
                    }

                    dataVm.TotalFixedAssetAndDeposito = dataVm?.CollateralCoverageFixedList?.Select(x => x.BindingValue)?.Sum();
                    dataVm.TotalLoanAndStock = dataVm?.CollateralCoverageLoanList?.Select(x => x.BindingValue)?.Sum();
                    if (!(dataVm.TotalFixedAssetAndDeposito == null && dataVm.TotalLoanAndStock == null))
                    {
                        dataVm.TotalCollateral = (dataVm.TotalFixedAssetAndDeposito == null ? 0 : dataVm.TotalFixedAssetAndDeposito) + (dataVm?.TotalLoanAndStock == null ? 0 : dataVm?.TotalLoanAndStock);
                    }

                    dataVm.Remark = appraisalResult.Remark;
                }

                return ServiceResponse<AppraisalResultResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppraisalResultResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private async Task<AppraisalResults> GetAppraisalResult(Guid LoanApplicationGuid)
        {
            var includes = new string[] {
                "LoanApplications",
                "LoanApplications.Debtors",
                "LoanApplications.Debtors.DebtorCollaterals.RfCollateral",
                "LoanApplications.Debtors.DebtorCollaterals.RfPledge",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals.ApprReceivableVerifications",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals.ApprWorkPaperLandBuildingSummaries",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals.ApprWorkPaperMachineMarketSummaries",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals.ApprWorkPaperShopApartmentSummaries",
                "LoanApplications.Debtors.DebtorCollaterals.Appraisals.ApprWorkPaperVehicleSummaries",
                "LoanApplications.Debtors.DebtorCollaterals.CollateralInsurances",
                "LoanApplications.LoanFacilities",
                "LoanApplications.LoanFacilities.RFCreditSubProducts",
                "LoanApplications.LoanFacilities.RFCreditSubProducts.RFCreditNatures",
                "AppraisalResultCollateralBindings",
                "AppraisalResultCollateralBindings.RFCollaterals",
                "AppraisalResultCollateralBindings.BindingFK",
                "AppraisalResultCollateralBindings.BindingTypeFK",
                "AppraisalResultCollateralBindings.LoanFacilities",
                "AppraisalResultCollateralBindings.LoanFacilities.RFCreditSubProducts",
                "AppraisalResultCollateralBindings.LoanFacilities.RFCreditSubProducts.RFCreditNatures"
            };
            var data = await _appraisalResult.GetByIdAsync(LoanApplicationGuid, "LoanApplicationGuid", includes);
            if (data == null)
            {
                var appraisalResult = new AppraisalResults
                {
                    AppraisalResultGuid = Guid.NewGuid(),
                    LoanApplicationGuid = LoanApplicationGuid
                };

                await _appraisalResult.AddAsync(appraisalResult);

                return await _appraisalResult.GetByIdAsync(LoanApplicationGuid, "LoanApplicationGuid", includes);
            }
            return data;
        }
    }
}
*/