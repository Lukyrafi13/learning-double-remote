using Bjb.DigitalBisnis.SLIK.Interfaces;
using Bjb.DigitalBisnis.SLIK.Models.GetResult;
using MediatR;
using NewLMS.UMKM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class GetSlikIndividualCommand : SlikGetResultRequest,IRequest<ServiceResponse<SlikGetIndividualResultResponse>>
    {
    }

    public class GetSlikIndividualCommandHandler : IRequestHandler<GetSlikIndividualCommand, ServiceResponse<SlikGetIndividualResultResponse>>
    {
        private readonly ISlikService _slikService;

        public GetSlikIndividualCommandHandler(ISlikService slikService)
        {
            _slikService = slikService;
        }

        public async Task<ServiceResponse<SlikGetIndividualResultResponse>> Handle(GetSlikIndividualCommand request, CancellationToken cancellationToken)
        {
            var res = await _slikService.MockResultIndividualSuccess(request);
            return ServiceResponse<SlikGetIndividualResultResponse>.ReturnResultWith200(res);
        }
    }
}
