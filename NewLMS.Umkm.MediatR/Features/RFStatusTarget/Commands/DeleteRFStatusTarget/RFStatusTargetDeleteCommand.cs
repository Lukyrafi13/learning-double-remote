using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFStatusTargets.Commands
{
    public class RFStatusTargetDeleteCommand : RFStatusTargetFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFStatusTargetCommandHandler : IRequestHandler<RFStatusTargetDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFStatusTarget> _rfStatusTarget;
        private readonly IMapper _mapper;

        public DeleteRFStatusTargetCommandHandler(IGenericRepositoryAsync<RFStatusTarget> rfStatusTarget, IMapper mapper){
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFStatusTargetDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFStatusTarget = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
            rFStatusTarget.IsDeleted = true;
            await _rfStatusTarget.UpdateAsync(rFStatusTarget);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}