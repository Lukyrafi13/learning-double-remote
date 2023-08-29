using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Commands
{
    public class RFSifatKreditDeleteCommand : RFSifatKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSifatKreditCommandHandler : IRequestHandler<RFSifatKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSifatKredit> _RFSifatKredit;
        private readonly IMapper _mapper;

        public DeleteRFSifatKreditCommandHandler(IGenericRepositoryAsync<RFSifatKredit> RFSifatKredit, IMapper mapper){
            _RFSifatKredit = RFSifatKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSifatKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSifatKredit.GetByIdAsync(request.SKCode, "SKCode");
            rFProduct.IsDeleted = true;
            await _RFSifatKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}