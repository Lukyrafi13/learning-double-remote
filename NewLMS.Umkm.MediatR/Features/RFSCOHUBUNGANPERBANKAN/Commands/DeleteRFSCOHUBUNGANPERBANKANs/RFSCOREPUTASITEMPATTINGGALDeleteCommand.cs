using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Commands
{
    public class RFSCOHUBUNGANPERBANKANDeleteCommand : RFSCOHUBUNGANPERBANKANFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOHUBUNGANPERBANKANCommandHandler : IRequestHandler<RFSCOHUBUNGANPERBANKANDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> _RFSCOHUBUNGANPERBANKAN;
        private readonly IMapper _mapper;

        public DeleteRFSCOHUBUNGANPERBANKANCommandHandler(IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN, IMapper mapper){
            _RFSCOHUBUNGANPERBANKAN = RFSCOHUBUNGANPERBANKAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOHUBUNGANPERBANKANDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOHUBUNGANPERBANKAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOHUBUNGANPERBANKAN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}