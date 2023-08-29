using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisUsaha
{
    public class RFJenisUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisUsaha By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisUsahaById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisUsahaResponseDto))]
        public async Task<IActionResult> GetRFJenisUsahaById(string ANL_CODE)
        {
            var getGenderQuery = new RFJenisUsahaGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisUsaha
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFJenisUsahaList(RFJenisUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisUsaha
        /// </summary>
        /// <param name="postRFJenisUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaResponseDto>))]
        public async Task<IActionResult> AddRFJenisUsaha(RFJenisUsahaPostCommand postRFJenisUsaha)
        {
            var result = await _mediator.Send(postRFJenisUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisUsahaById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisUsaha
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJenisUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaResponseDto>))]
        public async Task<IActionResult> EditRFJenisUsaha([FromRoute] string ANL_CODE, [FromBody] RFJenisUsahaPutCommand putRFJenisUsaha)
        {
            putRFJenisUsaha.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFJenisUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisUsaha
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisUsaha([FromRoute] string ANL_CODE, [FromBody] RFJenisUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}