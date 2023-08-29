using DocumentFormat.OpenXml.Spreadsheet;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.MediatR.Exceptions;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ThridParties.Queries.GetThridPartyByClientIdAndClientSecret
{
    public class GetThridPartyByClientIdAndClientSecretQuery : IRequest<bool>
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientSecret { get; set; }
    }

    public class GetThridPartyByClientIdAndClientSecretQueryHandler : IRequestHandler<GetThridPartyByClientIdAndClientSecretQuery, bool>
    {
        private readonly IGenericRepositoryAsync<ThridParty> _thridParty;

        public GetThridPartyByClientIdAndClientSecretQueryHandler(IGenericRepositoryAsync<ThridParty> thridParty)
        {
            _thridParty = thridParty;
        }

        public async Task<bool> Handle(GetThridPartyByClientIdAndClientSecretQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = _thridParty.GetByPredicate(x => x.ClientId == request.ClientId && x.ClientSecret == request.ClientSecret);
                if (exists.Result != null)
                {
                    if (!string.IsNullOrEmpty(exists.Result.UrlCallback))
                    {
                        return true;
                    }
                    else
                    {
                        throw new ApiException($"url callback untuk {exists.Result.Name} belum disetting silahkan hubungi admin");
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new ApiException(ex.Message.ToString());
            }
        }
    }
}
