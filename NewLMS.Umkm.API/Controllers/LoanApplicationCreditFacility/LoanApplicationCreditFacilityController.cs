using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Commands;
using NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.LoanApplicationCreditFacility
{
    public class LoanApplicationCreditFacilityController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// LoanApplicationCreditFacility
        /// </summary>
        /// <param name="mediator"></param>
        public LoanApplicationCreditFacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get LoanApplicationCreditFacility By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetLoanApplicationCreditFacilityByCode")]
        [Produces("application/json", "application/xml", Type = typeof(Unit))]
        public async Task<IActionResult> GetLoanApplicationCreditFacilityByCode(Guid Id)
        {
            var getSCOQuery = new LoanApplicationCreditFacilityGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get LoanApplicationCreditFacility
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetLoanApplicationCreditFacilityList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<Unit>>))]
        public async Task<IActionResult> GetLoanApplicationCreditFacilityList(LoanApplicationCreditFacilitiesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New LoanApplicationCreditFacility
        /// </summary>
        /// <param name="postLoanApplicationCreditFacility"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddLoanApplicationCreditFacility")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> AddLoanApplicationCreditFacility(LoanApplicationCreditFacilityPostCommand postLoanApplicationCreditFacility)
        {
            var result = await _mediator.Send(postLoanApplicationCreditFacility);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetLoanApplicationCreditFacilityByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit LoanApplicationCreditFacility
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putLoanApplicationCreditFacility"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditLoanApplicationCreditFacility")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> EditLoanApplicationCreditFacility([FromRoute] Guid Id, [FromBody] LoanApplicationCreditFacilityPutCommand putLoanApplicationCreditFacility)
        {
            putLoanApplicationCreditFacility.Id = Id;
            var result = await _mediator.Send(putLoanApplicationCreditFacility);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete LoanApplicationCreditFacility
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteLoanApplicationCreditFacility")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteLoanApplicationCreditFacility([FromRoute] Guid Id, [FromBody]LoanApplicationCreditFacilityDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}