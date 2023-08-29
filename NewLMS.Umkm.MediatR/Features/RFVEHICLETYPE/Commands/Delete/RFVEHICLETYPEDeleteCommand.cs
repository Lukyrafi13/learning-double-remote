using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHICLETYPEs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHICLETYPEss.Commands
{
    public class RFVEHICLETYPEDeleteCommand : RFVEHICLETYPEFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFVEHICLETYPECommandHandler : IRequestHandler<RFVEHICLETYPEDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFVEHICLETYPEs> _RFVEHICLETYPE;
        private readonly IMapper _mapper;

        public DeleteRFVEHICLETYPECommandHandler(IGenericRepositoryAsync<RFVEHICLETYPEs> RFVEHICLETYPE, IMapper mapper)
        {
            _RFVEHICLETYPE = RFVEHICLETYPE;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFVEHICLETYPEDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFVEHICLETYPE.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
            rFProduct.IsDeleted = true;
            await _RFVEHICLETYPE.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}