using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSandiBIGroup;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfSandiBIGroups.Queries.GetByIdRfSandiGroups;
using NewLMS.UMKM.MediatR.Features.RfSandiBIGroups.Queries.GetFilterRfSandiGroups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.KprKkb.API.Controllers.RfSandiBIGroup
{
    [AllowAnonymous]
    public class RfSandiBIGroupController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfSandiBIGroupResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfSandiBIGroupGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{BIGroup}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfSandiBIGroupResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfSandiGroupsGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
