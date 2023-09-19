using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.API.Controllers;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfSandiBIGroup;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.RfSandiBIGroups.Queries.GetByIdRfSandiGroups;
using NewLMS.Umkm.MediatR.Features.RfSandiBIGroups.Queries.GetFilterRfSandiGroups;
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
