using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands;
using NewLMS.Umkm.MediatR.Features.RFZipcodes.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using Microsoft.AspNetCore.Http;
using Hangfire;

namespace NewLMS.Umkm.API.Controllers.RFZipCode
{
    public class RFZipCodeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFZipCode
        /// </summary>
        /// <param name="mediator"></param>
        public RFZipCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFZipCode By ZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ZipCode}", Name = "GetRFZipCodeByZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFZipCodeResponse))]
        public async Task<IActionResult> GetRFZipCodeByZipCode(string ZipCode)
        {
            var getStatusTargetQuery = new RFZipCodesGetByIdQuery { ZipCode = ZipCode };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFZipCode By ZipCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFZipCodeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFZipCodeResponse>>))]
        public async Task<IActionResult> GetRFZipCodeList(RFZipCodeGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFZipCode
        /// </summary>
        /// <param name="postRFZipCode"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFZipCodeResponse>))]
        public async Task<IActionResult> AddRFZipCode(RFZipCodePostCommand postRFZipCode)
        {
            var result = await _mediator.Send(postRFZipCode);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFZipCodeByZipCode", new { ZipCode = result.Data.ZipCode }, result.Data);
        }

        /// <summary>
        /// Post Update RFZipCode JSON
        /// </summary>
        /// <param name="JSONFile"></param>
        /// <returns></returns>
        [HttpPost("upload/json/", Name = "UploadJSONZipCode")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public IActionResult UploadJSONZipCode(IFormFile JSONFile)
        {
            BackgroundJob.Enqueue<RfZipCodesUploadJSON>(x => x.UploadJSON(JSONFile));
            return Ok();
        }

        /// <summary>
        /// Put Edit RFZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="putRFZipCode"></param>
        /// <returns></returns>
        [HttpPut("put/{ZipCode}", Name = "EditRFZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFZipCodeResponse>))]
        public async Task<IActionResult> EditRFZipCode([FromRoute] string ZipCode, [FromBody] RFZipCodePutCommand putRFZipCode)
        {
            putRFZipCode.ZipCode = ZipCode;
            var result = await _mediator.Send(putRFZipCode);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ZipCode}", Name = "DeleteRFZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFZipCode([FromRoute] string ZipCode, [FromBody]RFZipCodeDeleteCommand deleteCommand)
        {
            deleteCommand.ZipCode = ZipCode;
            return Ok(await _mediator.Send(deleteCommand));
        }

        /// <summary>
        /// Get All Provinces
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/provinces", Name = "GetProvinces")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeResponse>))]
        public async Task<IActionResult> GetProvinces()
        {
            var getProvinces = new GetProvinsiZipCode{};
            var result = await _mediator.Send(getProvinces);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Kabupaten by Province
        /// </summary>
        /// <param name="kodeProvinsi"></param>
        /// <returns></returns>
        [HttpGet("get/kabupatens", Name = "GetKabupatens")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeResponse>))]
        public async Task<IActionResult> GetKabupatens(string kodeProvinsi)
        {
            var getKabupatens = new GetKabKotaByProvinsiQueryZipCode{KodeProvinsi = kodeProvinsi};
            var result = await _mediator.Send(getKabupatens);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Kabupaten by Zip Code
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <returns></returns>
        [HttpGet("get/kabupatens-by-code", Name = "GetKabupatensByCode")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeResponse>))]
        public async Task<IActionResult> GetKabupatensByCode(string ZipCode)
        {
            var getKabupatensByCode = new GetKabKotaByZipCode{ZipCode = ZipCode};
            var result = await _mediator.Send(getKabupatensByCode);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Kabupaten List
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/kabupaten-list", Name = "GetKabupatenList")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeKabKotaGroupedResponse>))]
        public async Task<IActionResult> GetKabupatenList()
        {
            var getKabupatenList = new GetKabKotaGroupedQuery{};
            var result = await _mediator.Send(getKabupatenList);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Kecamatan by Kabupaten
        /// </summary>
        /// <param name="kodeKabKota"></param>
        /// <returns></returns>
        [HttpGet("get/kecamatans", Name = "GetKecamatans")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeResponse>))]
        public async Task<IActionResult> GetKecamatans(string kodeKabKota)
        {
            var getKecamatans = new GetKecamatanByKabKotaQueryZipCode{KodeKabKota = kodeKabKota};
            var result = await _mediator.Send(getKecamatans);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Keluarahan by Kecamatan
        /// </summary>
        /// <param name="kodeKecamatan"></param>
        /// <returns></returns>
        [HttpGet("get/kelurahans", Name = "getKelurahans")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFZipCodeResponse>))]
        public async Task<IActionResult> getKelurahans(string kodeKecamatan)
        {
            var getKelurahans = new GetKelurahanByKecamatanQueryZipCode{KodeKecamatan = kodeKecamatan};
            var result = await _mediator.Send(getKelurahans);
            return ReturnFormattedResponse(result);
        }
    }
}