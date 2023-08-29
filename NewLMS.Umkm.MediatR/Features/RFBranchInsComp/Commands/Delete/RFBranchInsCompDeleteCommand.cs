using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBranchInsComps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBranchInsComps.Commands
{
    public class RFBranchInsCompDeleteCommand : RFBranchInsCompFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFBranchInsCompCommandHandler : IRequestHandler<RFBranchInsCompDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBranchInsComp> _RFBranchInsComp;
        private readonly IMapper _mapper;

        public DeleteRFBranchInsCompCommandHandler(IGenericRepositoryAsync<RFBranchInsComp> RFBranchInsComp, IMapper mapper){
            _RFBranchInsComp = RFBranchInsComp;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBranchInsCompDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBranchInsComp.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFBranchInsComp.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}