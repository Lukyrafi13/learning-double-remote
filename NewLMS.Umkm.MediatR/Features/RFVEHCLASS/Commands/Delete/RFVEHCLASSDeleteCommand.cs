using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Commands
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