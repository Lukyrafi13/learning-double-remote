using Bjb.Util.GeneratePdf.Interfaces;
using Bjb.Util.GeneratePdf.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class GeneratePdfUploadCommand : IRequest<Byte[]>
    {
        public IFormFile Files { get; set; }
        // public string Template { get; set; }
        // public Dictionary<string, string> Data { get; set; }
        // public string StyleSheet { get; set; }
    }

    public class GeneratePdfUploadCommandHandler : IRequestHandler<GeneratePdfUploadCommand, byte[]>
    {
        private readonly IGeneratePdf _generatePdf;

        public GeneratePdfUploadCommandHandler(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public async Task<byte[]> Handle(GeneratePdfUploadCommand request, CancellationToken cancellationToken)
        {
            var template = await ReadFormFileAsync(request.Files);
            var dictionary = new Dictionary<string, string>();
            var style = "";
           
            return GeneratePdfWithSytleSheet.GeneratePdf(template, dictionary, style,1,1,1,1,WkHtmlToPdfDotNet.PaperKind.A4, WkHtmlToPdfDotNet.Orientation.Portrait, WkHtmlToPdfDotNet.ColorMode.Color);
        }

        public static async Task<string> ReadFormFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
