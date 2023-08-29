using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBranches.Commands
{
    public class RfBranchDeleteCommand : RfBranchFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class RfBranchDeleteCommandHandler : IRequestHandler<RfBranchDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfBranch> _RfBranch;
        private readonly IMapper _mapper;

        public RfBranchDeleteCommandHandler(IGenericRepositoryAsync<RfBranch> RfBranch, IMapper mapper)
        {
            _RfBranch = RfBranch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfBranchDeleteCommand request, CancellationToken cancellationToken)
        {
            var RfBranch = await _RfBranch.GetByIdAsync(request.Code, "Code");
            RfBranch.IsDeleted = true;
            await _RfBranch.UpdateAsync(RfBranch);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}