using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.AppraisalWorkPapers.Commands
{
    public class ApprLiquidationPostCommand : ApprLiquidationPostRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid LiquidationGuid;
    }

    public class PostApprLiquidationCommandHandler : IRequestHandler<ApprLiquidationPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprLiquidation> _liquidation;
        private readonly IMapper _mapper;

        public PostApprLiquidationCommandHandler(
            IGenericRepositoryAsync<ApprLiquidation> liquidation,
            IMapper mapper)
        {
            _liquidation = liquidation;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprLiquidationPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // var dataVm = _mapper.Map<ApprLiquidation>(request);
                var apprEntity = await _liquidation.GetByIdAsync(request.LiquidationGuid, "LiquidationGuid");
                if (apprEntity != null)
                {
                    // dataVm.LiquidationGuid = apprEntity.LiquidationGuid;
                    // dataVm.AppraisalGuid = apprEntity.AppraisalGuid;
                    // dataVm = HelperGeneral.UpdateBaseEntityTime(dataVm, apprEntity);
                    apprEntity.LiquidationOption = request.LiquidationOption;
                    apprEntity.LiquidationScore = request.LiquidationScore;

                    await _liquidation.UpdateAsync(apprEntity);
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
