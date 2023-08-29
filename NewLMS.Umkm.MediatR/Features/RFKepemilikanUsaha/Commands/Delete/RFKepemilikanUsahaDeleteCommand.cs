using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKepemilikanUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanUsahas.Commands
{
    public class RFKepemilikanUsahaDeleteCommand : RFKepemilikanUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFKepemilikanUsahaCommandHandler : IRequestHandler<RFKepemilikanUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanUsaha> _RFKepemilikanUsaha;
        private readonly IMapper _mapper;

        public DeleteRFKepemilikanUsahaCommandHandler(IGenericRepositoryAsync<RFKepemilikanUsaha> RFKepemilikanUsaha, IMapper mapper){
            _RFKepemilikanUsaha = RFKepemilikanUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFKepemilikanUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFKepemilikanUsaha.GetByIdAsync(request.KepemilikanUsahaId, "KepemilikanUsahaId");
            rFProduct.IsDeleted = true;
            await _RFKepemilikanUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}