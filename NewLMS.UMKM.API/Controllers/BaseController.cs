using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.Helper;
using Swashbuckle.AspNetCore.Annotations;

namespace NewLMS.Umkm.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public IActionResult ReturnFormattedResponse<T>(ServiceResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return StatusCode(response.StatusCode, response.Errors);
        }
    }
}