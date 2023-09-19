using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NewLMS.Umkm.Data.Dto.LoanApplicationFacilities;
using NewLMS.Umkm.MediatR.Features.LoanApplicationFacilities.Queries;
using MediatR;
using NewLMS.Umkm.MediatR.Features.LoanApplicationFacilities.Commands;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationFacility
{
    public class LoanApplicationFacilityController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationFacilityResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(LoanApplicationFacilitiesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get LoanApplicationFacility By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationFacilityResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] LoanApplicationFacilitiesGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a LoanApplicationFacility
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(LoanApplicationFacilitiesPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update LoanApplicationFacility Data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] LoanApplicationFacilitiesPutCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete LoanApplicationFacility by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(LoanApplicationFacilitiesDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
