using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationStageProcess;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationStageProcess.Commands
{
    public class LoanAppStageProcessApprAsignmentCommand : LoanApplicationStageProcessRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanAppStageProcessApprAsignmentCommandHandler : IRequestHandler<LoanAppStageProcessApprAsignmentCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IGenericRepositoryAsync<ApprLandTemplates> _apprLandTemplate;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuildingTemplate;
        private readonly IMapper _mapper;

        public LoanAppStageProcessApprAsignmentCommandHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal,
            IGenericRepositoryAsync<ApprLandTemplates> apprLandTemplate,
            IGenericRepositoryAsync<ApprBuildingTemplates> apprBuildingTemplate,
            IMapper mapper)
        {
            _appraisal = appraisal;
            _apprLandTemplate = apprLandTemplate;
            _apprBuildingTemplate = apprBuildingTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppStageProcessApprAsignmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var includeappraisal = new string[]
                {
                    "LoanApplicationCollateral",
                    "LoanApplicationCollateral.RfDocument",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner",
                };
                var appraisalData = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId, includeappraisal);
                if (appraisalData != null)
                {
                    appraisalData.StageId = LMSUMKMStages.AppraisalSurveyor.StageId;//Appr Surveyor
                    await _appraisal.UpdateAsync(appraisalData);

                    await SetValueAppraisalTemplate();

                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data Tidak Ditemukan, Gagal Proses Stage");
                }


                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

                async Task SetValueAppraisalTemplate()
                {
                    //Set Value Template Tanah from Collateral(Rumah Tapak, Tanah Kosong)
                    if (appraisalData.LoanApplicationCollateral.CollateralBCId == "176"
                        || appraisalData.LoanApplicationCollateral.CollateralBCId == "187")
                    {
                        var apprLandTemplate = await _apprLandTemplate.GetByPredicate(x => x.AppraisalGuid == appraisalData.AppraisalId);

                        if (apprLandTemplate == null)
                        {
                            var apprLandTemplateNew = new ApprLandTemplates
                            {
                                ApprLandTemplateGuid = Guid.NewGuid(),
                                AppraisalGuid = appraisalData.AppraisalId,
                                CertificateType = appraisalData.LoanApplicationCollateral.RfDocument.ParameterAppraisalGuid,
                                CertficateNumber = appraisalData.LoanApplicationCollateral.DocumentNumber,
                                CollateralOwner = appraisalData.LoanApplicationCollateral.LoanApplicationCollateralOwner.OwnerName,
                            };

                            await _apprLandTemplate.AddAsync(apprLandTemplateNew);
                        }
                    }

                    //Set Value Template Bangunan(Rumah Tapak, Rumah Toko, Rumah Susun, Kios)
                    if (appraisalData.LoanApplicationCollateral.CollateralBCId == "176"
                        || appraisalData.LoanApplicationCollateral.CollateralBCId == "113"
                        || appraisalData.LoanApplicationCollateral.CollateralBCId == "102"
                        || appraisalData.LoanApplicationCollateral.CollateralBCId == "112")
                    {
                        var apprBuildingTemplate = await _apprBuildingTemplate.GetByPredicate(x => x.AppraisalGuid == appraisalData.AppraisalId);

                        if (apprBuildingTemplate == null)
                        {
                            var apprBuildingTemplateNew = new ApprBuildingTemplates
                            {
                                ApprEnvironmentGuid = Guid.NewGuid(),
                                AppraisalGuid = appraisalData.AppraisalId,
                                CollateralOwner = appraisalData.LoanApplicationCollateral.LoanApplicationCollateralOwner.OwnerName,
                            };

                            await _apprBuildingTemplate.AddAsync(apprBuildingTemplateNew);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
