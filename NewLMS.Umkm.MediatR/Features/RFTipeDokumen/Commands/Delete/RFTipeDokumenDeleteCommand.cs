using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTipeDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTipeDokumens.Commands
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