using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranchess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBranchess.Commands
{
    public class RfBranchesDeleteCommand : RfBranchesFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRfBranchesCommandHandler : IRequestHandler<RfBranchesDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfBranches> _RfBranches;
        private readonly IMapper _mapper;

        public DeleteRfBranchesCommandHandler(IGenericRepositoryAsync<RfBranches> RfBranches, IMapper mapper)
        {
            _RfBranch = RfBranches;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfBranchesDeleteCommand request, CancellationToken cancellationToken)
        {
            var RfBranch = await _RfBranches.GetByIdAsync(request.Code, "Code");
            RfBranches.IsDeleted = true;
            await _RfBranches.UpdateAsync(RfBranches);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}