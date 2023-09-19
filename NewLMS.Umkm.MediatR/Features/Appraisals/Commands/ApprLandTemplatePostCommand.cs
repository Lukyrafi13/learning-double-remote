using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        private readonly IMapper _mapper;

        public PostApprLandTemplateCommandHandler(IGenericRepositoryAsync<ApprLandTemplates> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprLandTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataLand = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
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

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
