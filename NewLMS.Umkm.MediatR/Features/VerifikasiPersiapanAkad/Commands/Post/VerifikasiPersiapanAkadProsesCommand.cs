using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.VerifikasiPersiapanAkads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.VerifikasiPersiapanAkads.Commands
{
    public class VerifikasiPersiapanAkadProsesCommand : VerifikasiPersiapanAkadFind, IRequest<ServiceResponse<VerifikasiPersiapanAkadProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class VerifikasiPersiapanAkadProsesCommandHandler : IRequestHandler<VerifikasiPersiapanAkadProsesCommand, ServiceResponse<VerifikasiPersiapanAkadProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<VerifikasiPersiapanAkad> _VerifikasiPersiapanAkad;
        private readonly IGenericRepositoryAsync<ReviewPersiapanAkad> _ReviewPersiapanAkad;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public VerifikasiPersiapanAkadProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<VerifikasiPersiapanAkad> VerifikasiPersiapanAkad,
                IGenericRepositoryAsync<ReviewPersiapanAkad> ReviewPersiapanAkad,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _VerifikasiPersiapanAkad = VerifikasiPersiapanAkad;
            _ReviewPersiapanAkad = ReviewPersiapanAkad;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<VerifikasiPersiapanAkadProsesResponse>> Handle(VerifikasiPersiapanAkadProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var VerifikasiPersiapanAkad = await _VerifikasiPersiapanAkad.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );
                if (VerifikasiPersiapanAkad == null)
                {
                    var failResp = ServiceResponse<VerifikasiPersiapanAkadProsesResponse>.Return404("Data VerifikasiPersiapanAkad not found");
                    failResp.Success = false;
                    return failResp;
                }

                var ReviewPersiapanAkad = await _ReviewPersiapanAkad.GetByPredicate(x=> x.AppId == VerifikasiPersiapanAkad.AppId);

                if (ReviewPersiapanAkad == null)
                {
                    // Assign New VerifikasiPersiapanAkad
                    ReviewPersiapanAkad = new ReviewPersiapanAkad();

                    ReviewPersiapanAkad.AppId = VerifikasiPersiapanAkad.AppId;
                    ReviewPersiapanAkad.SppkId = VerifikasiPersiapanAkad.SppkId;
                    ReviewPersiapanAkad.AnalisaId = VerifikasiPersiapanAkad.AnalisaId;
                    ReviewPersiapanAkad.PrescreeningId = VerifikasiPersiapanAkad.PrescreeningId;
                    ReviewPersiapanAkad.PersiapanAkadId = VerifikasiPersiapanAkad.PersiapanAkadId;

                    ReviewPersiapanAkad = await _ReviewPersiapanAkad.AddAsync(ReviewPersiapanAkad);
                }

                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "11.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "10.0");

                if (VerifikasiPersiapanAkad.App.Prospect.Stage.Code == "11.0")
                {
                    var failResp = ServiceResponse<VerifikasiPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "VerifikasiPersiapanAkad sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (VerifikasiPersiapanAkad.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<VerifikasiPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "VerifikasiPersiapanAkad sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                VerifikasiPersiapanAkad.App.Prospect.RFStagesId = stageFound.StageId;
                VerifikasiPersiapanAkad.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(VerifikasiPersiapanAkad.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == VerifikasiPersiapanAkad.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = VerifikasiPersiapanAkad.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new VerifikasiPersiapanAkadProsesResponse();

                response.AppId = VerifikasiPersiapanAkad.App.Id;
                response.VerifikasiPersiapanAkadId = VerifikasiPersiapanAkad.Id;
                response.ReviewPersiapanAkadId = ReviewPersiapanAkad.Id;
                response.Stage = stageFound.Description;
                response.Message = "Verifikasi Persiapan Akad berhasil diproses ke Review Persiapan Akad";

                return ServiceResponse<VerifikasiPersiapanAkadProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<VerifikasiPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}