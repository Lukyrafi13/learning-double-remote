using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPilihanPemutuss;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPilihanPemutuss.Commands
{
    public class RFPilihanPemutusDeleteCommand : RFPilihanPemutusFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFPilihanPemutusCommandHandler : IRequestHandler<RFPilihanPemutusDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFPilihanPemutus> _RFPilihanPemutus;
        private readonly IMapper _mapper;

        public DeleteRFPilihanPemutusCommandHandler(IGenericRepositoryAsync<RFPilihanPemutus> RFPilihanPemutus, IMapper mapper){
            _RFPilihanPemutus = RFPilihanPemutus;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFPilihanPemutusDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFPilihanPemutus.GetByIdAsync(request.PemCode, "PemCode");
            rFProduct.IsDeleted = true;
            await _RFPilihanPemutus.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}