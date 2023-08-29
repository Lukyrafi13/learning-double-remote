using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Approvals;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Approvals.Commands
{
    public class ApprovalKembaliKeAnalisaCommand : ApprovalFind, IRequest<ServiceResponse<ApprovalProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class ApprovalKembaliKeAnalisaCommandHandler : IRequestHandler<ApprovalKembaliKeAnalisaCommand, ServiceResponse<ApprovalProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<Approval> _Approval;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public ApprovalKembaliKeAnalisaCommandHandler(
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<Approval> Approval,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Prospect = Prospect;
            _Approval = Approval;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ApprovalProsesResponse>> Handle(ApprovalKembaliKeAnalisaCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var Approval = await _Approval.GetByIdAsync(request.Id, "Id", 
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );
                if (Approval == null){
                    var failResp = ServiceResponse<ApprovalProsesResponse>.Return404("Data Approval not found");
                    failResp.Success = false;
                    return failResp;
                }
                
                // Change App status
                var stageFound = await _stages.GetByPredicate(x=> x.Code == "5.0");
                var previousStage = await _stages.GetByPredicate(x=> x.Code == "7.0");
                
                if (Approval.App.Prospect.Stage.Code == "5.0"){
                    var failResp = ServiceResponse<ApprovalProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Approval sudah dikembalikan sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (Approval.App.Prospect.Stage.Code == "0.0"){
                    var failResp = ServiceResponse<ApprovalProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Approval sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }
                
                Approval.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                Approval.App.Prospect.PreviousStage = previousStage;
                Approval.App.Prospect.RFStagesId = stageFound.StageId;
                Approval.App.Prospect.Stage = stageFound;
                
                await _Prospect.UpdateAsync(Approval.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x=> x.Prospect.Id == Approval.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = Approval.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;

                await _stageLogs.AddAsync(newLog);

                var response = new ApprovalProsesResponse();

                response.AppId = Approval.App.Id;
                response.Stage = stageFound.Description;
                response.Message = "Approval berhasil dikembalikan ke Analisa";

                return ServiceResponse<ApprovalProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<ApprovalProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}