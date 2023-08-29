using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NewLMS.Umkm.Maps.Models;
using System.Net.Http.Headers;
using System.Text;

namespace NewLMS.Umkm.Maps.Delegates
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly SalesMonitoringModel _model;
        public AuthHeaderHandler(IOptions<SalesMonitoringModel> options)
        {
            _model = options.Value;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(
                    $"{_model.Username}:{_model.Password}")));

            return await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
