using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.Tests;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.SIKPs.SIKP;
using NewLMS.Umkm.MediatR.FireAndForgetJobs;
using System;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfVehType
{
    public class TestController : BaseController
    {
        public IMediator _mediator { get; set; }
        private readonly IFireAndForgetDuplicationCheck _duplicationCheckTask;

        public TestController(IMediator mediator, IFireAndForgetDuplicationCheck duplicationCheckTask)
        {
            _mediator = mediator;
            _duplicationCheckTask = duplicationCheckTask;
        }
        /// <summary>
        /// GetFilter RfVehType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("status-code/{Status}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> TestPutCommand(int Status)
        {
            var command = new TestPutCommand()
            {
                Status = Status
            };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("current-user")]
        public async Task<IActionResult> TestCurrentUser(SIKPProcessCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok("ad");
        }

        [HttpPost("duplication")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DuplicationTest([FromBody] Guid Id)
        {
            await _duplicationCheckTask.DuplicationCheck(Id);
            return Ok();
        }
    }
}
