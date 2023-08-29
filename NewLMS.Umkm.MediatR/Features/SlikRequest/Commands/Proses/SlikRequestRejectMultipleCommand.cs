using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikRequests;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace NewLMS.Umkm.MediatR.Features.SlikRequests.Commands
{
    public class SlikRequestRejectMultipleCommand : IRequest<ServiceResponse<List<SlikRequestProsesResponse>>>
    {
        public List<Guid> ListIds { get; set; }
        public string NamaUser { get; set; }
        public Guid RFRejectId { get; set; }
    }
    public class SlikRequestRejectMultipleCommandHandler : IRequestHandler<SlikRequestRejectMultipleCommand, ServiceResponse<List<SlikRequestProsesResponse>>>
    {
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public SlikRequestRejectMultipleCommandHandler(
                IGenericRepositoryAsync<SlikRequest> SlikRequest,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _SlikRequest = SlikRequest;
            _Prospect = Prospect;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<SlikRequestProsesResponse>>> Handle(SlikRequestRejectMultipleCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var listResponse = new List<SlikRequestProsesResponse>();
                foreach (var id in request.ListIds)
                {
                    var SlikRequest = await _SlikRequest.GetByIdAsync(id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.JenisProduk",
                        "App.Prospect.TipeDebitur",
                        "App.Prospect.JenisKelamin",
                        "App.Prospect.JenisPermohonanKredit",
                        "App.Prospect.KodePos",
                        "App.Prospect.Status",
                        "App.Prospect.SektorEkonomi",
                        "App.Prospect.SubSektorEkonomi",
                        "App.Prospect.SubSubSektorEkonomi",
                        "App.Prospect.Kategori",
                        "App.Prospect.KodeDinas",
                        "App.Prospect.Stage"
                    }
                );
                    if (SlikRequest == null)
                    {
                        var failResp = ServiceResponse<SlikRequestProsesResponse>.Return404("Data SlikRequest not found");
                        failResp.Success = false;
                        failResp.Data.Message = "Data SlikRequest not found";
                        failResp.Data.SlikRequestId = id;
                        listResponse.Add(failResp.Data);
                        continue;
                    }

                    // Change SlikRequest status
                    var stageFound = await _stages.GetByPredicate(x => x.Code == "0.0");
                    var previousStage = await _stages.GetByPredicate(x => x.Code == "4.2.1");

                    if (SlikRequest.App.Prospect.Stage.Code == "4.2.2")
                    {
                        var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah diproses sebelumnya");
                        failResp.Data.Message = "SlikRequest sudah diproses sebelumnya";
                        failResp.Data.SlikRequestId = id;
                        listResponse.Add(failResp.Data);
                        continue;
                    }

                    if (SlikRequest.App.Prospect.Stage.Code == "0.0")
                    {
                        var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah ditolak sebelumnya");
                        failResp.Data.Message = "SlikRequest sudah ditolak sebelumnya";
                        failResp.Data.SlikRequestId = id;
                        listResponse.Add(failResp.Data);
                        continue;
                    }

                    SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
                    SlikRequest.App.Prospect.Stage = stageFound;

                    await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

                    // Update SlikRequest History
                    var oldLog = await _stageLogs.GetByPredicate(x => x.ProspectId == SlikRequest.App.Prospect.Id && x.StageId == previousStage.StageId);
                    oldLog.ModifiedDate = DateTime.Now;
                    oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                    await _stageLogs.UpdateAsync(oldLog);

                    var newLog = new ProspectStageLogs();
                    newLog.ProspectId = SlikRequest.App.Prospect.Id;
                    newLog.StageId = stageFound.StageId;
                    newLog.ExecutedBy = request.NamaUser;
                    newLog.ModifiedDate = DateTime.Now;
                    newLog.ExecutedDate = DateTime.Now.ToLocalTime();
                    newLog.RFRejectId = request.RFRejectId;

                    await _stageLogs.AddAsync(newLog);

                    var response = new SlikRequestProsesResponse();

                    response.SlikRequestId = SlikRequest.Id;
                    response.Stage = stageFound.Description;
                    response.Message = "SlikRequest berhasil ditolak untuk pemrosesan";

                    listResponse.Add(response);
                }

                return ServiceResponse<List<SlikRequestProsesResponse>>.ReturnResultWith200(listResponse);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<List<SlikRequestProsesResponse>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}