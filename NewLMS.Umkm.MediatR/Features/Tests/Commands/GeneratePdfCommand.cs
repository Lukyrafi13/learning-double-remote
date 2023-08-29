using Bjb.Util.GeneratePdf.Interfaces;
using Bjb.Util.GeneratePdf.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Tests.Commands
{
    public class GeneratePdfCommand : IRequest<Byte[]>
    {
        public string Template { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public string StyleSheet { get; set; }
    }

    public class GeneratePdfCommandHandler : IRequestHandler<GeneratePdfCommand, byte[]>
    {
        private readonly IGeneratePdf _generatePdf;

        public GeneratePdfCommandHandler(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public async Task<byte[]> Handle(GeneratePdfCommand request, CancellationToken cancellationToken)
        {
            return GeneratePdfWithSytleSheet.GeneratePdf(request.Template, request.Data, request.StyleSheet,  1,1,1,1,WkHtmlToPdfDotNet.PaperKind.A4, WkHtmlToPdfDotNet.Orientation.Portrait, WkHtmlToPdfDotNet.ColorMode.Color);
        }
    }
}
