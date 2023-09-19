using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Wilayah.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.WilayahController
{
    public class WilayahController : BaseController
    {
        [HttpGet("get-provinces")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProvinces()
        {
            return Ok(await Mediator.Send(new GetWilayahProvinceQuery()));
        }
        [HttpGet("get-districts/{ParentCode}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDistricts([FromRoute] string ParentCode)
        {
            return Ok(await Mediator.Send(new GetWilayahDistrictQuery
            {
                ParentCode = ParentCode
            }));
        }
        [HttpGet("get-regencies/{ParentCode}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRegencies([FromRoute] string ParentCode)
        {
            return Ok(await Mediator.Send(new GetWilayahRegencyQuery
            {
                ParentCode = ParentCode
            }));
        }
        [HttpGet("get-regencies")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRegencyCity([FromRoute] string ParentCode)
        {
            return Ok(await Mediator.Send(new GetWilayahRegencyQuery
            {
                ParentCode = ParentCode
            }));
        }
        [HttpGet("get")]
        [ProducesResponseType(type: typeof(ServiceResponse<IEnumerable<SimpleResponse<string>>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetWilayahRegencyCityQuery()));
        }

        [HttpGet("get-villages/{ParentCode}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVillages([FromRoute] string ParentCode)
        {
            return Ok(await Mediator.Send(new GetWilayahVillageQuery
            {
                ParentCode = ParentCode
            }));
        }
    }
}
