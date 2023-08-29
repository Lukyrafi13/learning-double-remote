using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Commands
{
    public class RFJenisDuplikasiDeleteCommand : RFJenisDuplikasiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFJenisDuplikasiCommandHandler : IRequestHandler<RFJenisDuplikasiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        private readonly IMapper _mapper;

        public DeleteRFJenisDuplikasiCommandHandler(IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi, IMapper mapper){
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJenisDuplikasiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJenisDuplikasi.GetByIdAsync(request.JenisCode, "JenisCode");
            rFProduct.IsDeleted = true;
            await _RFJenisDuplikasi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}