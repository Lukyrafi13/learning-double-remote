using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisAsuransis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisAsuransis.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisAsuransis.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisAsuransi
{
    public class RFJenisAsuransiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisAsuransi
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisAsuransiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisAsuransi By Id
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisAsuransiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisAsuransiResponseDto))]
        public async Task<IActionResult> GetRFJenisAsuransiById(string JenisCode)
        {
            var getGenderQuery = new RFJenisAsuransiGetQuery { JenisCode = JenisCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisAsuransi
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisAsuransiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisAsuransiResponseDto>>))]
        public async Task<IActionResult> GetRFJenisAsuransiList(RFJenisAsuransisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisAsuransi
        /// </summary>
        /// <param name="postRFJenisAsuransi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisAsuransiResponseDto>))]
        public async Task<IActionResult> AddRFJenisAsuransi(RFJenisAsuransiPostCommand postRFJenisAsuransi)
        {
            var result = await _mediator.Send(postRFJenisAsuransi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisAsuransiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisAsuransi
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <param name="putRFJenisAsuransi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisAsuransiResponseDto>))]
        public async Task<IActionResult> EditRFJenisAsuransi([FromRoute] string JenisCode, [FromBody] RFJenisAsuransiPutCommand putRFJenisAsuransi)
        {
            putRFJenisAsuransi.JenisCode = JenisCode;
            var result = await _mediator.Send(putRFJenisAsuransi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisAsuransi
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisAsuransi([FromRoute] string JenisCode, [FromBody] RFJenisAsuransiDeleteCommand deleteCommand)
        {
            deleteCommand.JenisCode = JenisCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}