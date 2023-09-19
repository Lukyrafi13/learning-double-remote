using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands;
using NewLMS.Umkm.MediatR.Features.RfZipCodes.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfZipCode
{
    public class RfZipCodeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFZipCode
        /// </summary>
        /// <param name="mediator"></param>
        public RfZipCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfZipCodeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfZipCodeGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfZipCodeResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfZipCodesGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RfZipCodePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] RfZipCodePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(RfZipCodeDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// Get All Provinces
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/provinces", Name = "GetProvinces")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RfZipCodeResponse>))]
        public async Task<IActionResult> GetProvinces()
        {
            var getProvinces = new GetProvinsiZipCode { };
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
            var getKabupatens = new GetKabKotaByProvinsiQueryZipCode { KodeProvinsi = kodeProvinsi };
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
            var getKabupatensByCode = new GetKabKotaByZipCode { ZipCode = ZipCode };
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
            var getKabupatenList = new GetKabKotaGroupedQuery { };
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
            var getKecamatans = new GetKecamatanByKabKotaQueryZipCode { KodeKabKota = kodeKabKota };
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
            var getKelurahans = new GetKelurahanByKecamatanQueryZipCode { KodeKecamatan = kodeKecamatan };
            var result = await _mediator.Send(getKelurahans);
            return ReturnFormattedResponse(result);
        }
    }
}
