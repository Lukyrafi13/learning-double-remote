using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Commands;
using NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.SIKPResponseData
{
    public class SIKPResponseDataController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SIKPResponseData
        /// </summary>
        /// <param name="mediator"></param>
        public SIKPResponseDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SIKPResponseData By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSIKPResponseDataByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SIKPResponseDataResponseDto))]
        public async Task<IActionResult> GetSIKPResponseDataByCode(Guid Id)
        {
            var getSCOQuery = new SIKPResponseDataGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SIKPResponseData
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSIKPResponseDataList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SIKPResponseDataResponseDto>>))]
        public async Task<IActionResult> GetSIKPResponseDataList(SIKPResponseDatasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SIKPResponseData
        /// </summary>
        /// <param name="postSIKPResponseData"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSIKPResponseData")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPResponseDataResponseDto>))]
        public async Task<IActionResult> AddSIKPResponseData(SIKPResponseDataPostCommand postSIKPResponseData)
        {
            var result = await _mediator.Send(postSIKPResponseData);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSIKPResponseDataByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SIKPResponseData
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSIKPResponseData"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSIKPResponseData")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPResponseDataResponseDto>))]
        public async Task<IActionResult> EditSIKPResponseData([FromRoute] Guid Id, [FromBody] SIKPResponseDataPutCommand putSIKPResponseData)
        {
            putSIKPResponseData.Id = Id;
            var result = await _mediator.Send(putSIKPResponseData);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SIKPResponseData
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSIKPResponseData")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSIKPResponseData([FromRoute] Guid Id, [FromBody]SIKPResponseDataDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}