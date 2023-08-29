using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCaraPengikatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFCaraPengikatans.Commands
{
    public class RFCaraPengikatanDeleteCommand : RFCaraPengikatanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFCaraPengikatanCommandHandler : IRequestHandler<RFCaraPengikatanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFCaraPengikatan> _RFCaraPengikatan;
        private readonly IMapper _mapper;

        public DeleteRFCaraPengikatanCommandHandler(IGenericRepositoryAsync<RFCaraPengikatan> RFCaraPengikatan, IMapper mapper)
        {
            _RFCaraPengikatan = RFCaraPengikatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFCaraPengikatanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFCaraPengikatan.GetByIdAsync(request.PK_CODE, "PK_CODE");
            rFProduct.IsDeleted = true;
            await _RFCaraPengikatan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}