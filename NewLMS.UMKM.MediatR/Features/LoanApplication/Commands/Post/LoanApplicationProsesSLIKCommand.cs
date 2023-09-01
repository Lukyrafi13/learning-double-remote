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
using Hangfire;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class LoanApplicationProsesSLIKCommand : LoanApplicationFind, IRequest<ServiceResponse<LoanApplicationProsesResponseDto>>
    {
        public string NamaUser { get; set; }
    }
    public class LoanApplicationProsesSLIKCommandHandler : IRequestHandler<LoanApplicationProsesSLIKCommand, ServiceResponse<LoanApplicationProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _LoanApplicationCollateral;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IGenericRepositoryAsync<RfStage> _stages;
        private readonly IGenericRepositoryAsync<DebtorCouple> _DebtorCouple;
        private readonly IGenericRepositoryAsync<LoanApplicationStageLogs> _stageLogs;
        private readonly IGenericRepositoryAsync<Prescreening> _prescreening;

        public LoanApplicationProsesSLIKCommandHandler(
                IGenericRepositoryAsync<LoanApplication> LoanApplication,
                IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson,
                IGenericRepositoryAsync<LoanApplicationCollateral> LoanApplicationCollateral,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData,
                IGenericRepositoryAsync<SlikRequest> SlikRequest,
                IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
                IGenericRepositoryAsync<RfStage> stages,
                IGenericRepositoryAsync<DebtorCouple> DebtorCouple,
                IGenericRepositoryAsync<LoanApplicationStageLogs> stageLogs,
                IGenericRepositoryAsync<Prescreening> prescreening
            )
        {
            _LoanApplication = LoanApplication;
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _LoanApplicationCollateral = LoanApplicationCollateral;
            _Prospect = Prospect;
            _SIKPResponseData = SIKPResponseData;
            _SlikRequest = SlikRequest;
            _SlikRequestObject = SlikRequestObject;
            _stages = stages;
            _stageLogs = stageLogs;
            _prescreening = prescreening;
        }

        public async Task<ServiceResponse<LoanApplicationProsesResponseDto>> ProsesKeSLIK(LoanApplication LoanApplication, LoanApplicationProsesSLIKCommand request, LoanApplicationProsesResponseDto response, List<LoanApplicationCollateral> agunans)
        {
            var SlikRequest = await _SlikRequest.GetByPredicate(x => x.LoanApplicationId == request.Id);

            if (SlikRequest == null)
            {
                // Assign new slik
                SlikRequest = new SlikRequest
                {
                    ProcessStatus = 0,
                    AdminVerified = 0,
                    LoanApplicationId = LoanApplication.Id,
                };

                var newSlikRequest = await _SlikRequest.AddAsync(SlikRequest);
                response.SLIKId = SlikRequest.Id;

                // Input pemohon
                if (LoanApplication.Prospect.RfOwnerCategory.OwnDesc.ToLower() == "Perorangan".ToLower())
                {
                    // Tipe Debitur
                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 1,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = LoanApplication.Debtor.Fullname,
                        NPWP = LoanApplication.Debtor.NPWP,
                        NoIdentity = LoanApplication.Debtor.NoIdentity,
                        DateOfBirth = (DateTime)LoanApplication.Debtor.DateOfBirth,
                        PlaceOfBirth = LoanApplication.Debtor.PlaceOfBirth,
                        ApplicationStatus = "Perorangan",
                        RoboSlik = false,
                        Automatic = true,
                    };

                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    if (LoanApplication.Debtor.RfMarital.MR_DESC.ToLower() == "Menikah".ToLower())
                    {
                        var debtorCouple = await _DebtorCouple.GetByPredicate(x=>x.DebtorCoupleId == LoanApplication.Debtor.NoIdentity);
                        // Pasangan
                        var SilkReqObjPasangan = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = debtorCouple.Fullname,
                            NPWP = debtorCouple.NPWP,
                            NoIdentity = debtorCouple.DebtorCoupleNoIdentity,
                            DateOfBirth = (DateTime)debtorCouple.DateOfBirth,
                            PlaceOfBirth = debtorCouple.PlaceOfBirth,
                            ApplicationStatus = "Perorangan",
                            RoboSlik = false,
                            Automatic = true,
                        };

                        await _SlikRequestObject.AddAsync(SilkReqObjPasangan);
                    }
                }
                if (LoanApplication.Prospect.RfOwnerCategory.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                {
                    // Perusahaan
                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 2,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = LoanApplication.CompanyEntity.CompanyName,
                        NPWP = LoanApplication.CompanyEntity.NPWP,
                        NoIdentity = LoanApplication.CompanyEntity.DeedOfEstablishmentNumber,
                        DateOfBirth = (DateTime)LoanApplication.CompanyEntity.DeedOfEstablishmentDate,
                        PlaceOfBirth = LoanApplication.CompanyEntity.Address,
                        ApplicationStatus = "Badan Usaha",
                        RoboSlik = false,
                        Automatic = true,
                    };

                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    // Key Person
                    var LoanApplicationKeyPersons = await _LoanApplicationKeyPerson.GetListByPredicate(x => x.LoanApplicationId == LoanApplication.Id, new string[] { "RfMarital" });

                    foreach (var LoanApplicationKeyPerson in LoanApplicationKeyPersons)
                    {
                        var SilkReqObjKey = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = LoanApplicationKeyPerson.Fullname,
                            NPWP = LoanApplicationKeyPerson.NPWP,
                            NoIdentity = LoanApplicationKeyPerson.NoIdentity,
                            DateOfBirth = (DateTime)LoanApplicationKeyPerson.DateOfBirth,
                            PlaceOfBirth = LoanApplicationKeyPerson.PlaceOfBirth,
                            ApplicationStatus = "Perorangan",
                            RoboSlik = false,
                            Automatic = true,
                        };
                        await _SlikRequestObject.AddAsync(SilkReqObjKey);

                        if (LoanApplicationKeyPerson.RfMarital.MR_DESC.ToLower() == "Menikah".ToLower())
                        {

                            // Pasangan
                            // var SilkReqObjKeyPasangan = new SlikRequestObject
                            // {
                            //     SlikObjectTypeId = 1,
                            //     SlikRequestId = SlikRequest.Id,
                            //     Fullname = LoanApplicationKeyPerson.NamaLengkLoanApplicationasangan,
                            //     NPWP = LoanApplication.NPWPPasangan,
                            //     NoIdentity = LoanApplication.NoKTPPasangan,
                            //     DateOfBirth = (DateTime)LoanApplication.TanggalLahirPasangan,
                            //     PlaceOfBirth = LoanApplication.TempatLahirPasangan,
                            //     LoanApplicationlicationStatus = "Perorangan",
                            //     RoboSlik = false,
                            // };

                            // await _SlikRequestObject.AddAsync(SilkReqObjKeyPasangan);
                        }
                    }
                }

                foreach (var agunan in agunans)
                {
                    if ((agunan.CollateralOwnedByDebtor ?? false )|| agunan.ParamRealationCol.Description.ToLower() == "SUAMI/ISTRI".ToLower())
                    {
                        continue;
                    }

                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 1,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = agunan.OwnerName,
                        NPWP = agunan.OwnerNPWP,
                        NoIdentity = agunan.OwnerNoIdentity,
                        DateOfBirth = (DateTime)agunan.OwnerDateOfBirth,
                        PlaceOfBirth = agunan.OwnerPlaceOfBirth,
                        ApplicationStatus = "Perorangan",
                        RoboSlik = false,
                        Automatic = true,
                    };
                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    if (agunan.RfMarital.MR_DESC.ToLower() == "Menikah".ToLower())
                    {

                        // Pasangan
                        var SilkReqObjPasangan = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = agunan.CoupleName,
                            NPWP = agunan.CoupleNPWP,
                            NoIdentity = agunan.CoupleNoIdentity,
                            DateOfBirth = (DateTime)agunan.CoupleDateOfBirth,
                            PlaceOfBirth = agunan.CouplePlaceOfBirth,
                            ApplicationStatus = "Perorangan",
                            RoboSlik = false,
                            Automatic = true,
                        };

                        await _SlikRequestObject.AddAsync(SilkReqObjPasangan);
                    }
                }
            }
            else
            {
                // Reset their process status
                SlikRequest.AdminVerified = 0;
                SlikRequest.ProcessStatus = 0;

                await _SlikRequest.UpdateAsync(SlikRequest);
            }

            // Change LoanApplication status
            var stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.1");
            var previousStage = await _stages.GetByPredicate(x => x.Code == "2.0");

            if (LoanApplication.LatestStage?.Code == "4.2.1")
            {
                var failResp = ServiceResponse<LoanApplicationProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "LoanApplication sudah diproses sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            if (LoanApplication.LatestStage?.Code == "0.0")
            {
                var failResp = ServiceResponse<LoanApplicationProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "LoanApplication sudah ditolak sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            await _Prospect.UpdateAsync(LoanApplication.Prospect);

            // Update LoanApplication History
            var oldLog = await _stageLogs.GetByPredicate(x => x.LoanApplicationId == LoanApplication.Id && x.StageId == previousStage.StageId);
            oldLog.ModifiedDate = DateTime.Now;
            oldLog.ExecutedDate = DateTime.Now.ToLocalTime();
            oldLog.TargetStage = stageFound.StageId;
            oldLog.BackStaged = false;
            oldLog.Aging = ((DateTime)oldLog.ExecutedDate - oldLog.CreatedDate).Days + " HARI";

            await _stageLogs.UpdateAsync(oldLog);

            var newLog = new LoanApplicationStageLogs
            {
                LoanApplicationId = LoanApplication.Id,
                StageId = stageFound.StageId,
            };

            await _stageLogs.AddAsync(newLog);

            response.LoanApplicationId = LoanApplication.Id;
            response.SLIKId = SlikRequest.Id;
            response.Stage = stageFound.Description;
            response.Message = "LoanApplication berhasil diproses ke SLIK";

            // if (SlikRequest.StatusCheckingDuplikasi == 0 || (SlikRequest.StatusCheckingDuplikasi == 2 && (SlikRequest.IsCheckingError??false))){
            //     BackgroundJob.Enqueue<DuplicationCheckTask>(x=> x.DuplicationCheck(SlikRequest.Id));
            // }


            return ServiceResponse<LoanApplicationProsesResponseDto>.ReturnResultWith200(response);
        }
        public async Task<ServiceResponse<LoanApplicationProsesResponseDto>> Handle(LoanApplicationProsesSLIKCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new LoanApplicationProsesResponseDto();

                var LoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "Prospect.RfProduct",
                        "Prospect.RfOwnerCategory",
                        "Debtor",
                        "Debtor.RfMarital",
                        "Prospect",
                        "Prospect.RfSectorLBU3",
                        "Prospect.RfSectorLBU3.RfSectorLBU2",
                        "LoanApplicationStageLogs"
                    }
                );
                if (LoanApplication == null)
                {
                    var failResp = ServiceResponse<LoanApplicationProsesResponseDto>.Return404("Data LoanApplication not found");
                    failResp.Success = false;
                    return failResp;
                }


                var SIKP = await _SIKPResponseData.GetByPredicate(x => x.LoanApplicationId == request.Id);

                if (SIKP == null)
                {
                    if (LoanApplication.Prospect.RfProduct.ProductType == "KUR")
                    {

                        // Assign New SIKP
                        SIKP = new SIKPResponseData
                        {
                            LoanApplicationId = LoanApplication.Id,

                            RfOwnerCategoryId = LoanApplication.RfOwnerCategoryId,
                            NoKTP = LoanApplication.Debtor.NoIdentity,
                            RfSectorLBU1Code = LoanApplication.Prospect.RfSectorLBU3.RfSectorLBU2.RfSectorLBU1Code,
                            RfSectorLBU2Code = LoanApplication.Prospect.RfSectorLBU3.RfSectorLBU2Code,
                            RfSectorLBU3Code = LoanApplication.Prospect.RfSectorLBU3Code,
                            NPWP = LoanApplication.Debtor.NPWP,
                        };

                        if (LoanApplication.Prospect.RfOwnerCategory.OwnCode == "01"){
                            SIKP.NPWP = LoanApplication.Debtor.NPWP; 
                            SIKP.NamaDebitur = LoanApplication.Debtor.Fullname; 
                            SIKP.TanggalLahir = LoanApplication.Debtor.DateOfBirth; 
                            SIKP.RfGenderId = LoanApplication.Debtor.RfGenderId; 
                            SIKP.RFMaritalId = LoanApplication.Debtor.RfMaritalId; 
                            SIKP.RFEducationId = LoanApplication.Debtor.RfEducationId; 
                            SIKP.RFJobId = LoanApplication.Debtor.RfJobId; 
                            SIKP.Alamat = LoanApplication.Debtor.Address; 
                            SIKP.Propinsi = LoanApplication.Debtor.Province; 
                            SIKP.KabupatenKota = LoanApplication.Debtor.City; 
                            SIKP.Kecamatan = LoanApplication.Debtor.District; 
                            SIKP.Kelurahan = LoanApplication.Debtor.Neighborhoods; 
                            SIKP.RfZipCodeId = LoanApplication.Debtor.RfZipCodeId;
                            
                            SIKP.AlamatUsaha = LoanApplication.CompanyEntity.Address;
                            SIKP.PropinsiUsaha = LoanApplication.CompanyEntity.Province;
                            SIKP.KabupatenKotaUsaha = LoanApplication.CompanyEntity.City;
                            SIKP.KecamatanUsaha = LoanApplication.CompanyEntity.District;
                            SIKP.KelurahanUsaha = LoanApplication.CompanyEntity.Neighborhoods;
                            SIKP.RfZipCodeUsahaId = LoanApplication.CompanyEntity.RfZipCodeId;
                        }else{
                            SIKP.NPWP = LoanApplication.CompanyEntity.NPWP; 
                            SIKP.NamaDebitur = LoanApplication.CompanyEntity.CompanyName; 
                            SIKP.TanggalLahir = LoanApplication.CompanyEntity.DeedOfEstablishmentDate;
                            SIKP.Alamat = LoanApplication.CompanyEntity.Address; 
                            SIKP.Propinsi = LoanApplication.CompanyEntity.Province; 
                            SIKP.KabupatenKota = LoanApplication.CompanyEntity.City; 
                            SIKP.Kecamatan = LoanApplication.CompanyEntity.District; 
                            SIKP.Kelurahan = LoanApplication.CompanyEntity.Neighborhoods; 
                            SIKP.RfZipCodeId = LoanApplication.CompanyEntity.RfZipCodeId;
                            
                            SIKP.AlamatUsaha = LoanApplication.CompanyEntity?.Address;
                            SIKP.PropinsiUsaha = LoanApplication.CompanyEntity?.Province;
                            SIKP.KabupatenKotaUsaha = LoanApplication.CompanyEntity?.City;
                            SIKP.KecamatanUsaha = LoanApplication.CompanyEntity?.District;
                            SIKP.KelurahanUsaha = LoanApplication.CompanyEntity?.Neighborhoods;
                            SIKP.RfZipCodeUsahaId = LoanApplication.CompanyEntity?.RfZipCodeId;
                        }

                        var newSIKP = await _SIKPResponseData.AddAsync(SIKP);
                        response.SIKPId = newSIKP.Id;
                    }
                }

                // Pemilik Agunan
                var agunans = await _LoanApplicationCollateral.GetListByPredicate(x => x.LoanApplicationGuid == LoanApplication.Id, new string[] { "RfMarital", "RelationColId" });
                
                return await ProsesKeSLIK(LoanApplication, request, response, agunans);

            }
            catch (Exception ex)
            {
                var response = ServiceResponse<LoanApplicationProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}