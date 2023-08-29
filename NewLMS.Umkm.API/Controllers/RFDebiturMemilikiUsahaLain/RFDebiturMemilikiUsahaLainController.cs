using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands;
using NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFDebiturMemilikiUsahaLain
{
    public class RFDebiturMemilikiUsahaLainController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFDebiturMemilikiUsahaLain
        /// </summary>
        /// <param name="mediator"></param>
        public RFDebiturMemilikiUsahaLainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFDebiturMemilikiUsahaLain By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFDebiturMemilikiUsahaLainById")]
        [Produces("application/json", "application/xml", Type = typeof(RFDebiturMemilikiUsahaLainResponseDto))]
        public async Task<IActionResult> GetRFDebiturMemilikiUsahaLainById(string StatusDebitur_Code)
        {
            var getGenderQuery = new RFDebiturMemilikiUsahaLainGetQuery { StatusDebitur_Code = StatusDebitur_Code };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFDebiturMemilikiUsahaLain By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFDebiturMemilikiUsahaLainList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>))]
        public async Task<IActionResult> GetRFDebiturMemilikiUsahaLainList(RFDebiturMemilikiUsahaLainsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFDebiturMemilikiUsahaLain
        /// </summary>
        /// <param name="postRFDebiturMemilikiUsahaLain"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFDebiturMemilikiUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>))]
        public async Task<IActionResult> AddRFDebiturMemilikiUsahaLain(RFDebiturMemilikiUsahaLainPostCommand postRFDebiturMemilikiUsahaLain)
        {
            var result = await _mediator.Send(postRFDebiturMemilikiUsahaLain);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFDebiturMemilikiUsahaLainById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFDebiturMemilikiUsahaLain
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFDebiturMemilikiUsahaLain"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFDebiturMemilikiUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>))]
        public async Task<IActionResult> EditRFDebiturMemilikiUsahaLain([FromRoute] string StatusDebitur_Code, [FromBody] RFDebiturMemilikiUsahaLainPutCommand putRFDebiturMemilikiUsahaLain)
        {
            putRFDebiturMemilikiUsahaLain.StatusDebitur_Code = StatusDebitur_Code;
            var result = await _mediator.Send(putRFDebiturMemilikiUsahaLain);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFDebiturMemilikiUsahaLain
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFDebiturMemilikiUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFDebiturMemilikiUsahaLain([FromRoute] string StatusDebitur_Code, [FromBody] RFDebiturMemilikiUsahaLainDeleteCommand deleteCommand)
        {
            deleteCommand.StatusDebitur_Code = StatusDebitur_Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}