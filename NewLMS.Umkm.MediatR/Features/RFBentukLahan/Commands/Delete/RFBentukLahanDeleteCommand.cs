using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFBentukLahans.Commands
{
    public class RFBentukLahanDeleteCommand : RFBentukLahanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFBentukLahanCommandHandler : IRequestHandler<RFBentukLahanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBentukLahan> _RFBentukLahan;
        private readonly IMapper _mapper;

        public DeleteRFBentukLahanCommandHandler(IGenericRepositoryAsync<RFBentukLahan> RFBentukLahan, IMapper mapper)
        {
            _RFBentukLahan = RFBentukLahan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBentukLahanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBentukLahan.GetByIdAsync(request.BentukLahan_Id, "BentukLahan_Id");
            rFProduct.IsDeleted = true;
            await _RFBentukLahan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}