using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.MediatR.Features.RfCompanyStatuses.Queries.GetFilterRfCompanyStatuses;
using NewLMS.UMKM.Data.Dto.RfCompanyStatuses;
using MediatR;
using NewLMS.UMKM.MediatR.Features.RfCompanyStatuses.Queries.GetByIdRfCompanyStatuses;

namespace NewLMS.UMKM.API.Controllers.RfCompanyStatus
{
    public class RfCompanyStatusController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCompanyType
        /// </summary>
        /// <param name="mediator"></param>
        public RfCompanyStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCompanyType By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{StatusCode}", Name = "GetRfCompanyStatusById")]
        [Produces("application/json", "application/xml", Type = typeof(RfCompanyStatusResponse))]
        public async Task<IActionResult> GetRfCompanyStatusById(string StatusCode)
        {
            var getGenderQuery = new RfCompanyStatusesGetByIdQuery { StatusCode = StatusCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }


        /// <summary>
        /// Get RfCompanyTypeStatus
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCompanyStatusList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCompanyStatusResponse>>))]
        public async Task<IActionResult> GetRfCompanyStatusList(RfCompanyStatusesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

    }
}
