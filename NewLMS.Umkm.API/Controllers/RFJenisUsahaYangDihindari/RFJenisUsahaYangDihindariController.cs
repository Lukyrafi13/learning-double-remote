using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Commands;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCompanyTypeYangDihindari
{
    public class RfCompanyTypeYangDihindariController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCompanyTypeYangDihindari
        /// </summary>
        /// <param name="mediator"></param>
        public RfCompanyTypeYangDihindariController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCompanyTypeYangDihindari By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRfCompanyTypeYangDihindariById")]
        [Produces("application/json", "application/xml", Type = typeof(RfCompanyTypeYangDihindariResponseDto))]
        public async Task<IActionResult> GetRfCompanyTypeYangDihindariById(string StatusJenisUsaha_Code)
        {
            var getGenderQuery = new RfCompanyTypeYangDihindariGetQuery { StatusJenisUsaha_Code = StatusJenisUsaha_Code };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCompanyTypeYangDihindari
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCompanyTypeYangDihindariList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>))]
        public async Task<IActionResult> GetRfCompanyTypeYangDihindariList(RfCompanyTypeYangDihindarisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCompanyTypeYangDihindari
        /// </summary>
        /// <param name="postRfCompanyTypeYangDihindari"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCompanyTypeYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeYangDihindariResponseDto>))]
        public async Task<IActionResult> AddRfCompanyTypeYangDihindari(RfCompanyTypeYangDihindariPostCommand postRfCompanyTypeYangDihindari)
        {
            var result = await _mediator.Send(postRfCompanyTypeYangDihindari);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCompanyTypeYangDihindariById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCompanyTypeYangDihindari
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRfCompanyTypeYangDihindari"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRfCompanyTypeYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeYangDihindariResponseDto>))]
        public async Task<IActionResult> EditRfCompanyTypeYangDihindari([FromRoute] string StatusJenisUsaha_Code, [FromBody] RfCompanyTypeYangDihindariPutCommand putRfCompanyTypeYangDihindari)
        {
            putRfCompanyTypeYangDihindari.StatusJenisUsaha_Code = StatusJenisUsaha_Code;
            var result = await _mediator.Send(putRfCompanyTypeYangDihindari);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCompanyTypeYangDihindari
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRfCompanyTypeYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCompanyTypeYangDihindari([FromRoute] string StatusJenisUsaha_Code, [FromBody] RfCompanyTypeYangDihindariDeleteCommand deleteCommand)
        {
            deleteCommand.StatusJenisUsaha_Code = StatusJenisUsaha_Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}