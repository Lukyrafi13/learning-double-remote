using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ArusKasMasuks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ArusKasMasuks.Commands
{
    public class ArusKasMasukDeleteCommand : ArusKasMasukFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteArusKasMasukCommandHandler : IRequestHandler<ArusKasMasukDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
        private readonly IMapper _mapper;

        public DeleteArusKasMasukCommandHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
        {
            _ArusKasMasuk = ArusKasMasuk;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ArusKasMasukDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _ArusKasMasuk.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _ArusKasMasuk.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}