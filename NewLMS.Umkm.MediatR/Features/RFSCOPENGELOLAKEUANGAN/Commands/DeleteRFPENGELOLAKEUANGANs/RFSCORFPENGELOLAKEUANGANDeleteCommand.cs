using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Commands
{
    public class RFSCOPENGELOLAKEUANGANDeleteCommand : RFSCOPENGELOLAKEUANGANFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSCOPENGELOLAKEUANGANCommandHandler : IRequestHandler<RFSCOPENGELOLAKEUANGANDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> _rfScoPENGELOLAKEUANGAN;
        private readonly IMapper _mapper;

        public DeleteRFSCOPENGELOLAKEUANGANCommandHandler(IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> rfScoPENGELOLAKEUANGAN, IMapper mapper)
        {
            _rfScoPENGELOLAKEUANGAN = rfScoPENGELOLAKEUANGAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOPENGELOLAKEUANGANDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _rfScoPENGELOLAKEUANGAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _rfScoPENGELOLAKEUANGAN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}