using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfTargetStatuses;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Commands
{
    public class RfTargetStatusDeleteCommand : RfTargetStatusFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfTargetStatusCommandHandler : IRequestHandler<RfTargetStatusDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfTargetStatus> _rfStatusTarget;
        private readonly IMapper _mapper;

        public DeleteRfTargetStatusCommandHandler(IGenericRepositoryAsync<RfTargetStatus> rfStatusTarget, IMapper mapper){
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfTargetStatusDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFStatusTarget = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
            rFStatusTarget.IsDeleted = true;
            await _rfStatusTarget.UpdateAsync(rFStatusTarget);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}