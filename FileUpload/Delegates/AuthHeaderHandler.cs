using Microsoft.Extensions.Options;
using NewLMS.UMKM.FileUpload.Models;
using System.Net.Http.Headers;
using System.Text;

namespace NewLMS.UMKM.FileUpload.Delegates
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly FileUploadModel _model;
        public AuthHeaderHandler(IOptions<FileUploadModel> options)
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
