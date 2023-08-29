using Bjb.DigitalBisnis.SLIK.Models.GetResult;
using Bjb.DigitalBisnis.SLIK.Models.Inquiry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Tests.Commands;
using NewLMS.UMKM.MediatR.Features.Tests.Queries;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers
{
    public class TestController : BaseController
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(type: typeof(ServiceResponse<>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(TestPostDataCommand command)
        {
            _logger.LogInformation("TEST LOG TO SQL");
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("inquiry-individual")]
        [ProducesResponseType(type: typeof(ServiceResponse<SlikInquiryResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> InquiryIndividual(InquirySlikIndividualCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("get-slik-individual")]
        [ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetResultIndividual(GetSlikIndividualCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("generate-pdf")]
        //[ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GeneratePdf(GeneratePdfCommand command)
        {
            var res = await Mediator.Send(command);
            return File(res, "application/pdf", "test.pdf");
        }


        [HttpPost("generate-pdf-upload")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GeneratePdf([FromForm] GeneratePdfUploadCommand command)
        {
            var res = await Mediator.Send(command);
            return File(res, "application/pdf", "test.pdf");
        }

        [HttpPost("generate-excel")]
        //[ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateExcel(GenerateExcelCommand command)
        {
            var res = await Mediator.Send(command);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "test.xlsx");
        }


        [HttpPost("login-via-uim")]
        //[ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginViaUIM([FromBody]LoginViaUIMCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("get-web-rootpath")]
        //[ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWebRootPath()
        {
            return Ok(await Mediator.Send(new GetWebRootPathCommand()));
        }
    }
}
