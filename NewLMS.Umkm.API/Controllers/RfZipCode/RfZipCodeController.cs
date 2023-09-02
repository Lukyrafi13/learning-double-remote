using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands;
using NewLMS.UMKM.MediatR.Features.RfZipCodes.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfZipCode
{
    public class RfZipCodeController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfZipCodeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfZipCodeGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfZipCodeResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfZipCodesGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RfZipCodePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] RfZipCodePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(RfZipCodeDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
