/*using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Dto.CollateralInsurances;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.CollateralInsurances.Commands;
using NewLMS.Umkm.MediatR.Features.CollateralInsurances.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.CollateralInsurance
{
    /// <summary>
    /// Menyediakan fungsionalitas data untuk menu "Appraisal Surveyor -> Asuransi Agunan"
    /// </summary>
    public class CollateralInsuranceController : BaseController
    {
        /// <summary>
        /// Get Asuransi Agunan by DebtorCollateralGuid
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>      
        [HttpGet("get/{LoanApplicationCollateralGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<CollateralInsuranceResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> Get([FromRoute] GetByDebtorCollateralQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Insert dan Update Asuransi Agunan by DebtorCollateralGuid
        /// </summary>
        /// <param name="LoanApplicationCollateralGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>  
        [HttpPost("post/{LoanApplicationCollateralGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromRoute] Guid LoanApplicationCollateralGuid, [FromBody] CollateralInsurancePostCommand command)
        {
            command.LoanApplicationCollateralGuid = LoanApplicationCollateralGuid;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get Nama Asuransi by Kode Broker
        /// </summary>
        /// <param name="BrokerGuid"></param>
        /// <returns></returns>  
        [HttpGet("get-insurance-names/{BrokerGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<List<SimpleResponse<string>>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInsuranceNames([FromRoute] Guid BrokerGuid)
        {
            return Ok(await Mediator.Send(new GetInsuranceByBrokerQuery
            {
                CompanyType = BrokerGuid
            }));
        }

        /// <summary>
        /// Get Coverage by Kode Asuransi
        /// </summary>
        /// <param name="InsuranceId"></param>
        /// <returns></returns>
        [HttpGet("get-coverages/{InsuranceId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<List<SimpleResponse<string>>>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetCoverages([FromRoute] string InsuranceId)
        {
            return Ok(await Mediator.Send(new GetCoverageByInsuranceQuery
            {
                CompanyId = InsuranceId
            }));
        }

        /// <summary>
        /// Insert data Bunga Asuransi
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("post-insurance-rates")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostInsuranceRates([FromBody] PostInsuranceRateMappingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get data Bunga Asuransi
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-insurance-rates")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<InsuranceRateMappingResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInsuranceRates(GetInsuranceRatesByCoverageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // [HttpPut("{CollateralInsuranceGuid}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<CollateralInsuranceResponse>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> Update([FromRoute] Guid CollateralInsuranceGuid, [FromBody] CollateralInsurancePutCommand command)
        // {
        //     command.CollateralInsuranceGuid = CollateralInsuranceGuid;
        //     return Ok(await Mediator.Send(command));
        // }

        // [HttpDelete("{CollateralInsuranceGuid}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<CollateralInsuranceResponse>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> Delete([FromRoute] CollateralInsuranceDeleteCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }
    }
}
*/