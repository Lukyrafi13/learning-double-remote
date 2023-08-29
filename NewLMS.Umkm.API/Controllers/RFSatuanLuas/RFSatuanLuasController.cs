using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSatuanLuass;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSatuanLuass.Commands;
using NewLMS.Umkm.MediatR.Features.RFSatuanLuass.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSatuanLuas
{
    public class RFSatuanLuasController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSatuanLuas
        /// </summary>
        /// <param name="mediator"></param>
        public RFSatuanLuasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSatuanLuas By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFSatuanLuasById")]
        [Produces("application/json", "application/xml", Type = typeof(RFSatuanLuasResponseDto))]
        public async Task<IActionResult> GetRFSatuanLuasById(string SatuanLuas_Id)
        {
            var getGenderQuery = new RFSatuanLuasGetQuery { SatuanLuas_Id = SatuanLuas_Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSatuanLuas
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSatuanLuasList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSatuanLuasResponseDto>>))]
        public async Task<IActionResult> GetRFSatuanLuasList(RFSatuanLuassGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSatuanLuas
        /// </summary>
        /// <param name="postRFSatuanLuas"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSatuanLuas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSatuanLuasResponseDto>))]
        public async Task<IActionResult> AddRFSatuanLuas(RFSatuanLuasPostCommand postRFSatuanLuas)
        {
            var result = await _mediator.Send(postRFSatuanLuas);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSatuanLuasById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSatuanLuas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFSatuanLuas"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFSatuanLuas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSatuanLuasResponseDto>))]
        public async Task<IActionResult> EditRFSatuanLuas([FromRoute] string SatuanLuas_Id, [FromBody] RFSatuanLuasPutCommand putRFSatuanLuas)
        {
            putRFSatuanLuas.SatuanLuas_Id = SatuanLuas_Id;
            var result = await _mediator.Send(putRFSatuanLuas);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSatuanLuas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFSatuanLuas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSatuanLuas([FromRoute] string SatuanLuas_Id, [FromBody] RFSatuanLuasDeleteCommand deleteCommand)
        {
            deleteCommand.SatuanLuas_Id = SatuanLuas_Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}