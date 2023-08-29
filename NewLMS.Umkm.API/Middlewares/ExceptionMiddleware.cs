using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NewLMS.Umkm.Helper;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using NewLMS.Umkm.MediatR.Exceptions;
namespace NewLMS.Umkm.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
                                                                                                                                                             
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var responseModel = new ServiceResponse<string>() { };
                var message = error.InnerException != null ? error.InnerException.Message : error.Message;
                response.ContentType = "application/json";        
                responseModel.Success = false;
                responseModel.Message = message;
                switch (error)
                {
                    case ApiException e:
                        response.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = new System.Collections.Generic.List<string> { error.Message };
                        _logger.LogError(message);
                        break;
                    case NewLMS.Umkm.MediatR.Exceptions.ValidationException e:
                        response.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        _logger.LogError(message + string.Format("({0})", JsonConvert.SerializeObject(e.Errors)));
                        break;
                    case ForbiddenException e:
                        response.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        responseModel.StatusCode = (int)HttpStatusCode.Forbidden;
                        responseModel.Errors = new System.Collections.Generic.List<string> { error.Message };
                        _logger.LogError(message);
                        break;
                    case NotFoundException e:
                        response.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Errors = new System.Collections.Generic.List<string> { error.Message };
                        _logger.LogError(message);
                        break;
                    default:
                        //unhandled error
                        response.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = new System.Collections.Generic.List<string> { error.Message };
                        _logger.LogError(message);
                        break;
                }
                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

