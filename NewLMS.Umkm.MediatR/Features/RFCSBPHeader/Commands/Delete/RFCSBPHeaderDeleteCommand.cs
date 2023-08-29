using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCSBPHeaders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPHeaders.Commands
{
    public class RFCSBPHeaderDeleteCommand : RFCSBPHeaderFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFCSBPHeaderCommandHandler : IRequestHandler<RFCSBPHeaderDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPHeader> _RFCSBPHeader;
        private readonly IMapper _mapper;

        public DeleteRFCSBPHeaderCommandHandler(IGenericRepositoryAsync<RFCSBPHeader> RFCSBPHeader, IMapper mapper)
        {
            _RFCSBPHeader = RFCSBPHeader;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFCSBPHeaderDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFCSBPHeader.GetByIdAsync(request.CSBPGroupID, "CSBPGroupID");
            rFProduct.IsDeleted = true;
            await _RFCSBPHeader.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}