using Bjb.DigitalBisnis.SLIK.Models.GetResult;
using Bjb.DigitalBisnis.SLIK.Models.Inquiry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Tests.Commands;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.v2
{
    [ApiVersion("2.0")]
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
            _logger.LogError("TEST LOG TO SQL");
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
    }
}
