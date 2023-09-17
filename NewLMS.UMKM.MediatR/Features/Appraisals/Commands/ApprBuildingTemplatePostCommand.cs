﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands
{
    public class ApprBuildingTemplatePostCommand : AppraisalBuildingTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprBuildingTemplatePostCommandHandler : IRequestHandler<ApprBuildingTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _appr;
        private readonly IMapper _mapper;

        public ApprBuildingTemplatePostCommandHandler(IGenericRepositoryAsync<ApprBuildingTemplates> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
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

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}