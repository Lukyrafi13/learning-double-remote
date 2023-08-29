using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands
{
    public class RFSCOTINGKATKEBUTUHANDeleteCommand : RFSCOTINGKATKEBUTUHANFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSCOTINGKATKEBUTUHANCommandHandler : IRequestHandler<RFSCOTINGKATKEBUTUHANDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> _RFSCOTINGKATKEBUTUHAN;
        private readonly IMapper _mapper;

        public DeleteRFSCOTINGKATKEBUTUHANCommandHandler(IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN, IMapper mapper)
        {
            _RFSCOTINGKATKEBUTUHAN = RFSCOTINGKATKEBUTUHAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOTINGKATKEBUTUHANDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOTINGKATKEBUTUHAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOTINGKATKEBUTUHAN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}