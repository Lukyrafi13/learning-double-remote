using Bjb.DigitalBisnis.SLIK.Interfaces;
using Bjb.DigitalBisnis.SLIK.Models.Inquiry;
using MediatR;
using NewLMS.UMKM.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class InquirySlikIndividualCommand : SlikInquiryIndividualRequest,IRequest<ServiceResponse<SlikInquiryResponse>>
    {
    }
    public class InquirySlikIndividualCommandHandler : IRequestHandler<InquirySlikIndividualCommand, ServiceResponse<SlikInquiryResponse>>
    {
        private readonly ISlikService _slikService;

        public InquirySlikIndividualCommandHandler(ISlikService slikService)
        {
            _slikService = slikService;
        }

        public async Task<ServiceResponse<SlikInquiryResponse>> Handle(InquirySlikIndividualCommand request, CancellationToken cancellationToken)
        {
            var res = await _slikService.InquiryIndividual(request);
            return ServiceResponse<SlikInquiryResponse>.ReturnResultWith200(res);
        }
    }
}
