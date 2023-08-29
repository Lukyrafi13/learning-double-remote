using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCSBPDetails;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPDetails.Commands
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