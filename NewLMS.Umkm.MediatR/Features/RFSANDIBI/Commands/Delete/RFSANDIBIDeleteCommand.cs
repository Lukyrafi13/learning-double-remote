using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Commands
{
    public class RFSANDIBIDeleteCommand : RFSANDIBIFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSANDIBICommandHandler : IRequestHandler<RFSANDIBIDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSANDIBI> _RFSANDIBI;
        private readonly IMapper _mapper;

        public DeleteRFSANDIBICommandHandler(IGenericRepositoryAsync<RFSANDIBI> RFSANDIBI, IMapper mapper)
        {
            _RFSANDIBI = RFSANDIBI;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSANDIBIDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSANDIBI.GetByIdAsync(request.BI_CODE, "BI_CODE");
            rFProduct.IsDeleted = true;
            await _RFSANDIBI.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}