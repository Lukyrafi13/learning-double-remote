using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFPengikatanKredits;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RFPengikatanKredits.Queries;
using NewLMS.UMKM.MediatR.Features.RFPengikatanKredits.Commands;

namespace NewLMS.UMKM.API.Controllers.RFPengikatanKredit
{
    public class RFPengikatanKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFPengikatanKredit
        /// </summary>
        /// <param name="mediator"></param>
        public RFPengikatanKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFPengikatanKredit By PK_CODE
        /// </summary>
        /// <param name="PK_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{PK_CODE}", Name = "GetRFPengikatanKreditBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFPengikatanKreditResponseDto))]
        public async Task<IActionResult> GetRFPengikatanKreditBy(string PK_CODE)
        {
            var getGenderQuery = new RFPengikatanKreditGetQuery { PK_CODE = PK_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFPengikatanKredit By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFPengikatanKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFPengikatanKreditResponseDto>>))]
        public async Task<IActionResult> GetRFPengikatanKreditList(RFPengikatanKreditGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFPengikatanKredit
        /// </summary>
        /// <param name="postRFPengikatanKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFPengikatanKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPengikatanKreditResponseDto>))]
        public async Task<IActionResult> AddRFPengikatanKredit(RFPengikatanKreditPostCommand postRFPengikatanKredit)
        {
            var result = await _mediator.Send(postRFPengikatanKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFPengikatanKreditByPK_CODE", new { id = result.Data.PK_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFPengikatanKredit
        /// </summary>
        /// <param name="PK_CODE"></param>
        /// <param name="putRFPengikatanKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{PK_CODE}", Name = "EditRFPengikatanKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPengikatanKreditResponseDto>))]
        public async Task<IActionResult> EditRFPengikatanKredit([FromRoute] string PK_CODE, [FromBody] RFPengikatanKreditPutCommand putRFPengikatanKredit)
        {
            putRFPengikatanKredit.PK_CODE = PK_CODE;
            var result = await _mediator.Send(putRFPengikatanKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFPengikatanKredit
        /// </summary>
        /// <param name="PK_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{PK_CODE}", Name = "DeleteRFPengikatanKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFPengikatanKredit([FromRoute] string PK_CODE, [FromBody] RFPengikatanKreditDeleteCommand deleteCommand)
        {
            deleteCommand.PK_CODE = PK_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}