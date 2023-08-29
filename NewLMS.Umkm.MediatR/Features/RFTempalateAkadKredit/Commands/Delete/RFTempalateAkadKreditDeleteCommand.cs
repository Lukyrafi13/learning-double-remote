using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTempalateAkadKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFTempalateAkadKredits.Commands
{
    public class RFTempalateAkadKreditDeleteCommand : RFTempalateAkadKreditFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFTempalateAkadKreditCommandHandler : IRequestHandler<RFTempalateAkadKreditDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTempalateAkadKredit> _RFTempalateAkadKredit;
        private readonly IMapper _mapper;

        public DeleteRFTempalateAkadKreditCommandHandler(IGenericRepositoryAsync<RFTempalateAkadKredit> RFTempalateAkadKredit, IMapper mapper)
        {
            _RFTempalateAkadKredit = RFTempalateAkadKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTempalateAkadKreditDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTempalateAkadKredit.GetByIdAsync(request.TermDesc, "TermDesc");
            rFProduct.IsDeleted = true;
            await _RFTempalateAkadKredit.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}