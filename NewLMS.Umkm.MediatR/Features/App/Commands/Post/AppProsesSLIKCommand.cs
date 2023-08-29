using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using Hangfire;
using NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Commands;

namespace NewLMS.Umkm.MediatR.Features.Apps.Commands
{
    public class AppProsesSLIKCommand : AppFind, IRequest<ServiceResponse<AppProsesResponseDto>>
    {
        public string NamaUser { get; set; }
    }
    public class AppProsesSLIKCommandHandler : IRequestHandler<AppProsesSLIKCommand, ServiceResponse<AppProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
        private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IGenericRepositoryAsync<Prescreening> _prescreening;

        public AppProsesSLIKCommandHandler(
                IGenericRepositoryAsync<App> App,
                IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson,
                IGenericRepositoryAsync<AppAgunan> AppAgunan,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur,
                IGenericRepositoryAsync<SlikRequest> SlikRequest,
                IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IGenericRepositoryAsync<Prescreening> prescreening
            )
        {
            _App = App;
            _AppKeyPerson = AppKeyPerson;
            _AppAgunan = AppAgunan;
            _Prospect = Prospect;
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _SlikRequest = SlikRequest;
            _SlikRequestObject = SlikRequestObject;
            _stages = stages;
            _stageLogs = stageLogs;
            _prescreening = prescreening;
        }

        public async Task<ServiceResponse<AppProsesResponseDto>> ProsesKeSLIK(App App, AppProsesSLIKCommand request, AppProsesResponseDto response, List<AppAgunan> agunans)
        {
            var SlikRequest = await _SlikRequest.GetByPredicate(x => x.AppId == request.Id);

            if (SlikRequest == null)
            {
                // Assign new slik
                SlikRequest = new SlikRequest
                {
                    ProcessStatus = 0,
                    AdminVerified = 0,
                    AppId = App.Id,
                    StatusCheckingDuplikasi = 0,
                    IsCheckingError = false,
                };

                var newSlikRequest = await _SlikRequest.AddAsync(SlikRequest);
                response.SLIKId = SlikRequest.Id;

                // Input pemohon
                if (App.TipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
                {
                    // Tipe Debitur
                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 1,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = App.NamaCustomer,
                        NPWP = App.NPWP,
                        NoIdentity = App.NomorKTP,
                        DateOfBirth = (DateTime)App.TanggalLahir,
                        PlaceOfBirth = App.TempatLahir,
                        ApplicationStatus = "Perorangan",
                        RoboSlik = false,
                        Automatic = true,
                    };

                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    if (App.StatusPerkawinan.MR_DESC.ToLower() == "Menikah".ToLower())
                    {

                        // Pasangan
                        var SilkReqObjPasangan = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = App.NamaLengkapPasangan,
                            NPWP = App.NPWPPasangan,
                            NoIdentity = App.NoKTPPasangan,
                            DateOfBirth = (DateTime)App.TanggalLahirPasangan,
                            PlaceOfBirth = App.TempatLahirPasangan,
                            ApplicationStatus = "Perorangan",
                            RoboSlik = false,
                            Automatic = true,
                        };

                        await _SlikRequestObject.AddAsync(SilkReqObjPasangan);
                    }
                }
                if (App.TipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                {
                    // Perusahaan
                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 2,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = App.NamaCustomer,
                        NPWP = App.NPWP,
                        NoIdentity = App.NomorAktaPendirian,
                        DateOfBirth = (DateTime)App.TanggalAktaPendirian,
                        PlaceOfBirth = App.Alamat,
                        ApplicationStatus = "Badan Usaha",
                        RoboSlik = false,
                        Automatic = true,
                    };

                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    // Key Person
                    var AppKeyPersons = await _AppKeyPerson.GetListByPredicate(x => x.AppId == App.Id, new string[] { "Status" });

                    foreach (var appKeyPerson in AppKeyPersons)
                    {
                        var SilkReqObjKey = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = appKeyPerson.Nama,
                            NPWP = appKeyPerson.NPWP,
                            NoIdentity = appKeyPerson.NoKTP,
                            DateOfBirth = (DateTime)appKeyPerson.TanggalLahir,
                            PlaceOfBirth = appKeyPerson.TempatLahir,
                            ApplicationStatus = "Perorangan",
                            RoboSlik = false,
                            Automatic = true,
                        };
                        await _SlikRequestObject.AddAsync(SilkReqObjKey);

                        if (appKeyPerson.Status.MR_DESC.ToLower() == "Menikah".ToLower())
                        {

                            // Pasangan
                            // var SilkReqObjKeyPasangan = new SlikRequestObject
                            // {
                            //     SlikObjectTypeId = 1,
                            //     SlikRequestId = SlikRequest.Id,
                            //     Fullname = appKeyPerson.NamaLengkapPasangan,
                            //     NPWP = App.NPWPPasangan,
                            //     NoIdentity = App.NoKTPPasangan,
                            //     DateOfBirth = (DateTime)App.TanggalLahirPasangan,
                            //     PlaceOfBirth = App.TempatLahirPasangan,
                            //     ApplicationStatus = "Perorangan",
                            //     RoboSlik = false,
                            // };

                            // await _SlikRequestObject.AddAsync(SilkReqObjKeyPasangan);
                        }
                    }
                }

                foreach (var agunan in agunans)
                {
                    if ((agunan.AgunanMilikDebitur ?? false )|| agunan.HubunganDenganDebitur.ReDesc.ToLower() == "SUAMI/ISTRI".ToLower())
                    {
                        continue;
                    }

                    var SilkReqObj = new SlikRequestObject
                    {
                        SlikObjectTypeId = 1,
                        SlikRequestId = SlikRequest.Id,
                        Fullname = agunan.NamaPemilik,
                        NPWP = agunan.NPWPPemilik,
                        NoIdentity = agunan.NomorIDPemilik,
                        DateOfBirth = (DateTime)agunan.TanggalLahirPemilik,
                        PlaceOfBirth = agunan.TempatLahirPemilik,
                        ApplicationStatus = "Perorangan",
                        RoboSlik = false,
                        Automatic = true,
                    };
                    await _SlikRequestObject.AddAsync(SilkReqObj);

                    if (agunan.StatusPernikahan.MR_DESC.ToLower() == "Menikah".ToLower())
                    {

                        // Pasangan
                        var SilkReqObjPasangan = new SlikRequestObject
                        {
                            SlikObjectTypeId = 1,
                            SlikRequestId = SlikRequest.Id,
                            Fullname = agunan.NamaPasangan,
                            NPWP = agunan.NPWPPasangan,
                            NoIdentity = agunan.NomorKTPPasangan,
                            DateOfBirth = (DateTime)agunan.TanggalLahirPasangan,
                            PlaceOfBirth = agunan.TempatLahirPasangan,
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

            // Change App status
            var stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.1");
            var previousStage = await _stages.GetByPredicate(x => x.Code == "2.0");

            if (App.Prospect.Stage.Code == "4.2.1")
            {
                var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah diproses sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            if (App.Prospect.Stage.Code == "0.0")
            {
                var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah ditolak sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            App.Prospect.RFPreviousStagesId = previousStage.StageId;
            App.Prospect.PreviousStage = previousStage;
            App.Prospect.RFStagesId = stageFound.StageId;
            App.Prospect.Stage = stageFound;

            await _Prospect.UpdateAsync(App.Prospect);

            // Update App History
            var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == App.Prospect.Id && x.StageId == previousStage.StageId);
            oldLog.ModifiedDate = DateTime.Now;
            oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

            await _stageLogs.UpdateAsync(oldLog);

            var newLog = new ProspectStageLogs
            {
                ProspectId = App.Prospect.Id,
                StageId = stageFound.StageId,
                ExecutedBy = request.NamaUser
            };

            await _stageLogs.AddAsync(newLog);

            response.AppId = App.Id;
            response.SLIKId = SlikRequest.Id;
            response.Stage = stageFound.Description;
            response.Message = "App berhasil diproses ke SLIK";

            if (SlikRequest.StatusCheckingDuplikasi == 0 || (SlikRequest.StatusCheckingDuplikasi == 2 && (SlikRequest.IsCheckingError??false))){
                BackgroundJob.Enqueue<DuplicationCheckTask>(x=> x.DuplicationCheck(SlikRequest.Id));
            }


            return ServiceResponse<AppProsesResponseDto>.ReturnResultWith200(response);
        }
        public async Task<ServiceResponse<AppProsesResponseDto>> ProsesKePrescreening(App App, AppProsesSLIKCommand request, AppProsesResponseDto response)
        {
            var prescreening = await _prescreening.GetByPredicate(x=> x.AppId == App.Id);

            if (prescreening == null){
                prescreening = new Prescreening(){
                    AppId = App.Id,
                };

                prescreening = await _prescreening.AddAsync(prescreening);
            }

            // Change App status
            var stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.2");
            var previousStage = await _stages.GetByPredicate(x => x.Code == "2.0");

            if (App.Prospect.Stage.Code == "4.2.2")
            {
                var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah diproses sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            if (App.Prospect.Stage.Code == "0.0")
            {
                var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah ditolak sebelumnya");
                failResp.Success = false;
                return failResp;
            }

            App.Prospect.RFStagesId = stageFound.StageId;
            App.Prospect.Stage = stageFound;

            await _Prospect.UpdateAsync(App.Prospect);

            // Update App History
            var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == App.Prospect.Id && x.StageId == previousStage.StageId);
            oldLog.ModifiedDate = DateTime.Now;
            oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

            await _stageLogs.UpdateAsync(oldLog);

            var newLog = new ProspectStageLogs
            {
                ProspectId = App.Prospect.Id,
                StageId = stageFound.StageId,
                ExecutedBy = request.NamaUser
            };

            await _stageLogs.AddAsync(newLog);

            response.AppId = App.Id;
            response.PrescreeningId = prescreening.Id;
            response.Stage = stageFound.Description;
            response.Message = "App berhasil diproses ke Prescreening";


            return ServiceResponse<AppProsesResponseDto>.ReturnResultWith200(response);

        }

        public async Task<ServiceResponse<AppProsesResponseDto>> Handle(AppProsesSLIKCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new AppProsesResponseDto();

                var App = await _App.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "JenisProduk",
                        "TipeDebitur",
                        "StatusPerkawinan",
                        "Prospect",
                        "Prospect.Stage",
                        "JenisProduk"
                    }
                );
                if (App == null)
                {
                    var failResp = ServiceResponse<AppProsesResponseDto>.Return404("Data App not found");
                    failResp.Success = false;
                    return failResp;
                }


                var SIKP = await _SIKPCalonDebitur.GetByPredicate(x => x.AppId == request.Id);

                if (SIKP == null)
                {
                    if (App.JenisProduk.ProductType == "KUR")
                    {

                        // Assign New SIKP
                        SIKP = new SIKPCalonDebitur
                        {
                            AppId = App.Id,

                            RFOwnerCategoryId = App.RFOwnerCategoryId,
                            NoKTP = App.NomorKTP,
                            RFSectorLBU1Code = App.Prospect.RFSectorLBU1Code,
                            RFSectorLBU2Code = App.Prospect.RFSectorLBU2Code,
                            RFSectorLBU3Code = App.Prospect.RFSectorLBU3Code,
                            NPWP = App.NPWP,
                            NamaDebitur = App.NamaCustomer,
                            TanggalLahir = App.TanggalLahir,
                            RFGenderId = App.Prospect.RFGenderId,
                            RFMaritalId = App.RFMaritalId,
                            RFEducationId = App.RFEducationId,
                            RFJobId = App.RFJobId,
                            Alamat = App.Alamat,
                            Propinsi = App.Propinsi,
                            KabupatenKota = App.KabupatenKota,
                            Kecamatan = App.Kecamatan,
                            Kelurahan = App.Kelurahan,
                            RFZipCodeId = App.RFZipCodeId,

                            AlamatUsaha = App.Prospect.AlamatUsaha,
                            PropinsiUsaha = App.Prospect.PropinsiUsaha,
                            KabupatenKotaUsaha = App.Prospect.KabupatenKotaUsaha,
                            KecamatanUsaha = App.Prospect.KecamatanUsaha,
                            KelurahanUsaha = App.Prospect.KelurahanUsaha,
                            RFZipCodeUsahaId = App.Prospect.RFZipCodeUsahaId
                        };

                        var newSIKP = await _SIKPCalonDebitur.AddAsync(SIKP);
                        response.SIKPId = newSIKP.Id;
                    }
                }

                // Pemilik Agunan
                var agunans = await _AppAgunan.GetListByPredicate(x => x.AppId == App.Id, new string[] { "StatusPernikahan", "HubunganDenganDebitur" });
                
                return await ProsesKeSLIK(App, request, response, agunans);

            }
            catch (Exception ex)
            {
                var response = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}