using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSandiBI;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfSandiBIs.Queries.GetByIdRfSandiBIs;
using NewLMS.UMKM.MediatR.Features.RfSandiBIs.Queries.GetFilterRfSandiBIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.KprKkb.API.Controllers.RfSandiBI
{
    [AllowAnonymous]
    public class RfSandiBIController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfSandiBIResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfSandiBIsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{RfSandiBIId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfSandiBIResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfSandiBIsGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
