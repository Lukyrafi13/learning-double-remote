using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SPPKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SPPKs.Commands
{
    public class SPPKProsesCommand : SPPKFind, IRequest<ServiceResponse<SPPKProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class SPPKProsesCommandHandler : IRequestHandler<SPPKProsesCommand, ServiceResponse<SPPKProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<SPPK> _SPPK;
        private readonly IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public SPPKProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<Survey> Survey,
                IGenericRepositoryAsync<SPPK> SPPK,
                IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
                IGenericRepositoryAsync<Prescreening> Prescreening,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _SPPK = SPPK;
            _PersiapanAkad = PersiapanAkad;
            _Prescreening = Prescreening;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SPPKProsesResponse>> Handle(SPPKProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SPPK = await _SPPK.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );

                if (SPPK == null)
                {
                    var failResp = ServiceResponse<SPPKProsesResponse>.Return404("Data SPPK not found");
                    failResp.Success = false;
                    return failResp;
                }

                // get prescreening
                var Prescreening = await _Prescreening.GetByPredicate(x => x.AppId == SPPK.AppId);

                var PersiapanAkad = await _PersiapanAkad.GetByPredicate(x => x.AppId == SPPK.AppId);

                if (PersiapanAkad == null)
                {

                    // Assign New Survey
                    PersiapanAkad = new PersiapanAkad();

                    PersiapanAkad.AppId = SPPK.AppId;
                    PersiapanAkad.SppkId = SPPK.Id;
                    PersiapanAkad.AnalisaId = SPPK.AnalisaId;
                    PersiapanAkad.PrescreeningId = Prescreening.Id;

                    PersiapanAkad = await _PersiapanAkad.AddAsync(PersiapanAkad);
                }

                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "9.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "8.0");

                if (SPPK.App.Prospect.Stage.Code == "9.0")
                {
                    var failResp = ServiceResponse<SPPKProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SPPK sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (SPPK.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<SPPKProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SPPK sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                SPPK.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                SPPK.App.Prospect.PreviousStage = previousStage;
                SPPK.App.Prospect.RFStagesId = stageFound.StageId;
                SPPK.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(SPPK.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == SPPK.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = SPPK.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new SPPKProsesResponse();

                response.AppId = SPPK.App.Id;
                response.SPPKId = SPPK.Id;
                response.PersiapanAkadId = PersiapanAkad.Id;
                response.Stage = stageFound.Description;
                response.Message = "SPPK berhasil diproses ke Persiapan Akad";

                return ServiceResponse<SPPKProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<SPPKProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}