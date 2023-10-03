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
    public class ApprBuildingTemplatePostCommand : AppraisalBuildingTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprBuildingTemplatePostCommandHandler : IRequestHandler<ApprBuildingTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _appr;
        private readonly IGenericRepositoryAsync<ApprLandTemplates> _apprLandTemplate;
        private readonly IMapper _mapper;

        public ApprBuildingTemplatePostCommandHandler(
            IGenericRepositoryAsync<ApprBuildingTemplates> appr,
            IGenericRepositoryAsync<ApprLandTemplates> apprLandTemplate,
            IMapper mapper)
        {
            _appr = appr;
            _apprLandTemplate = apprLandTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var include = new string[]
                {
                    "LoanApplicationAppraisal.LoanApplicationCollateral"
                };
                var data = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, include);
                var apprEntity = _mapper.Map<ApprBuildingTemplates>(request);
                if (data == null)
                {
                    apprEntity.ApprEnvironmentGuid = Guid.NewGuid();
                    await _appr.AddAsync(apprEntity);
                }
                else
                {
                    apprEntity.ApprEnvironmentGuid = data.ApprEnvironmentGuid;
                    apprEntity = HelperGeneral.UpdateBaseEntityTime(apprEntity, data);

                    await _appr.UpdateAsync(apprEntity);
                }

                if(data.LoanApplicationAppraisal.LoanApplicationCollateral.CollateralBCId == "176")
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
                var dataLandTemplate = await _apprLandTemplate.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (dataLandTemplate == null)
                {
                    dataLandTemplate.ApprLandTemplateGuid = Guid.NewGuid();
                    dataLandTemplate.AppraisalGuid = request.AppraisalGuid;
                    dataLandTemplate.ObjectType = request.ObjectType;
                    dataLandTemplate.InspectionDate = request.InspectionDate;
                    dataLandTemplate.ObjectStatus = request.ObjectStatus;
                    dataLandTemplate.Inhabited = request.Inhabited;
                    dataLandTemplate.CollateralOwner = request.CollateralOwner;
                    await _apprLandTemplate.AddAsync(dataLandTemplate);
                }
                else
                {
                    dataLandTemplate.ObjectType = request.ObjectType;
                    dataLandTemplate.InspectionDate = request.InspectionDate;
                    dataLandTemplate.ObjectStatus = request.ObjectStatus;
                    dataLandTemplate.Inhabited = request.Inhabited;
                    dataLandTemplate.CollateralOwner = request.CollateralOwner;
                    await _apprLandTemplate.UpdateAsync(dataLandTemplate);
                }
            }
        }
    }
}
