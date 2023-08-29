using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Commands;
using NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSANDIBI
{
    public class RFSANDIBIController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSANDIBI
        /// </summary>
        /// <param name="mediator"></param>
        public RFSANDIBIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSANDIBI By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFSANDIBIById")]
        [Produces("application/json", "application/xml", Type = typeof(RFSANDIBIResponseDto))]
        public async Task<IActionResult> GetRFSANDIBIById(string BI_CODE)
        {
            var getGenderQuery = new RFSANDIBIGetQuery { BI_CODE = BI_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSANDIBI
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSANDIBIList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSANDIBIResponseDto>>))]
        public async Task<IActionResult> GetRFSANDIBIList(RFSANDIBISGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSANDIBI
        /// </summary>
        /// <param name="postRFSANDIBI"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSANDIBI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSANDIBIResponseDto>))]
        public async Task<IActionResult> AddRFSANDIBI(RFSANDIBIPostCommand postRFSANDIBI)
        {
            var result = await _mediator.Send(postRFSANDIBI);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSANDIBIById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSANDIBI
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFSANDIBI"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFSANDIBI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSANDIBIResponseDto>))]
        public async Task<IActionResult> EditRFSANDIBI([FromRoute] string BI_CODE, [FromBody] RFSANDIBIPutCommand putRFSANDIBI)
        {
            putRFSANDIBI.BI_CODE = BI_CODE;
            var result = await _mediator.Send(putRFSANDIBI);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSANDIBI
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFSANDIBI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSANDIBI([FromRoute] string BI_CODE, [FromBody] RFSANDIBIDeleteCommand deleteCommand)
        {
            deleteCommand.BI_CODE = BI_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}