using MediatR;
using Microsoft.AspNetCore.Hosting;
using NewLMS.UMKM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class GetWebRootPathCommand : IRequest<ServiceResponse<string>>
    {
    }

    public class GetWebRootPathCommandHandler : IRequestHandler<GetWebRootPathCommand, ServiceResponse<string>>
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public GetWebRootPathCommandHandler(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public Task<ServiceResponse<string>> Handle(GetWebRootPathCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(ServiceResponse<string>.ReturnResultWith200(_hostingEnvironment.WebRootPath));
        }
    }
}
