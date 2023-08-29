using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFPengikatanKredits;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFPengikatanKredits.Commands
{
    public class RFPengikatanKreditDeleteCommand : RFPengikatanKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFPengikatKreditCommandHandler : IRequestHandler<RFPengikatanKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFPengikatanKredit> _RFPengikatKredit;
        private readonly IMapper _mapper;

        public DeleteRFPengikatKreditCommandHandler(IGenericRepositoryAsync<RFPengikatanKredit> RFPengikatKredit, IMapper mapper)
        {
            _RFPengikatKredit = RFPengikatKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFPengikatanKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFPengikatKredit.GetByIdAsync(request.PK_CODE, "PK_CODE");
            rFProduct.IsDeleted = true;
            await _RFPengikatKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}