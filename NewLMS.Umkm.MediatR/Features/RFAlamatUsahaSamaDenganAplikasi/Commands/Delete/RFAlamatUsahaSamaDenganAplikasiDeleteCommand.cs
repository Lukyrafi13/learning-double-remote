using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands
{
    public class RFAlamatUsahaSamaDenganAplikasiDeleteCommand : RFAlamatUsahaSamaDenganAplikasiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFAlamatUsahaSamaDenganAplikasiCommandHandler : IRequestHandler<RFAlamatUsahaSamaDenganAplikasiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> _RFAlamatUsahaSamaDenganAplikasi;
        private readonly IMapper _mapper;

        public DeleteRFAlamatUsahaSamaDenganAplikasiCommandHandler(IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> RFAlamatUsahaSamaDenganAplikasi, IMapper mapper)
        {
            _RFAlamatUsahaSamaDenganAplikasi = RFAlamatUsahaSamaDenganAplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFAlamatUsahaSamaDenganAplikasiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFAlamatUsahaSamaDenganAplikasi.GetByIdAsync(request.StatusAlamat_Code, "StatusAlamat_Code");
            rFProduct.IsDeleted = true;
            await _RFAlamatUsahaSamaDenganAplikasi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}