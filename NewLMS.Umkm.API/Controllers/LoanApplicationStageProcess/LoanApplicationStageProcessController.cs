using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.LoanApplicationStageProcess.Commands;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationStageProcess
{
    [Authorize]
    public class LoanApplicationStageProcessController : BaseController
    {
        /// <summary>
        /// Appraisal Asignment to Surveyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-asignment/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprAsignmentProcess(LoanAppStageProcessApprAsignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal Surveyor to Approval
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-surveyor/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprSurveyorProcess(ProcessApprSurveyorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal Surveyor Back to Appraisal Asingment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-surveyor/back-to-ide")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprSurveyorBackToIDE(LoanAppStageBackApprSurveyorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal Approval to Analyst
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-approval/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprApprovalProcess(ProcessApprApprovalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal Approval Back To Surveyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-approval/back-to-surveyor")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprBackToSurveyor(BackToSurveyorApprApprovalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        #region Prescrening
        //Prescresning

        /// <summary>
        /// Process Prescrening Process To Survey
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> PrescreeningProcess(ProcessLoanApplicationPrescreening command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Prescreening Back to IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/back-to-ide")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> PrescreeningBackToIDE(BackToIDELoanApplicationPrescreeningCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Prescreening Not Process
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/not-process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> PrescreeningNotProcess(NotProcessLoanApplicationPrescreeningCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Prescreening Back To Slik Request
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/to-slik-request")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> PrescreeningBakcToSlikRequest(BackToSlikRequestLoanApplicationPrescreeningCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        //Survey
        /// <summary>
        /// Process Survey Process To Analisa
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("survey/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprSurveyProcess(ProcessLoanApplicationSurvey command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal Survey Back to IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("survey/back-to-ide")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> ApprSurveyBackToIDE(BackToIDESurveyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
