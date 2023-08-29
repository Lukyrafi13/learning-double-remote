using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SPPKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.SPPKs.Queries
{
    public class SPPKsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SPPKTableResponse>>>
    {
    }

    public class SPPKsGetFilterQueryHandler : IRequestHandler<SPPKsGetFilterQuery, PagedResponse<IEnumerable<SPPKTableResponse>>>
    {
        private IGenericRepositoryAsync<SPPK> _SPPK;
        private readonly IMapper _mapper;

        public SPPKsGetFilterQueryHandler(
            IGenericRepositoryAsync<SPPK> SPPK,
            IMapper mapper)
        {
            _SPPK = SPPK;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SPPKTableResponse>>> Handle(SPPKsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "App.Prospect",
                "App.Prospect.ProspectStageLogs",
                "App.Prospect.ProspectStageLogs.RFStages",
                "Analisa",
                "Analisa.Survey",
            };

            var data = await _SPPK.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SPPKTableResponse>>(data.Results);
            IEnumerable<SPPKTableResponse> dataVm;
            var listResponse = new List<SPPKTableResponse>();

            foreach (var res in data.Results){
                var response = new SPPKTableResponse();

                response.Id = res.Id;
                response.App = res.App;
                response.Age = res.Age;
                response.Analisa = res.Analisa;
                
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SPPKTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}