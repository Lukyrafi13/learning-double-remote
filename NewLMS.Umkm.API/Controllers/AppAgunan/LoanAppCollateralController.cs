using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using Microsoft.AspNetCore.Http;
using NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Queries;
using NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Commands;

namespace NewLMS.UMKM.API.Controllers.AppAgunan
{
    public class LoanAppCollateralController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<AppAgunanResponseDto>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(LoanAppCollateralGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get Other Finance By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] LoanAppColateralGetQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a Collateral
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(LoanAppCollateralPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update Collateral Data
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] LoanAppCollateralPutCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete Collateral by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(LoanAppCollateralDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}