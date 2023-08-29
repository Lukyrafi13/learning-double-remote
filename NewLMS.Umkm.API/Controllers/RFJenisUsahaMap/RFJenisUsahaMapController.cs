using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Commands;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCompanyTypeMap
{
    public class RfCompanyTypeMapController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCompanyTypeMap
        /// </summary>
        /// <param name="mediator"></param>
        public RfCompanyTypeMapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCompanyTypeMap By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRfCompanyTypeMapByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfCompanyTypeMapResponseDto))]
        public async Task<IActionResult> GetRfCompanyTypeMapByCode(Guid Id)
        {
            var getSCOQuery = new RfCompanyTypeMapGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCompanyType By RfCompanyGroup KELOMPOK_CODE
        /// </summary>
        /// <param name="KELOMPOK_CODE"></param>
        /// <returns></returns>
        [HttpGet("jenis-by-kelompok/get/{KELOMPOK_CODE}", Name = "GetRfCompanyTypeByKelompokCode")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfCompanyTypeByKelompokResponse>))]
        public async Task<IActionResult> GetRfCompanyTypeByKelompokCode(string KELOMPOK_CODE)
        {
            var getSCOQuery = new RfCompanyTypeByKelompokCodeQuery { KELOMPOK_CODE = KELOMPOK_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCompanyTypeMap
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCompanyTypeMapList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCompanyTypeMapResponseDto>>))]
        public async Task<IActionResult> GetRfCompanyTypeMapList(RfCompanyTypeMapsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCompanyTypeMap
        /// </summary>
        /// <param name="postRfCompanyTypeMap"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCompanyTypeMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeMapResponseDto>))]
        public async Task<IActionResult> AddRfCompanyTypeMap(RfCompanyTypeMapPostCommand postRfCompanyTypeMap)
        {
            var result = await _mediator.Send(postRfCompanyTypeMap);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCompanyTypeMapByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCompanyTypeMap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRfCompanyTypeMap"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRfCompanyTypeMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeMapResponseDto>))]
        public async Task<IActionResult> EditRfCompanyTypeMap([FromRoute] Guid Id, [FromBody] RfCompanyTypeMapPutCommand putRfCompanyTypeMap)
        {
            putRfCompanyTypeMap.Id = Id;
            var result = await _mediator.Send(putRfCompanyTypeMap);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCompanyTypeMap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRfCompanyTypeMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCompanyTypeMap([FromRoute] Guid Id, [FromBody]RfCompanyTypeMapDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}