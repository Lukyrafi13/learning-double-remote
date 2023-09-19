using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalVehicle;
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
    public class ApprVehicleTemplatePostCommand : ApprVehicleTemplatePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprVehicleTemplatePostCommandHandler : IRequestHandler<ApprVehicleTemplatePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprVehicleTemplate> _appr;
        private readonly IMapper _mapper;

        public ApprVehicleTemplatePostCommandHandler(IGenericRepositoryAsync<ApprVehicleTemplate> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprVehicleTemplatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                var apprEntity = _mapper.Map<ApprVehicleTemplate>(request);
                if (data == null)
                {
                    apprEntity.ApprVehicleTemplateGuid = Guid.NewGuid();
                    await _appr.AddAsync(apprEntity);
                }
                else
                {
                    apprEntity.ApprVehicleTemplateGuid = data.ApprVehicleTemplateGuid;
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
