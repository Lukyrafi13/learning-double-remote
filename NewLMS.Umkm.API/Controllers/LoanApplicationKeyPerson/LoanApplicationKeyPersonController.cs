using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Commands;
using NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.LoanApplicationKeyPerson
{
    public class LoanApplicationKeyPersonController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// LoanApplicationKeyPerson
        /// </summary>
        /// <param name="mediator"></param>
        public LoanApplicationKeyPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get LoanApplicationKeyPerson By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetLoanApplicationKeyPersonByCode")]
        [Produces("application/json", "application/xml", Type = typeof(LoanApplicationKeyPersonResponseDto))]
        public async Task<IActionResult> GetLoanApplicationKeyPersonByCode(Guid Id)
        {
            var getSCOQuery = new LoanApplicationKeyPersonGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get LoanApplicationKeyPerson
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetLoanApplicationKeyPersonList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<LoanApplicationKeyPersonResponseDto>>))]
        public async Task<IActionResult> GetLoanApplicationKeyPersonList(LoanApplicationKeyPersonsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New LoanApplicationKeyPerson
        /// </summary>
        /// <param name="postLoanApplicationKeyPerson"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddLoanApplicationKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<LoanApplicationKeyPersonResponseDto>))]
        public async Task<IActionResult> AddLoanApplicationKeyPerson(LoanApplicationKeyPersonPostCommand postLoanApplicationKeyPerson)
        {
            var result = await _mediator.Send(postLoanApplicationKeyPerson);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetLoanApplicationKeyPersonByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit LoanApplicationKeyPerson
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putLoanApplicationKeyPerson"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditLoanApplicationKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<LoanApplicationKeyPersonResponseDto>))]
        public async Task<IActionResult> EditLoanApplicationKeyPerson([FromRoute] Guid Id, [FromBody] LoanApplicationKeyPersonPutCommand putLoanApplicationKeyPerson)
        {
            putLoanApplicationKeyPerson.Id = Id;
            var result = await _mediator.Send(putLoanApplicationKeyPerson);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete LoanApplicationKeyPerson
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteLoanApplicationKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteLoanApplicationKeyPerson([FromRoute] Guid Id, [FromBody]LoanApplicationKeyPersonDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}