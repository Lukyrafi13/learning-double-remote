using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ReviewPersiapanAkads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.ReviewPersiapanAkads.Commands
{
    public class ReviewPersiapanAkadProsesCommand : ReviewPersiapanAkadFind, IRequest<ServiceResponse<ReviewPersiapanAkadProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class ReviewPersiapanAkadProsesCommandHandler : IRequestHandler<ReviewPersiapanAkadProsesCommand, ServiceResponse<ReviewPersiapanAkadProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<ReviewPersiapanAkad> _ReviewPersiapanAkad;
        private readonly IGenericRepositoryAsync<Disbursement> _Disbursement;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public ReviewPersiapanAkadProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<ReviewPersiapanAkad> ReviewPersiapanAkad,
                IGenericRepositoryAsync<Disbursement> Disbursement,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _ReviewPersiapanAkad = ReviewPersiapanAkad;
            _Disbursement = Disbursement;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ReviewPersiapanAkadProsesResponse>> Handle(ReviewPersiapanAkadProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var ReviewPersiapanAkad = await _ReviewPersiapanAkad.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );
                if (ReviewPersiapanAkad == null)
                {
                    var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.Return404("Data ReviewPersiapanAkad not found");
                    failResp.Success = false;
                    return failResp;
                }

                var Disbursement = await _Disbursement.GetByPredicate(x => x.AppId == ReviewPersiapanAkad.AppId);

                if (Disbursement == null)
                {

                    // Assign New Disbursement
                    Disbursement = new Disbursement();

                    Disbursement.AppId = ReviewPersiapanAkad.AppId;
                    Disbursement.SppkId = ReviewPersiapanAkad.SppkId;
                    Disbursement.AnalisaId = ReviewPersiapanAkad.AnalisaId;
                    Disbursement.PrescreeningId = ReviewPersiapanAkad.PrescreeningId;
                    Disbursement.PersiapanAkadId = ReviewPersiapanAkad.PersiapanAkadId;

                    Disbursement = await _Disbursement.AddAsync(Disbursement);
                }

                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "12.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "11.0");

                if (ReviewPersiapanAkad.App.Prospect.Stage.Code == "12.0")
                {
                    var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "ReviewPersiapanAkad sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (ReviewPersiapanAkad.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "ReviewPersiapanAkad sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                ReviewPersiapanAkad.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                ReviewPersiapanAkad.App.Prospect.PreviousStage = previousStage;
                ReviewPersiapanAkad.App.Prospect.RFStagesId = stageFound.StageId;
                ReviewPersiapanAkad.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(ReviewPersiapanAkad.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == ReviewPersiapanAkad.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = ReviewPersiapanAkad.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new ReviewPersiapanAkadProsesResponse();

                response.AppId = ReviewPersiapanAkad.App.Id;
                response.ReviewPersiapanAkadId = ReviewPersiapanAkad.Id;
                response.DisbursementId = Disbursement.Id;
                response.Stage = stageFound.Description;
                response.Message = "Review Persiapan Akad berhasil diproses ke Disbursement";

                return ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}