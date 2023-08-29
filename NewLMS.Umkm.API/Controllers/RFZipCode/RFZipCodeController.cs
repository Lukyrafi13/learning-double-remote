using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfZipcodes.Commands;
using NewLMS.UMKM.MediatR.Features.RfZipcodes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using Microsoft.AspNetCore.Http;
using Hangfire;

namespace NewLMS.UMKM.API.Controllers.RfZipCode
{
    public class RfZipCodeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfZipCode
        /// </summary>
        /// <param name="mediator"></param>
        public RfZipCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfZipCode By ZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ZipCode}", Name = "GetRfZipCodeByZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfZipCodeResponse))]
        public async Task<IActionResult> GetRfZipCodeByZipCode(string ZipCode)
        {
            var getStatusTargetQuery = new RfZipCodesGetByIdQuery { ZipCode = ZipCode };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfZipCode By ZipCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfZipCodeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfZipCodeResponse>>))]
        public async Task<IActionResult> GetRfZipCodeList(RfZipCodeGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfZipCode
        /// </summary>
        /// <param name="postRfZipCode"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfZipCodeResponse>))]
        public async Task<IActionResult> AddRfZipCode(RfZipCodePostCommand postRfZipCode)
        {
            var result = await _mediator.Send(postRfZipCode);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfZipCodeByZipCode", new { ZipCode = result.Data.ZipCode }, result.Data);
        }

        /// <summary>
        /// Post Update RfZipCode JSON
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
        /// Put Edit RfZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="putRfZipCode"></param>
        /// <returns></returns>
        [HttpPut("put/{ZipCode}", Name = "EditRfZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfZipCodeResponse>))]
        public async Task<IActionResult> EditRfZipCode([FromRoute] string ZipCode, [FromBody] RfZipCodePutCommand putRfZipCode)
        {
            putRfZipCode.ZipCode = ZipCode;
            var result = await _mediator.Send(putRfZipCode);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfZipCode
        /// </summary>
        /// <param name="ZipCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ZipCode}", Name = "DeleteRfZipCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfZipCode([FromRoute] string ZipCode, [FromBody]RfZipCodeDeleteCommand deleteCommand)
        {
            deleteCommand.ZipCode = ZipCode;
            return Ok(await _mediator.Send(deleteCommand));
        }

        /// <summary>
        /// Get All Provinces
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/provinces", Name = "GetProvinces")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
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
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
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
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
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
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeKabKotaGroupedResponse>))]
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
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
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
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
        public async Task<IActionResult> getKelurahans(string kodeKecamatan)
        {
            var getKelurahans = new GetKelurahanByKecamatanQueryZipCode{KodeKecamatan = kodeKecamatan};
            var result = await _mediator.Send(getKelurahans);
            return ReturnFormattedResponse(result);
        }
    }
}