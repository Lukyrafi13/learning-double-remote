using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTipeDokumens;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTipeDokumens.Commands
{
    public class RFTipeDokumenDeleteCommand : RFTipeDokumenFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFTipeDokumenCommandHandler : IRequestHandler<RFTipeDokumenDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IMapper _mapper;

        public DeleteRFTipeDokumenCommandHandler(IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen, IMapper mapper){
            _RFTipeDokumen = RFTipeDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTipeDokumenDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTipeDokumen.GetByIdAsync(request.TypeCode, "TypeCode");
            rFProduct.IsDeleted = true;
            await _RFTipeDokumen.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}