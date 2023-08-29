using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PersiapanAkads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.PersiapanAkads.Commands
{
    public class PersiapanAkadProsesCommand : PersiapanAkadFind, IRequest<ServiceResponse<PersiapanAkadProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class PersiapanAkadProsesCommandHandler : IRequestHandler<PersiapanAkadProsesCommand, ServiceResponse<PersiapanAkadProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
        private readonly IGenericRepositoryAsync<VerifikasiPersiapanAkad> _VerifikasiPersiapanAkad;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public PersiapanAkadProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
                IGenericRepositoryAsync<VerifikasiPersiapanAkad> VerifikasiPersiapanAkad,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _VerifikasiPersiapanAkad = VerifikasiPersiapanAkad;
            _PersiapanAkad = PersiapanAkad;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PersiapanAkadProsesResponse>> Handle(PersiapanAkadProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var PersiapanAkad = await _PersiapanAkad.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );

                if (PersiapanAkad == null)
                {
                    var failResp = ServiceResponse<PersiapanAkadProsesResponse>.Return404("Data PersiapanAkad not found");
                    failResp.Success = false;
                    return failResp;
                }

                var VerifikasiPersiapanAkad = await _VerifikasiPersiapanAkad.GetByPredicate(x => x.AppId == PersiapanAkad.AppId);

                if (VerifikasiPersiapanAkad == null)
                {

                    // Assign New VerifikasiPersiapanAkad
                    VerifikasiPersiapanAkad = new VerifikasiPersiapanAkad();

                    VerifikasiPersiapanAkad.AppId = PersiapanAkad.AppId;
                    VerifikasiPersiapanAkad.SppkId = PersiapanAkad.SppkId;
                    VerifikasiPersiapanAkad.AnalisaId = PersiapanAkad.AnalisaId;
                    VerifikasiPersiapanAkad.PrescreeningId = PersiapanAkad.PrescreeningId;
                    VerifikasiPersiapanAkad.PersiapanAkadId = PersiapanAkad.Id;

                    VerifikasiPersiapanAkad = await _VerifikasiPersiapanAkad.AddAsync(VerifikasiPersiapanAkad);
                }


                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "10.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "9.0");

                if (PersiapanAkad.App.Prospect.Stage.Code == "10.0")
                {
                    var failResp = ServiceResponse<PersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "PersiapanAkad sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (PersiapanAkad.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<PersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "PersiapanAkad sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                PersiapanAkad.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                PersiapanAkad.App.Prospect.PreviousStage = previousStage;
                PersiapanAkad.App.Prospect.RFStagesId = stageFound.StageId;
                PersiapanAkad.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(PersiapanAkad.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == PersiapanAkad.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = PersiapanAkad.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new PersiapanAkadProsesResponse();

                response.AppId = PersiapanAkad.App.Id;
                response.PersiapanAkadId = PersiapanAkad.Id;
                response.VerifikasiPersiapanAkadId = VerifikasiPersiapanAkad.Id;
                response.Stage = stageFound.Description;
                response.Message = "Persiapan Akad berhasil diproses ke Verifikasi Persiapan Akad";

                return ServiceResponse<PersiapanAkadProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<PersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}