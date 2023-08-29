using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Commands
{
    public class RFApprTanahLokasiDeleteCommand : RFApprTanahLokasiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFApprTanahLokasiCommandHandler : IRequestHandler<RFApprTanahLokasiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLokasi> _RFApprTanahLokasi;
        private readonly IMapper _mapper;

        public DeleteRFApprTanahLokasiCommandHandler(IGenericRepositoryAsync<RFApprTanahLokasi> RFApprTanahLokasi, IMapper mapper)
        {
            _RFApprTanahLokasi = RFApprTanahLokasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFApprTanahLokasiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFApprTanahLokasi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
            rFProduct.IsDeleted = true;
            await _RFApprTanahLokasi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}