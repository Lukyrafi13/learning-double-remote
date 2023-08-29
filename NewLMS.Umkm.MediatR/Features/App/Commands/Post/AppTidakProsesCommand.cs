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
    public class AppTidakProsesCommand : AppFind, IRequest<ServiceResponse<AppProsesResponseDto>>
    {
        public string NamaUser { get; set; }
        public Guid RFRejectId { get; set; }
    }
    public class AppTidakProsesCommandHandler : IRequestHandler<AppTidakProsesCommand, ServiceResponse<AppProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public AppTidakProsesCommandHandler(
                IGenericRepositoryAsync<App> App,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _App = App;
            _Prospect = Prospect;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppProsesResponseDto>> Handle(AppTidakProsesCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var App = await _App.GetByIdAsync(request.Id, "Id", 
                    new string[] {
                        "Prospect",
                        "Prospect.JenisProduk",
                        "Prospect.TipeDebitur",
                        "Prospect.JenisKelamin",
                        "Prospect.JenisPermohonanKredit",
                        "Prospect.KodePos",
                        "Prospect.Status",
                        "Prospect.SektorEkonomi",
                        "Prospect.SubSektorEkonomi",
                        "Prospect.SubSubSektorEkonomi",
                        "Prospect.Kategori",
                        "Prospect.KodeDinas",
                        "Prospect.Stage"
                    }
                );
                if (App == null){
                    var failResp = ServiceResponse<AppProsesResponseDto>.Return404("Data App not found");
                    failResp.Success = false;
                    return failResp;
                }
                
                // Change App status
                var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
                var previousStage = await _stages.GetByPredicate(x=> x.Code == "1.0");
                
                if (App.Prospect.Stage.Code == "3.0" || App.Prospect.Stage.Code == "4.2.1"){
                    var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (App.Prospect.Stage.Code == "0.0"){
                    var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }
                
                App.Prospect.RFStagesId = stageFound.StageId;
                App.Prospect.Stage = stageFound;
                
                await _Prospect.UpdateAsync(App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;
                newLog.ModifiedDate = DateTime.Now;
                newLog.ExecutedDate = DateTime.Now.ToLocalTime();
                newLog.RFRejectId = request.RFRejectId;

                await _stageLogs.AddAsync(newLog);

                var response = new AppProsesResponseDto();

                response.AppId = App.Id;
                response.Stage = stageFound.Description;
                response.Message = "App berhasil ditolak untuk pemrosesan";

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