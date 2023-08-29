using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.ArusKasMasuks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.ArusKasMasuks.Commands;
using NewLMS.Umkm.MediatR.Features.ArusKasMasuks.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.ArusKasMasuk
{
    public class ArusKasMasukController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// ArusKasMasuk
        /// </summary>
        /// <param name="mediator"></param>
        public ArusKasMasukController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get ArusKasMasuk By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetArusKasMasukById")]
        [Produces("application/json", "application/xml", Type = typeof(ArusKasMasukResponseDto))]
        public async Task<IActionResult> GetArusKasMasukById(Guid Id)
        {
            var getGenderQuery = new ArusKasMasukGetQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get ArusKasMasuk
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetArusKasMasukList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ArusKasMasukResponseDto>>))]
        public async Task<IActionResult> GetArusKasMasukList(ArusKasMasuksGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New ArusKasMasuk
        /// </summary>
        /// <param name="postArusKasMasuk"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddArusKasMasuk")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ArusKasMasukResponseDto>))]
        public async Task<IActionResult> AddArusKasMasuk(ArusKasMasukPostCommand postArusKasMasuk)
        {
            var result = await _mediator.Send(postArusKasMasuk);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetArusKasMasukById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit ArusKasMasuk
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putArusKasMasuk"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditArusKasMasuk")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ArusKasMasukResponseDto>))]
        public async Task<IActionResult> EditArusKasMasuk([FromRoute] Guid Id, [FromBody] ArusKasMasukPutCommand putArusKasMasuk)
        {
            putArusKasMasuk.Id = Id;
            var result = await _mediator.Send(putArusKasMasuk);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete ArusKasMasuk
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteArusKasMasuk")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteArusKasMasuk([FromRoute] Guid Id, [FromBody] ArusKasMasukDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}