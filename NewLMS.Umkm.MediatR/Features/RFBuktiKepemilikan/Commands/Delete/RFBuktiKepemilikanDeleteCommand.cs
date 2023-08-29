using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Commands
{
    public class RFBuktiKepemilikanDeleteCommand : RFBuktiKepemilikanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFBuktiKepemilikanCommandHandler : IRequestHandler<RFBuktiKepemilikanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBuktiKepemilikan> _RFBuktiKepemilikan;
        private readonly IMapper _mapper;

        public DeleteRFBuktiKepemilikanCommandHandler(IGenericRepositoryAsync<RFBuktiKepemilikan> RFBuktiKepemilikan, IMapper mapper){
            _RFBuktiKepemilikan = RFBuktiKepemilikan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBuktiKepemilikanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBuktiKepemilikan.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFBuktiKepemilikan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}