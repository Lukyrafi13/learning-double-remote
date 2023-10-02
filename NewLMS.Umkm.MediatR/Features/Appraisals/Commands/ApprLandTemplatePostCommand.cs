using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands
{
    public class ApprLandTemplatePostCommand : AppraisalLandTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostApprLandTemplateCommandHandler : IRequestHandler<ApprLandTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprLandTemplates> _appr;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuildingTemplate;
        private readonly IMapper _mapper;

        public PostApprLandTemplateCommandHandler(
            IGenericRepositoryAsync<ApprLandTemplates> appr,
            IGenericRepositoryAsync<ApprBuildingTemplates> apprBuildingTemplate,
            IMapper mapper)
        {
            _appr = appr;
            _apprBuildingTemplate = apprBuildingTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprLandTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var include = new string[]
                {
                    "LoanApplicationAppraisal.LoanApplicationCollateral"
                };
                var dataLand = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, include);
                var apprEntity = _mapper.Map<ApprLandTemplates>(request);
                if (dataLand == null)
                {
                    apprEntity.ApprLandTemplateGuid = Guid.NewGuid();
                    await _appr.AddAsync(apprEntity);
                }
                else
                {
                    apprEntity.ApprLandTemplateGuid = dataLand.ApprLandTemplateGuid;
                    apprEntity = HelperGeneral.UpdateBaseEntityTime(apprEntity, dataLand);

                    await _appr.UpdateAsync(apprEntity);
                }

                //Cek Collateral
                if (dataLand.LoanApplicationAppraisal.LoanApplicationCollateral.CollateralBCId == "176")
                {
                    await UpdateBuildingTemplate();
                }



                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

            async Task UpdateBuildingTemplate()
            {
                var dataBuildingTemplate = await _apprBuildingTemplate.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (dataBuildingTemplate == null)
                {
                    dataBuildingTemplate.ApprEnvironmentGuid = Guid.NewGuid();
                    dataBuildingTemplate.AppraisalGuid = request.AppraisalGuid;
                    dataBuildingTemplate.ObjectType = request.ObjectType;
                    dataBuildingTemplate.InspectionDate = request.InspectionDate;
                    dataBuildingTemplate.ObjectStatus = request.ObjectStatus;
                    dataBuildingTemplate.Inhabited = request.Inhabited;
                    dataBuildingTemplate.CollateralOwner = request.CollateralOwner;
                    await _apprBuildingTemplate.AddAsync(dataBuildingTemplate);
                }
                else
                {
                    dataBuildingTemplate.ObjectType = request.ObjectType;
                    dataBuildingTemplate.InspectionDate = request.InspectionDate;
                    dataBuildingTemplate.ObjectStatus = request.ObjectStatus;
                    dataBuildingTemplate.Inhabited = request.Inhabited;
                    dataBuildingTemplate.CollateralOwner = request.CollateralOwner;
                    await _apprBuildingTemplate.UpdateAsync(dataBuildingTemplate);
                }
            }
        }
    }
}
