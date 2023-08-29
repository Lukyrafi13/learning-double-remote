using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBentukLahans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFBentukLahans.Commands
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