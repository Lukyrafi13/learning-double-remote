﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Data.Dto.Tests;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.SIKPs.SIKP;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfVehType
{
    public class TestController : BaseController
    {
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
    }
}
