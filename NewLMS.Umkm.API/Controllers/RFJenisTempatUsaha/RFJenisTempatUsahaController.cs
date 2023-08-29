using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Commands;
using NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFJenisTempatUsaha
{
    public class RFJenisTempatUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisTempatUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisTempatUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisTempatUsaha By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisTempatUsahaById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisTempatUsahaResponseDto))]
        public async Task<IActionResult> GetRFJenisTempatUsahaById(string ANL_CODE)
        {
            var getGenderQuery = new RFJenisTempatUsahaGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisTempatUsaha
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisTempatUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisTempatUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFJenisTempatUsahaList(RFJenisTempatUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisTempatUsaha
        /// </summary>
        /// <param name="postRFJenisTempatUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisTempatUsahaResponseDto>))]
        public async Task<IActionResult> AddRFJenisTempatUsaha(RFJenisTempatUsahaPostCommand postRFJenisTempatUsaha)
        {
            var result = await _mediator.Send(postRFJenisTempatUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisTempatUsahaById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisTempatUsaha
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJenisTempatUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisTempatUsahaResponseDto>))]
        public async Task<IActionResult> EditRFJenisTempatUsaha([FromRoute] string ANL_CODE, [FromBody] RFJenisTempatUsahaPutCommand putRFJenisTempatUsaha)
        {
            putRFJenisTempatUsaha.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFJenisTempatUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisTempatUsaha
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisTempatUsaha([FromRoute] string ANL_CODE, [FromBody] RFJenisTempatUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}