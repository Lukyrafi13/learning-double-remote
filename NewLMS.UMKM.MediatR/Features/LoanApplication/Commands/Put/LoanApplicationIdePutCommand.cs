using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class LoanApplicationIDEPutCommand : LoanApplicationIDEPutRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }
    public class LoanApplicationIDEPutCommandHandler : IRequestHandler<LoanApplicationIDEPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        // private readonly IGenericRepositoryAsync<LoanApplicationFasilitasKredit> _LoanApplicationFasilitasKredit;
        private readonly IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RfBusinessPrimaryCycle;
        private readonly IGenericRepositoryAsync<LoanApplicationCreditScoring> _LoanApplicationCreditScoring;
        private readonly IMapper _mapper;

        public LoanApplicationIDEPutCommandHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            // IGenericRepositoryAsync<LoanApplicationFasilitasKredit> LoanApplicationFasilitasKredit,
            IGenericRepositoryAsync<RfBusinessPrimaryCycle> RfBusinessPrimaryCycle,
            IGenericRepositoryAsync<LoanApplicationCreditScoring> LoanApplicationCreditScoring,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            // _LoanApplicationFasilitasKredit = LoanApplicationFasilitasKredit;
            _RfBusinessPrimaryCycle = RfBusinessPrimaryCycle;
            _LoanApplicationCreditScoring = LoanApplicationCreditScoring;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationIDEPutCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var existingLoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id");

                // var siklusChanged = existingLoanApplication.RfBusinessPrimaryCycleId != request.RfBusinessPrimaryCycleId;

                var CreditScoring = await _LoanApplicationCreditScoring.GetByPredicate(x=>x.LoanApplicationGuid == request.Id);

                if(CreditScoring == null){
                    CreditScoring = new LoanApplicationCreditScoring(){
                        LoanApplicationGuid = request.Id,
                    };
                }

                CreditScoring.BusinessCycleMonth = request.BusinessCycleMonth;
                CreditScoring.RfBusinessPrimaryCycleId = request.RfBusinessPrimaryCycleId;
                CreditScoring.BusinessCycle = request.BusinessCycle;
                CreditScoring.RFSCOReputasiTempatTinggalId = request.RFSCOReputasiTempatTinggalId;
                CreditScoring.RFSCOTingkatKebutuhanId = request.RFSCOTingkatKebutuhanId;
                CreditScoring.RFSCOCaraTransaksiId = request.RFSCOCaraTransaksiId;
                CreditScoring.RFSCOPengelolaKeuanganId = request.RFSCOPengelolaKeuanganId;
                CreditScoring.RFSCOHutangPihakLainId = request.RFSCOHutangPihakLainId;
                CreditScoring.RFSCOLokTempatUsahaId = request.RFSCOLokTempatUsahaId;
                CreditScoring.RFSCOHubunganPerbankanId = request.RFSCOHubunganPerbankanId;
                CreditScoring.RFSCOMutasiPerBulanId = request.RFSCOMutasiPerBulanId;
                CreditScoring.RFSCORiwayatKreditBJBId = request.RFSCORiwayatKreditBJBId;
                CreditScoring.RFSCOScoringAgunanId = request.RFSCOScoringAgunanId;
                CreditScoring.RFSCOSaldoRekRataId = request.RFSCOSaldoRekRataId;
                
                // if (request.RfBusinessPrimaryCycleId == null && (request.SiklusUsaha??false)){
                //     return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "RF Siklus Usaha dengan Id "+ request.RfBusinessPrimaryCycleId+" tidak ditemukan");
                // }
                
                // RfBusinessPrimaryCycle siklusUsahaPokok = request.RfBusinessPrimaryCycleId==null ? null : await _RfBusinessPrimaryCycle.GetByIdAsync((Guid)request.RfBusinessPrimaryCycleId, "Id");

                // if (siklusChanged){

                //     var updateListFasilitas = new List<LoanApplicationFasilitasKredit>();

                //     var sameDateNextMonth = new DateTime(existingLoanApplication.CreatedDate.Year, existingLoanApplication.CreatedDate.Month+1, existingLoanApplication.CreatedDate.Day ); 
                //     var diffDays = Math.Abs((existingLoanApplication.CreatedDate - sameDateNextMonth).Days);
                //     var siklusUsahaAkhir = siklusUsahaPokok?.SiklusCode == "02";
                //     var LoanApplicationFasilitasKredits = await _LoanApplicationFasilitasKredit.GetListByPredicate(x=>x.LoanApplicationId == existingLoanApplication.Id, new string[]{"TenorKredit"}); 

                //     foreach (var fasilitasKredit in LoanApplicationFasilitasKredits)
                //     {
                //         if (fasilitasKredit.TenorKredit.Tenor == null){
                //             continue;
                //         }

                //         fasilitasKredit.AngsuranBunga = siklusUsahaAkhir ? 0 : 
                //         fasilitasKredit.PlafondYangDiajukan * fasilitasKredit.TingkatSukuBunga / 100 /360 * diffDays;

                //         fasilitasKredit.AngsuranPokok = (float)(siklusUsahaAkhir ? fasilitasKredit.PlafondYangDiajukan :
                //         fasilitasKredit.PlafondYangDiajukan / fasilitasKredit.TenorKredit.Tenor);

                //         updateListFasilitas.Add(fasilitasKredit);
                //     }

                //     await _LoanApplicationFasilitasKredit.UpdateRangeAsync(updateListFasilitas);
                // }

                await _LoanApplicationCreditScoring.UpdateAsync(CreditScoring);
                await _LoanApplication.UpdateAsync(existingLoanApplication);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}