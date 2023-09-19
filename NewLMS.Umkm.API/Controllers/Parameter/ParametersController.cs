using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Parameter.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.Parameter
{
    public class ParametersController : BaseController
    {
        [HttpGet("get-by-code/{ParameterGroupCode}")]
        [ProducesResponseType(type: typeof(ServiceResponse<List<SimpleResponse<Guid>>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParameter([FromRoute] string ParameterGroupCode)
        {
            return Ok(await Mediator.Send(new GetParameterByCodeQuery
            {
                ParameterGroupCode = ParameterGroupCode
            }));
        }
    }
}
