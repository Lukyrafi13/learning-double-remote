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
    public class SlikRequestProsesAdminPrescreeningCommand : IRequest<ServiceResponse<SlikRequestProsesAdminResponse>>
    {
        public List<SlikRequestFind> listSlikRequestFinds;
        public string NamaUser;
    }
    public class SlikRequestProsesAdminPrescreeningCommandHandler : IRequestHandler<SlikRequestProsesAdminPrescreeningCommand, ServiceResponse<SlikRequestProsesAdminResponse>>
    {
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _ProspectStageLogs;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IMapper _mapper;

        public SlikRequestProsesAdminPrescreeningCommandHandler(
                IGenericRepositoryAsync<App> App,
                IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
                IGenericRepositoryAsync<RFStages> RFStages,
                IGenericRepositoryAsync<SlikRequest> SlikRequest,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<ProspectStageLogs> ProspectStageLogs,
                IGenericRepositoryAsync<Prescreening> Prescreening,
                IMapper mapper
            )
        {
            _App = App;
            _SlikRequestObject = SlikRequestObject;
            _SlikRequest = SlikRequest;
            _RFStages = RFStages;
            _Prospect = Prospect;
            _ProspectStageLogs = ProspectStageLogs;
            _Prescreening = Prescreening;
            _mapper = mapper;
        }

        private async Task<SlikRequestProsesResponse> prosesPrescreening(SlikRequest SlikRequest, string NamaUser)
        {

            // Assign New Prescreening
            var Prescreening = new Prescreening();

            Prescreening.AppId = SlikRequest.AppId;

            // Change App status
            var stageFound = await _RFStages.GetByPredicate(x => x.Code == "4.2.2");
            var previousStage = await _RFStages.GetByPredicate(x => x.Code == "4.2.1");

            if (SlikRequest.App.Prospect.Stage.Code == "4.2.2")
            {
                var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SLIK Request sudah diproses sebelumnya");
                failResp.Success = false;
                failResp.Data.Message = "SLIK Request sudah diproses sebelumnya";
                failResp.Data.SlikRequestId = SlikRequest.Id;
                return failResp.Data;
            }

            if (SlikRequest.App.Prospect.Stage.Code == "0.0")
            {
                var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SLIK Request sudah ditolak sebelumnya");
                failResp.Success = false;
                failResp.Data.Message = "SLIK Request sudah ditolak sebelumnya";
                failResp.Data.SlikRequestId = SlikRequest.Id;
                return failResp.Data;
            }

            SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
            SlikRequest.App.Prospect.Stage = stageFound;

            await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

            // Update App History
            var oldLog = await _ProspectStageLogs.GetByPredicate(x => x.Prospect.Id == SlikRequest.App.Prospect.Id && x.StageId == previousStage.StageId);
            oldLog.ModifiedDate = DateTime.Now;
            oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

            await _ProspectStageLogs.UpdateAsync(oldLog);

            var newLog = new ProspectStageLogs();
            newLog.ProspectId = SlikRequest.App.Prospect.Id;
            newLog.StageId = stageFound.StageId;
            newLog.ExecutedBy = NamaUser;

            await _ProspectStageLogs.AddAsync(newLog);

            var newPrescreening = await _Prescreening.AddAsync(Prescreening);

            var response = new SlikRequestProsesResponse();

            response.AppId = SlikRequest.App.Id;
            response.SlikRequestId = SlikRequest.Id;
            response.PrescreeningId = newPrescreening.Id;
            response.Stage = stageFound.Description;
            response.Message = "SlikRequest berhasil diproses ke Prescreening";

            return response;
        }

        public async Task<ServiceResponse<SlikRequestProsesAdminResponse>> Handle(SlikRequestProsesAdminPrescreeningCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var listSlikRequestProsesResponse = new List<SlikRequestProsesResponse>();

                foreach (var SlikRequestFind in request.listSlikRequestFinds)
                {

                    var SlikRequest = await _SlikRequest.GetByIdAsync(SlikRequestFind.Id, "Id",
                        new string[] {
                            "App",
                            "App.Prospect",
                            "App.Prospect.Stage"
                        }
                    );

                    if (SlikRequest == null)
                    {
                        var failResp = ServiceResponse<SlikRequestProsesAdminResponse>.Return404("Data SlikRequest not found");
                        failResp.Success = false;
                        return failResp;
                    }

                    // TODO : Tembak ke RoboSLIK

                    SlikRequest.ProcessStatus = 1;
                    SlikRequest.ProcessDate = DateTime.Now;

                    await _SlikRequest.UpdateAsync(SlikRequest);

                    var listSlikRequestObject = await _SlikRequestObject.GetListByPredicate(x => x.SlikRequestId == SlikRequest.Id);

                    foreach (var SlikRequestObject in listSlikRequestObject)
                    {
                        SlikRequestObject.RequestDate = DateTime.Now;

                        await _SlikRequestObject.UpdateAsync(SlikRequestObject);
                    }


                    listSlikRequestProsesResponse.Add(await prosesPrescreening(SlikRequest, request.NamaUser));
                }
                var response = new SlikRequestProsesAdminResponse();

                response.ProsesResponse = listSlikRequestProsesResponse;

                response.Message = "SlikRequest berhasil diproses ke panel admin";



                return ServiceResponse<SlikRequestProsesAdminResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<SlikRequestProsesAdminResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}