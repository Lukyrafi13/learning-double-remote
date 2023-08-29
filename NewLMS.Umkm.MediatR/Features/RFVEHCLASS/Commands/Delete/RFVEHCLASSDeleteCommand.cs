using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHCLASSs.Commands
{
    public class RFVEHCLASSDeleteCommand : RFVEHCLASSFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFVEHCLASSCommandHandler : IRequestHandler<RFVEHCLASSDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFVEHCLASS> _RFVEHCLASS;
        private readonly IMapper _mapper;

        public DeleteRFVEHCLASSCommandHandler(IGenericRepositoryAsync<RFVEHCLASS> RFVEHCLASS, IMapper mapper){
            _RFVEHCLASS = RFVEHCLASS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFVEHCLASSDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFVEHCLASS.GetByIdAsync(request.VCLS_CODE, "VCLS_CODE");
            rFProduct.IsDeleted = true;
            await _RFVEHCLASS.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}