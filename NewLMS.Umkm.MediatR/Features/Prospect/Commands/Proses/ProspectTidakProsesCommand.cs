using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands
{
    public class ProspectTidakProsesCommand : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectProsesResponseDto>>
    {
        public string NamaUser { get; set; }
        public Guid RFRejectId { get; set; }
    }
    public class ProspectTidakProsesCommandHandler : IRequestHandler<ProspectTidakProsesCommand, ServiceResponse<ProspectProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public ProspectTidakProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _prospect = prospect;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProspectProsesResponseDto>> Handle(ProspectTidakProsesCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id", 
                    new string[] {
                        "JenisProduk",
                        "TipeDebitur",
                        "JenisKelamin",
                        "JenisPermohonanKredit",
                        "KodePos",
                        "Status",
                        "SektorEkonomi",
                        "SubSektorEkonomi",
                        "SubSubSektorEkonomi",
                        "Kategori",
                        "KodeDinas",
                        "Stage"
                    }
                );
                if (prospect == null){
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.Return404("Data Prospect not found");
                    failResp.Success = false;
                    return failResp;
                }
                
                // Change prospect status
                var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
                var previousStage = await _stages.GetByPredicate(x=> x.Code == "1.0");
                
                if (prospect.Stage.Code == "2.0"){
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prospect sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (prospect.Stage.Code == "0.0"){
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prospect sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }
                
                prospect.RFStagesId = stageFound.StageId;
                prospect.Stage = stageFound;
                
                await _prospect.UpdateAsync(prospect);

                // Update prospect History
                var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;
                newLog.ModifiedDate = DateTime.Now;
                newLog.ExecutedDate = DateTime.Now.ToLocalTime();
                newLog.RFRejectId = request.RFRejectId;

                await _stageLogs.AddAsync(newLog);

                var response = new ProspectProsesResponseDto();

                response.AppId = null;
                response.ProspectId = prospect.Id;
                response.Stage = stageFound.Description;
                response.Message = "Prospect berhasil ditolak untuk pemrosesan";

                return ServiceResponse<ProspectProsesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}