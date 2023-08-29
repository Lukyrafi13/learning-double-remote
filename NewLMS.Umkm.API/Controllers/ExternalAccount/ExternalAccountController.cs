﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.ExternalAccounts.Queries.GetByNoAcc;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.ExternalAccount
{
    //[Authorize]
    [AllowAnonymous]
    public class ExternalAccountController : BaseController
    {
        /// <summary>
        /// Get ExternalAccount By NoExtAcc
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{NoExtAcc}")]
        [ProducesResponseType(type: typeof(ServiceResponse<DomainDWH.Dtos.GetExtAccByNoAccountResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExtAcc([FromRoute] GetExternalAccByNoAcc command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
