using Bjb.DigitalBisnis.DigiloanAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace Bjb.DigitalBisnis.DigiloanAPI.Delegates
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly DigiloanModel _model;
        public AuthHeaderHandler(IOptions<DigiloanModel> options)
        {
            _model = options.Value;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(
                    $"{_model.Username}:{_model.Password}")));

            return await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
