using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSatuanKapasitass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSatuanKapasitass.Commands
{
    public class RFSatuanKapasitasDeleteCommand : RFSatuanKapasitasFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSatuanKapasitasCommandHandler : IRequestHandler<RFSatuanKapasitasDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanKapasitas> _RFSatuanKapasitas;
        private readonly IMapper _mapper;

        public DeleteRFSatuanKapasitasCommandHandler(IGenericRepositoryAsync<RFSatuanKapasitas> RFSatuanKapasitas, IMapper mapper)
        {
            _RFSatuanKapasitas = RFSatuanKapasitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSatuanKapasitasDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSatuanKapasitas.GetByIdAsync(request.SatuanKapasitas_Id, "SatuanKapasitas_Id");
            rFProduct.IsDeleted = true;
            await _RFSatuanKapasitas.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}