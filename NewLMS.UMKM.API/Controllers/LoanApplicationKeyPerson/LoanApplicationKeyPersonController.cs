
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.MediatR.Features.LoanApplicationKeyPersons.Queries;
using MediatR;
using NewLMS.Umkm.MediatR.Features.LoanApplicationKeyPersons.Commands;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationKeyPerson
{
    public class LoanApplicationKeyPersonController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationKeyPersonResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(LoanApplicationKeyPersonGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get LoanApplicationKeyPerson By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationKeyPersonResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] LoanApplicationKeyPersonGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a LoanApplicationKeyPerson
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(LoanApplicationKeyPersonPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update LoanApplicationKeyPerson Data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="DebtorFinanceId"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] LoanApplicationKeyPersonPutCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete LoanApplicationKeyPerson by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(LoanApplicationKeyPersonDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
