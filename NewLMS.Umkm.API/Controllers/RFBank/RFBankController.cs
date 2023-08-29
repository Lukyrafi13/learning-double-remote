using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFBanks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFBanks.Commands;
using NewLMS.UMKM.MediatR.Features.RFBanks.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFBank
{
    public class RFBankController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFBank
        /// </summary>
        /// <param name="mediator"></param>
        public RFBankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFBank By BankId
        /// </summary>
        /// <param name="BankId"></param>
        /// <returns></returns>
        [HttpGet("get/{BankId}", Name = "GetRFBankByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFBankResponseDto))]
        public async Task<IActionResult> GetRFBankByCode(string BankId)
        {
            var getSCOQuery = new RFBankGetQuery { BankId = BankId };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFBank
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFBankList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFBankResponseDto>>))]
        public async Task<IActionResult> GetRFBankList(RFBanksGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFBank
        /// </summary>
        /// <param name="postRFBank"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFBank")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBankResponseDto>))]
        public async Task<IActionResult> AddRFBank(RFBankPostCommand postRFBank)
        {
            var result = await _mediator.Send(postRFBank);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFBankByCode", new { BankId = result.Data.BankId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFBank
        /// </summary>
        /// <param name="BankId"></param>
        /// <param name="putRFBank"></param>
        /// <returns></returns>
        [HttpPut("put/{BankId}", Name = "EditRFBank")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBankResponseDto>))]
        public async Task<IActionResult> EditRFBank([FromRoute] string BankId, [FromBody] RFBankPutCommand putRFBank)
        {
            putRFBank.BankId = BankId;
            var result = await _mediator.Send(putRFBank);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFBank
        /// </summary>
        /// <param name="BankId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{BankId}", Name = "DeleteRFBank")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFBank([FromRoute] string BankId, [FromBody]RFBankDeleteCommand deleteCommand)
        {
            deleteCommand.BankId = BankId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}