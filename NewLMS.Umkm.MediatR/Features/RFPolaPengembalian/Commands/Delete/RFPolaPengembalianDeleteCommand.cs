using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPolaPengembalians;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPolaPengembalians.Commands
{
    public class RFPolaPengembalianDeleteCommand : RFPolaPengembalianFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFPolaPengembalianCommandHandler : IRequestHandler<RFPolaPengembalianDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFPolaPengembalian> _RFPolaPengembalian;
        private readonly IMapper _mapper;

        public DeleteRFPolaPengembalianCommandHandler(IGenericRepositoryAsync<RFPolaPengembalian> RFPolaPengembalian, IMapper mapper){
            _RFPolaPengembalian = RFPolaPengembalian;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFPolaPengembalianDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFPolaPengembalian.GetByIdAsync(request.PolaCode, "PolaCode");
            rFProduct.IsDeleted = true;
            await _RFPolaPengembalian.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}