using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.PersiapanAkadAsuransis.Commands;
using NewLMS.Umkm.MediatR.Features.PersiapanAkadAsuransis.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.PersiapanAkadAsuransi
{
    public class PersiapanAkadAsuransiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// PersiapanAkadAsuransi
        /// </summary>
        /// <param name="mediator"></param>
        public PersiapanAkadAsuransiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get PersiapanAkadAsuransi By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetPersiapanAkadAsuransiByCode")]
        [Produces("application/json", "application/xml", Type = typeof(Unit))]
        public async Task<IActionResult> GetPersiapanAkadAsuransiByCode(Guid Id)
        {
            var getSCOQuery = new PersiapanAkadAsuransiGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get PersiapanAkadAsuransi
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetPersiapanAkadAsuransiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<Unit>>))]
        public async Task<IActionResult> GetPersiapanAkadAsuransiList(PersiapanAkadAsuransisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New PersiapanAkadAsuransi
        /// </summary>
        /// <param name="postPersiapanAkadAsuransi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddPersiapanAkadAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> AddPersiapanAkadAsuransi(PersiapanAkadAsuransiPostCommand postPersiapanAkadAsuransi)
        {
            var result = await _mediator.Send(postPersiapanAkadAsuransi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetPersiapanAkadAsuransiByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit PersiapanAkadAsuransi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putPersiapanAkadAsuransi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditPersiapanAkadAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> EditPersiapanAkadAsuransi([FromRoute] Guid Id, [FromBody] PersiapanAkadAsuransiPutCommand putPersiapanAkadAsuransi)
        {
            putPersiapanAkadAsuransi.Id = Id;
            var result = await _mediator.Send(putPersiapanAkadAsuransi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete PersiapanAkadAsuransi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeletePersiapanAkadAsuransi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeletePersiapanAkadAsuransi([FromRoute] Guid Id, [FromBody]PersiapanAkadAsuransiDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}