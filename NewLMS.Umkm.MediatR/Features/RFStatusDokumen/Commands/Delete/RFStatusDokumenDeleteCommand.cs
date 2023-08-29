using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Commands
{
    public class RFStatusDokumenDeleteCommand : RFStatusDokumenFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFStatusDokumenCommandHandler : IRequestHandler<RFStatusDokumenDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IMapper _mapper;

        public DeleteRFStatusDokumenCommandHandler(IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen, IMapper mapper){
            _RFStatusDokumen = RFStatusDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFStatusDokumenDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFStatusDokumen.GetByIdAsync(request.StatusCode, "StatusCode");
            rFProduct.IsDeleted = true;
            await _RFStatusDokumen.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}