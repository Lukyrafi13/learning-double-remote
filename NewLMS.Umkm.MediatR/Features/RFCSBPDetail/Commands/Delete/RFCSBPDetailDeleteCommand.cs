using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCSBPDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPDetails.Commands
{
    public class RFCSBPDetailDeleteCommand : RFCSBPDetailFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFCSBPDetailCommandHandler : IRequestHandler<RFCSBPDetailDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPDetail> _RFCSBPDetail;
        private readonly IMapper _mapper;

        public DeleteRFCSBPDetailCommandHandler(IGenericRepositoryAsync<RFCSBPDetail> RFCSBPDetail, IMapper mapper)
        {
            _RFCSBPDetail = RFCSBPDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFCSBPDetailDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFCSBPDetail.GetByIdAsync(request.CSBPDetailID, "CSBPDetailID");
            rFProduct.IsDeleted = true;
            await _RFCSBPDetail.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}