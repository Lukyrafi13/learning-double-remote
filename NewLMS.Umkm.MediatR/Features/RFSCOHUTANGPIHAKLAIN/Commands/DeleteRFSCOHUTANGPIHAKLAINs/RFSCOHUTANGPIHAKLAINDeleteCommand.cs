using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUTANGPIHAKLAINs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Commands
{
    public class RFSCOHUTANGPIHAKLAINDeleteCommand : RFSCOHUTANGPIHAKLAINFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOHUTANGPIHAKLAINCommandHandler : IRequestHandler<RFSCOHUTANGPIHAKLAINDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> _RFSCOHUTANGPIHAKLAIN;
        private readonly IMapper _mapper;

        public DeleteRFSCOHUTANGPIHAKLAINCommandHandler(IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN, IMapper mapper){
            _RFSCOHUTANGPIHAKLAIN = RFSCOHUTANGPIHAKLAIN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOHUTANGPIHAKLAINDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOHUTANGPIHAKLAIN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOHUTANGPIHAKLAIN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}