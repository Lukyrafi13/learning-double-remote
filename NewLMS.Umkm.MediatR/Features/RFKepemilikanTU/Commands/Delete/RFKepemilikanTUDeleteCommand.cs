using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKepemilikanTUs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanTUs.Commands
{
    public class RFKepemilikanTUDeleteCommand : RFKepemilikanTUFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFKepemilikanTUCommandHandler : IRequestHandler<RFKepemilikanTUDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanTU> _RFKepemilikanTU;
        private readonly IMapper _mapper;

        public DeleteRFKepemilikanTUCommandHandler(IGenericRepositoryAsync<RFKepemilikanTU> RFKepemilikanTU, IMapper mapper)
        {
            _RFKepemilikanTU = RFKepemilikanTU;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFKepemilikanTUDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFKepemilikanTU.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFKepemilikanTU.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}