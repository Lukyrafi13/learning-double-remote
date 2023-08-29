using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Commands
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