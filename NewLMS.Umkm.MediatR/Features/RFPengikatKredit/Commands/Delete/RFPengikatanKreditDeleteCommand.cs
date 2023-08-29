using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFPengikatanKredits;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFPengikatanKredits.Commands
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