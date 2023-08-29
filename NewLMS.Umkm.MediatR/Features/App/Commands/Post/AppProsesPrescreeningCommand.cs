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

namespace NewLMS.Umkm.MediatR.Features.Apps.Commands
{
    public class AppProsesPrescreeningCommand : AppFind, IRequest<ServiceResponse<AppProsesResponseDto>>
    {
        public string NamaUser { get; set; }
    }
    public class AppProsesPrescreeningCommandHandler : IRequestHandler<AppProsesPrescreeningCommand, ServiceResponse<AppProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private readonly IGenericRepositoryAsync<Prescreening> _prescreening;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public AppProsesPrescreeningCommandHandler(
                IGenericRepositoryAsync<App> App,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur,
                IGenericRepositoryAsync<Prescreening> prescreening,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _App = App;
            _Prospect = Prospect;
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _prescreening = prescreening;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppProsesResponseDto>> Handle(AppProsesPrescreeningCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var App = await _App.GetByIdAsync(request.Id, "Id",
                    new string[] {
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

                var response = new AppProsesResponseDto();

                // Assign New Prescreening
                var prescreening = new Prescreening();

                prescreening.AppId = App.Id;
                var newPrescreening = await _prescreening.AddAsync(prescreening);
                if (App.JenisProduk.ProductType == "KUR")
                {
                    // Assign New SIKP
                    var SIKP = new SIKPCalonDebitur();
    
                    SIKP.AppId = App.Id;

                    SIKP.RFOwnerCategoryId = App.RFOwnerCategoryId;
                    SIKP.NoKTP = App.NomorKTP;
                    SIKP.RFSectorLBU1Code = App.Prospect.RFSectorLBU1Code;
                    SIKP.RFSectorLBU2Code = App.Prospect.RFSectorLBU2Code;
                    SIKP.RFSectorLBU3Code = App.Prospect.RFSectorLBU3Code;
                    SIKP.NPWP = App.NPWP;
                    SIKP.NamaDebitur = App.NamaCustomer;
                    SIKP.TanggalLahir = App.TanggalLahir;
                    SIKP.RFGenderId = App.Prospect.RFGenderId;
                    SIKP.RFMaritalId = App.RFMaritalId;
                    SIKP.RFEducationId = App.RFEducationId;
                    SIKP.RFJobId = App.RFJobId;
                    SIKP.Alamat = App.Alamat;
                    SIKP.Propinsi = App.Propinsi;
                    SIKP.KabupatenKota = App.KabupatenKota;
                    SIKP.Kecamatan = App.Kecamatan;
                    SIKP.Kelurahan = App.Kelurahan;
                    SIKP.RFZipCodeId = App.RFZipCodeId;

                    SIKP.AlamatUsaha = App.Prospect.AlamatUsaha;
                    SIKP.PropinsiUsaha = App.Prospect.PropinsiUsaha;
                    SIKP.KabupatenKotaUsaha = App.Prospect.KabupatenKotaUsaha;
                    SIKP.KecamatanUsaha = App.Prospect.KecamatanUsaha;
                    SIKP.KelurahanUsaha = App.Prospect.KelurahanUsaha;
                    SIKP.RFZipCodeUsahaId = App.Prospect.RFZipCodeUsahaId;

                    var newSIKP = await _SIKPCalonDebitur.AddAsync(SIKP);
                    response.SIKPId = newSIKP.Id;
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

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                response.AppId = App.Id;
                response.PrescreeningId = prescreening.Id;
                response.Stage = stageFound.Description;
                response.Message = "App berhasil diproses ke Prescreening";

                return ServiceResponse<AppProsesResponseDto>.ReturnResultWith200(response);
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