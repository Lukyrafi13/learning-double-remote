using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Commands
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