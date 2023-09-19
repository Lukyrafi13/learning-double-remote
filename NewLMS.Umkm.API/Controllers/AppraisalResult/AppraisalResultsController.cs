/*using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.AppraisalResults;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.AppraisalResult.Commands;
using NewLMS.Umkm.MediatR.Features.AppraisalResult.Queries;
using System;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.AppraisalResult
{
    /// <summary>
    /// Menyediakan fungsionalitas data untuk menu "Hasil Appraisal"
    /// </summary>
    public class AppraisalResultsController : BaseController
    {
        /// <summary>
        /// Get Hasil Appraisal By LoanApplicationGuid
        /// </summary>
        /// <param name="LoanApplicationGuid"></param>
        /// <returns></returns>
        *//*[HttpGet("get/{LoanApplicationGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<AppraisalResultResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid LoanApplicationGuid)
        {
            return Ok(await Mediator.Send(new GetAppraisalResultQuery
            {
                LoanApplicationGuid = LoanApplicationGuid
            }));
        }*//*

        /// <summary>
        /// Insert dan Update Hasil Appraisal By LoanApplicationGuid
        /// </summary>
        /// <param name="LoanApplicationGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("post/{LoanApplicationGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromRoute] Guid LoanApplicationGuid, [FromBody] PostAppraisalResultCommand command)
        {
            command.LoanApplicationGuid = LoanApplicationGuid;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update Appraisal Status By AppraisalGuid
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("toggle-status")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ToggleStatus([FromBody] PostAppraisalToggleStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get Informasi Pengikat Agunan By CollateralBindingGuid
        /// </summary>
        /// <param name="CollateralBindingGuid"></param>
        /// <returns></returns>
        [HttpGet("get-collateral-bindings/{CollateralBindingGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<AppraisalResultCollateralBindingResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCollateralBinding([FromRoute] Guid CollateralBindingGuid)
        {
            return Ok(await Mediator.Send(new GetCollateralBindingQuery
            {
                CollateralBindingGuid = CollateralBindingGuid
            }));
        }

        /// <summary>
        /// Untuk Insert "collateralBindingGuid = null" dan Untuk Update "collateralBindingGuid = xxxx-xxxx-xxxx-xxxx" Informasi Pengikat Agunan By LoanApplicationGuid
        /// </summary>
        /// <param name="LoanApplicationGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("post-collateral-bindings/{LoanApplicationGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCollateralBinding([FromRoute] Guid LoanApplicationGuid, [FromBody] PostCollateralBindingCommand command)
        {
            command.LoanApplicationGuid = LoanApplicationGuid;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete Informasi Pengikat Agunan By CollateralBindingGuid
        /// </summary>
        /// <param name="CollateralBindingGuid"></param>
        /// <returns></returns>
        [HttpDelete("delete-collateral-bindings/{CollateralBindingGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCollateralBinding([FromRoute] Guid CollateralBindingGuid)
        {
            return Ok(await Mediator.Send(new DeleteCollateralBindingCommand
            {
                CollateralBindingGuid = CollateralBindingGuid
            }));
        }
    }
}
*/