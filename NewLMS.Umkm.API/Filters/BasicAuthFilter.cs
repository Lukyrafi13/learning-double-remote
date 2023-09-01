using Microsoft.AspNetCore.Mvc.Filters;
using System;
using MediatR;
using NewLMS.UMKM.MediatR.Exceptions;
using NewLMS.UMKM.MediatR.Features.ThridParties.Queries.GetThridPartyByClientIdAndClientSecret;

namespace NewLMS.UMKM.API.Filters
{
    public class BasicAuthFilter : IAuthorizationFilter
    {
        private readonly string _realm;
        private readonly IMediator _mediator;
        public BasicAuthFilter(string realm, IMediator mediator)
        {
            _realm = realm;
            if (string.IsNullOrWhiteSpace(_realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
            }
            _mediator = mediator;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string clientId = context.HttpContext.Request.Headers["x-client-id"];
                string clientSecret = context.HttpContext.Request.Headers["x-client-secret"];
                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                    throw new BadRequestException("Client id atau Client secret tidak boleh kosong");
                var isExist = _mediator.Send(new GetThridPartyByClientIdAndClientSecretQuery
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                });
                if (isExist.Result)
                    return;
                else
                    throw new ApiException("Anda belum terdaftar sebagai thrid party aplikasi new lms silahkan hubungi admin");
            }
            catch (FormatException ex)
            {
                throw new ApiException(ex.Message.ToString());
            }
        }
    }
}
