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
using Hangfire;
using NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Commands;
using System.Linq;
using System.Collections.Generic;

namespace NewLMS.Umkm.MediatR.Features.SlikRequests.Commands
{
    public class SlikRequestProsesCommand
        : SlikRequestFind,
            IRequest<ServiceResponse<SlikRequestProsesResponse>>
    {
        public string NamaUser { get; set; }
    }

    public class SlikRequestProsesCommandHandler
        : IRequestHandler<SlikRequestProsesCommand, ServiceResponse<SlikRequestProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private readonly IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        
        public SlikRequestProsesCommandHandler(
            IGenericRepositoryAsync<Prospect> Prospect,
            IGenericRepositoryAsync<Prescreening> Prescreening,
            IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen,
            IGenericRepositoryAsync<SlikRequest> SlikRequest,
            IGenericRepositoryAsync<AppAgunan> AppAgunan,
            IGenericRepositoryAsync<RFDocument> RFDocument,
            IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan,
            IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen,
            IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen,
            IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC,
            IGenericRepositoryAsync<RFStages> stages,
            IGenericRepositoryAsync<ProspectStageLogs> stageLogs
        )
        {
            _Prospect = Prospect;
            _Prescreening = Prescreening;
            _PrescreeningDokumen = PrescreeningDokumen;
            _SlikRequest = SlikRequest;
            _AppAgunan = AppAgunan;
            _RFDocument = RFDocument;
            _RFDocumentAgunan = RFDocumentAgunan;
            _RFStatusDokumen = RFStatusDokumen;
            _RFColLateralBC = RFColLateralBC;
            _RFTipeDokumen = RFTipeDokumen;
            _stages = stages;
            _stageLogs = stageLogs;
        }

        public async Task<ServiceResponse<SlikRequestProsesResponse>> Handle(
            SlikRequestProsesCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var SlikRequest = await _SlikRequest.GetByIdAsync(
                    request.Id,
                    "Id",
                    new string[] { "App", "App.Prospect", "App.Prospect.Stage" }
                );
                if (SlikRequest == null)
                {
                    var failResp = ServiceResponse<SlikRequestProsesResponse>.Return404(
                        "Data SlikRequest not found"
                    );
                    failResp.Success = false;
                    return failResp;
                }

                var Prescreening = await _Prescreening.GetByPredicate(
                    x => x.AppId == SlikRequest.AppId
                );

                if (Prescreening == null)
                {
                    // Assign New Prescreening
                    Prescreening = new Prescreening
                    {
                        AppId = SlikRequest.AppId,
                        SlikRequestId = SlikRequest.Id
                    };

                    Prescreening = await _Prescreening.AddAsync(Prescreening);
                }

                // Insert dokumen kosong untuk jaminan

                // Prepare variables
                var ListNewDocument = new List<PrescreeningDokumen>();
                var RFTipeDokumen = await _RFTipeDokumen.GetByPredicate(x=>x.TypeCode == "JMN");
                var RFStatusDokumen = await _RFStatusDokumen.GetByPredicate(x=>x.StatusCode == "TBO");
                
                // Get all App agunan by appId
                var ListAgunan = await _AppAgunan
                .GetListByPredicate(x=> x.AppId == SlikRequest.AppId, new string[]{"JenisJaminan"});

                // Get Prescreening Dokumen Jaminan
                var ListPrescreeningDokumen = await _PrescreeningDokumen
                .GetListByPredicate(x=> x.PrescreeningId == Prescreening.Id && x.RFTipeDokumenId == RFTipeDokumen.Id);
                
                // Get distinct mapping agunan2
                var ListMappingAgunan2 = ListAgunan.DistinctBy(x=> x.RFMappingAgunan2Id)
                .Where(x=>x.RFMappingAgunan2Id != null).Select(x=> x.JenisJaminan).ToList();
                
                // For each mapping agunan, cek gap jumlah dokumen prescreening dan jml mapping agunan
                foreach (var jenisAgunan in ListMappingAgunan2)
                {
                    // Get jumlah agunan dengan jenis agunan ini
                    var jumlahAgunan = ListAgunan.Where(x => x.RFMappingAgunan2Id == jenisAgunan.Id).ToList().Count;

                    // Get relevant RFDocumentAgunan
                    var ListRFDocumentAgunan = await _RFDocumentAgunan.GetListByPredicate(x=> x.ColCode == jenisAgunan.ColCode);

                    // Get semua dokumen untuk jenis agunan ini
                    var ListJenisDokumen = await _RFDocument.GetListByPredicate(x=> ListRFDocumentAgunan.Select(y=>y.DocCode).ToList().Contains(x.DocCode));

                    // Get RF collateral
                    var collateral = await _RFColLateralBC.GetByPredicate(x=> x.ColCode == jenisAgunan.ColCode);

                    // Cek gap per dokumen

                    foreach (var dokumen in ListJenisDokumen)
                    {
                        var gap = jumlahAgunan - ListPrescreeningDokumen.Where(x=>x.RFDocumentId == dokumen.Id).ToList().Count;

                        // Fill gap if exist   
                        if (gap > 0){
                            for (int i = 0; i < gap; i++)
                            {
                                ListNewDocument.Add(new PrescreeningDokumen(){
                                    PrescreeningId = Prescreening.Id,
                                    RFDocumentId = dokumen.Id,
                                    RFTipeDokumenId = RFTipeDokumen.Id,
                                    RFStatusDokumenId = RFStatusDokumen.Id,
                                    RFCollateralBCId = collateral.Id
                                });
                            }
                        }
                    }
                }

                // Add new documents template
                await _PrescreeningDokumen.AddRangeAsync(ListNewDocument);

                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.2");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "4.2.1");

                if (SlikRequest.App.Prospect.Stage.Code == "4.2.2")
                {
                    var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed(
                        (int)HttpStatusCode.BadRequest,
                        "SLIK Request sudah diproses sebelumnya"
                    );
                    failResp.Success = false;
                    return failResp;
                }

                if (SlikRequest.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed(
                        (int)HttpStatusCode.BadRequest,
                        "SLIK Request sudah ditolak sebelumnya"
                    );
                    failResp.Success = false;
                    return failResp;
                }

                SlikRequest.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                SlikRequest.App.Prospect.PreviousStage = previousStage;
                SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
                SlikRequest.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(
                    x =>
                        x.Prospect.Id == SlikRequest.App.Prospect.Id
                        && x.StageId == previousStage.StageId
                );
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs
                {
                    ProspectId = SlikRequest.App.Prospect.Id,
                    StageId = stageFound.StageId,
                    ExecutedBy = request.NamaUser
                };

                await _stageLogs.AddAsync(newLog);

                var response = new SlikRequestProsesResponse
                {
                    AppId = SlikRequest.App.Id,
                    SlikRequestId = SlikRequest.Id,
                    PrescreeningId = Prescreening.Id,
                    Stage = stageFound.Description,
                    Message = "SlikRequest berhasil diproses ke Prescreening"
                };


                return ServiceResponse<SlikRequestProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed(
                    (int)HttpStatusCode.BadRequest,
                    ex.InnerException != null ? ex.InnerException.Message : ex.Message
                );
                response.Success = false;
                return response;
            }
        }
    }
}
