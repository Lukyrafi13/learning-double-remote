using MediatR;
using Microsoft.AspNetCore.Hosting;
using NewLMS.UMKM.Helper;
using System.Threading;
using System.Threading.Tasks;
using TechRedemption.UIM.Interfaces;
using TechRedemption.UIM.Models;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class LoginViaUIMCommand : IRequest<ServiceResponse<UIMNGResponse>>
    {
        public string UserId { get; set; }
        public string Password { get; set; }

    }

    public class LoginViaUIMCommandHandler : IRequestHandler<LoginViaUIMCommand, ServiceResponse<UIMNGResponse>>
    {
        private readonly IUIMService _uimService;
        private readonly IHostingEnvironment _hostingEnvinronment;
        public LoginViaUIMCommandHandler(IUIMService uimService, IHostingEnvironment hostingEnvinronment)
        {
            _uimService = uimService;
            _hostingEnvinronment = hostingEnvinronment;
        }

        public async Task<ServiceResponse<UIMNGResponse>> Handle(LoginViaUIMCommand request, CancellationToken cancellationToken)
        {
            UIMNGResponse res;

            if (_hostingEnvinronment.IsDevelopment())
            {
                res = await _uimService.LoginUIMNg(new LoginUIMRequest
                {
                    UserId = request.UserId,
                    Password = request.Password
                });
            }
            else
            {
                res = await _uimService.LoginUIMNg(new LoginUIMRequest
                {
                    UserId = request.UserId,
                    Password = request.Password
                });
            }
            return ServiceResponse<UIMNGResponse>.ReturnResultWith200(res);
        }
    }
}
