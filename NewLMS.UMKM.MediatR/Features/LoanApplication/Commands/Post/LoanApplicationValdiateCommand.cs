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
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class LoanApplicationValidateCommand : LoanApplicationFind, IRequest<ServiceResponse<LoanApplicationValidateResponse>>
    {

    }
    public class LoanApplicationValidateCommandHandler : IRequestHandler<LoanApplicationValidateCommand, ServiceResponse<LoanApplicationValidateResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _LoanApplicationAgunan;
        private readonly IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationFasilitasKredit;
        private readonly IGenericRepositoryAsync<DebtorCouple> _DebtorCouple;
        private readonly IGenericRepositoryAsync<DebtorEmergency> _DebtorEmergency;
        private readonly IMapper _mapper;

        public LoanApplicationValidateCommandHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IGenericRepositoryAsync<RFMARITAL> RFMARITAL,
            IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson,
            IGenericRepositoryAsync<LoanApplicationCollateral> LoanApplicationAgunan,
            IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationFasilitasKredit,
            IGenericRepositoryAsync<DebtorCouple> DebtorCouple,
            IGenericRepositoryAsync<DebtorEmergency> DebtorEmergency,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _LoanApplicationAgunan = LoanApplicationAgunan;
            _LoanApplicationFasilitasKredit = LoanApplicationFasilitasKredit;
            _RFMARITAL = RFMARITAL;
            _DebtorCouple = DebtorCouple;
            _DebtorEmergency = DebtorEmergency;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationValidateResponse>> Handle(LoanApplicationValidateCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var LoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id", new string[] { 
                    "LoanApplicationCreditScoring",
                    "Prospect.RfProduct",
                    "Prospect.RfOwnerCategory",
                    "Debtor",
                    "CompanyEntity",
                    });
                var invalidCounter = 0;
                var errorMessage = "";

                // Tab IDE
                if (LoanApplication.LoanApplicationCreditScoring.BusinessCycle ?? false)
                {
                    invalidCounter += LoanApplication.LoanApplicationCreditScoring.RfBusinessPrimaryCycleId != null ? 0 : 1;
                    invalidCounter += LoanApplication.LoanApplicationCreditScoring.BusinessCycleMonth != null ? 0 : 1;
                }

                invalidCounter += LoanApplication.RfBranchId != null ? 0 : 1;


                if (LoanApplication.Prospect.RfProduct.ProductType == "KUR")
                {
                    if (LoanApplication.Prospect.RfOwnerCategory.OwnDesc.ToLower() == "Perorangan".ToLower())
                    {

                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOReputasiTempatTinggalId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOTingkatKebutuhanId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOCaraTransaksiId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOPengelolaKeuanganId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOHutangPihakLainId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOLokTempatUsahaId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOHubunganPerbankanId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOMutasiPerBulanId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCORiwayatKreditBJBId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOScoringAgunanId != null ? 0 : 1;
                        invalidCounter += LoanApplication.LoanApplicationCreditScoring.RFSCOSaldoRekRataId != null ? 0 : 1;
                    }
                }

                if (invalidCounter > 1 && errorMessage == "")
                {
                    errorMessage += " Data IDE belum lengkap";
                }

                // Data Pemohon
                if (LoanApplication.Prospect.RfProduct.ProductType == "KUR")
                {
                    if (LoanApplication.Prospect.RfOwnerCategory.OwnDesc.ToLower() == "Perorangan".ToLower())
                    {

                        invalidCounter += LoanApplication.Debtor.Fullname != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.PlaceOfBirth != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.DateOfBirth != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.NoIdentity != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.Phone != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.RfEducationId != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.MotherName != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.NumberOfDependents != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.NPWP != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.RfMaritalId != null ? 0 : 1;
                        invalidCounter += LoanApplication.Debtor.RfJobId != null ? 0 : 1;

                        // check marital
                        if (LoanApplication.Debtor.RfMaritalId != null)
                        {
                            var marital = await _RFMARITAL.GetByIdAsync((Guid)LoanApplication.Debtor.RfMaritalId, "Id");

                            if (marital.MR_DESCSIKP.ToLower() == "Kawin".ToLower())
                            {
                                var debtorCouple = await _DebtorCouple.GetByPredicate(x=> x.DebtorCoupleId == LoanApplication.Debtor.NoIdentity);
                                invalidCounter += LoanApplication.Debtor.MarriageCertificateNumber != null ? 0 : 1;
                                invalidCounter += LoanApplication.Debtor.MarriageCertificateDate != null ? 0 : 1;
                                invalidCounter += LoanApplication.Debtor.MarriageCertificateIssuer != null ? 0 : 1;
                                invalidCounter += debtorCouple.RfJobId != null ? 0 : 1;
                                invalidCounter += debtorCouple.Fullname != null ? 0 : 1;
                                invalidCounter += debtorCouple.DebtorCoupleNoIdentity != null ? 0 : 1;
                                invalidCounter += debtorCouple.NPWP != null ? 0 : 1;
                                invalidCounter += debtorCouple.PlaceOfBirth != null ? 0 : 1;
                                invalidCounter += debtorCouple.DateOfBirth != null ? 0 : 1;
                                invalidCounter += debtorCouple.Address != null ? 0 : 1;
                                invalidCounter += debtorCouple.RfZipCodeId != null ? 0 : 1;
                                invalidCounter += debtorCouple.Province != null ? 0 : 1;
                                invalidCounter += debtorCouple.City != null ? 0 : 1;
                                invalidCounter += debtorCouple.District != null ? 0 : 1;
                                invalidCounter += debtorCouple.Neighborhoods != null ? 0 : 1;

                            }
                        }

                        var debtorEmergency = await _DebtorEmergency.GetByPredicate(x=> x.DebtorId == LoanApplication.Debtor.NoIdentity);

                        invalidCounter += debtorEmergency.Fullname != null ? 0 : 1;
                        invalidCounter += debtorEmergency.NoIdentityEmergency != null ? 0 : 1;
                        invalidCounter += debtorEmergency.Address != null ? 0 : 1;
                        invalidCounter += debtorEmergency.RfZipCodeId != null ? 0 : 1;
                        invalidCounter += debtorEmergency.Province != null ? 0 : 1;
                        invalidCounter += debtorEmergency.City != null ? 0 : 1;
                        invalidCounter += debtorEmergency.District != null ? 0 : 1;
                        invalidCounter += debtorEmergency.Neighborhoods != null ? 0 : 1;


                        if (invalidCounter > 1 && errorMessage == "")
                        {
                            errorMessage += " Data pemohon belum lengkap";
                        }
                    }


                    if (LoanApplication.Prospect.RfOwnerCategory.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                    {
                        invalidCounter += LoanApplication.CompanyEntity.CompanyName != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.Address != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.RfZipCodeId != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.Province != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.City != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.District != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.Neighborhoods != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.Phone != null ? 0 : 1;

                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonName != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonAddress != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.RfContactPersonZipCodeId != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonProvince != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonCity != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonDistrict != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonNeighborhoods != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.ContactPersonPhone != null ? 0 : 1;

                        invalidCounter += LoanApplication.CompanyEntity.DeedOfEstablishmentNumber != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.DeedOfEstablishmentDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SKDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.NPWP != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.LatestDeedOfChanges != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.DeedDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SIUPNumber != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SIUPDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.TDPNumber != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.TDPDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.TDPExpiryDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SKDPNumber != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SKDate != null ? 0 : 1;
                        invalidCounter += LoanApplication.CompanyEntity.SKDPExpiryDate != null ? 0 : 1;
                        if (invalidCounter > 1 && errorMessage == "")
                        {
                            errorMessage += " Data pemohon belum lengkap";
                        }

                        // Check LoanApplication Key Person
                        invalidCounter += (await _LoanApplicationKeyPerson.GetListByPredicate(x => x.LoanApplicationId == LoanApplication.Id)).Count > 0 ? 0 : 1;
                        if (invalidCounter > 1 && errorMessage == "")
                        {
                            errorMessage += " Data Key Person masih kosong";
                        }
                    }

                    invalidCounter += LoanApplication.RfDecisionMakerId != null ? 0 : 1;
                    if (invalidCounter > 1 && errorMessage == "")
                    {
                        errorMessage += " Data pemutus belum lengkap";
                    }

                    var ListFasilitasKredit = await _LoanApplicationFasilitasKredit.GetListByPredicate(x => x.LoanApplicationId == LoanApplication.Id);

                    invalidCounter += ListFasilitasKredit.Count > 0 ? 0 : 1;

                    if (invalidCounter > 1 && errorMessage == "")
                    {
                        errorMessage += " Data Fasilitas Kredit masih kosong";
                    }

                    var jumlahAgunan = (await _LoanApplicationAgunan.GetListByPredicate(x => x.LoanApplicationGuid == LoanApplication.Id)).Count;
                    invalidCounter += jumlahAgunan > 0 ? 0 : ListFasilitasKredit.Sum(x=>x.Plafond) > 100000000? 1 : 0;

                    if (invalidCounter > 1 && errorMessage == "")
                    {
                        errorMessage += " Data agunan masih kosong dan jumlah plafon melebihi 100 juta";
                    }
                }

                var valid = invalidCounter == 0;

                var message = valid ? "LoanApplication Valid" : "LoanApplication Invalid";

                var response = new LoanApplicationValidateResponse
                {
                    Id = request.Id,
                    Valid = valid,
                    Message = message + errorMessage
                };

                return ServiceResponse<LoanApplicationValidateResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationValidateResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}