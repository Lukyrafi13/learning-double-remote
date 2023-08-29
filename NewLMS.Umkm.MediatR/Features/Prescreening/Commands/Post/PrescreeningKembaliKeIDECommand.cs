using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prescreenings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Prescreenings.Commands
{
    public class PrescreeningKembaliKeIDECommand : PrescreeningFind, IRequest<ServiceResponse<PrescreeningProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class PrescreeningKembaliKeIDECommandHandler : IRequestHandler<PrescreeningKembaliKeIDECommand, ServiceResponse<PrescreeningProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public PrescreeningKembaliKeIDECommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<Prescreening> Prescreening,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _Prescreening = Prescreening;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PrescreeningProsesResponse>> Handle(PrescreeningKembaliKeIDECommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var Prescreening = await _Prescreening.GetByIdAsync(request.Id, "Id", 
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );
                if (Prescreening == null){
                    var failResp = ServiceResponse<PrescreeningProsesResponse>.Return404("Data Prescreening not found");
                    failResp.Success = false;
                    return failResp;
                }
                
                // Change App status
                var stageFound = await _stages.GetByPredicate(x=> x.Code == "2.0");
                var previousStage = await _stages.GetByPredicate(x=> x.Code == "4.2.2");
                
                if (Prescreening.App.Prospect.Stage.Code == "2.0"){
                    var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah dikembalikan sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (Prescreening.App.Prospect.Stage.Code == "0.0"){
                    var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }
                
                Prescreening.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                Prescreening.App.Prospect.PreviousStage = previousStage;
                Prescreening.App.Prospect.RFStagesId = stageFound.StageId;
                Prescreening.App.Prospect.Stage = stageFound;
                
                await _Prospect.UpdateAsync(Prescreening.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x=> x.Prospect.Id == Prescreening.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = Prescreening.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new PrescreeningProsesResponse();

                response.AppId = Prescreening.App.Id;
                response.Stage = stageFound.Description;
                response.Message = "Prescreening berhasil dikembalikan ke IDE";

                return ServiceResponse<PrescreeningProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}