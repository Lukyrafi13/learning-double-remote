using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHMAKERs.Commands
{
    public class RFVEHMAKERDeleteCommand : RFVEHMAKERFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFVEHMAKERCommandHandler : IRequestHandler<RFVEHMAKERDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFVEHMAKER> _RFVEHMAKER;
        private readonly IMapper _mapper;

        public DeleteRFVEHMAKERCommandHandler(IGenericRepositoryAsync<RFVEHMAKER> RFVEHMAKER, IMapper mapper){
            _RFVEHMAKER = RFVEHMAKER;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFVEHMAKERDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFVEHMAKER.GetByIdAsync(request.VMKR_CODE, "VMKR_CODE");
            rFProduct.IsDeleted = true;
            await _RFVEHMAKER.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}