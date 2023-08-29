using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PersiapanAkads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.PersiapanAkads.Queries
{
    public class PersiapanAkadsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<PersiapanAkadTableResponse>>>
    {
    }

    public class PersiapanAkadsGetFilterQueryHandler : IRequestHandler<PersiapanAkadsGetFilterQuery, PagedResponse<IEnumerable<PersiapanAkadTableResponse>>>
    {
        private IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
        private readonly IMapper _mapper;

        public PersiapanAkadsGetFilterQueryHandler(
            IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
            IMapper mapper)
        {
            _PersiapanAkad = PersiapanAkad;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PersiapanAkadTableResponse>>> Handle(PersiapanAkadsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "App.KodePos",
                "App.JenisProduk",
                "App.BookingOffice",
                "App.Prospect",
                "App.Prospect.ProspectStageLogs",
                "App.Prospect.ProspectStageLogs.RFStages",
                "App.TipeDebitur",
                "SPPK",
                "Analisa",
                "Prescreening",
            };

            var data = await _PersiapanAkad.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<PersiapanAkadTableResponse>>(data.Results);
            IEnumerable<PersiapanAkadTableResponse> dataVm;
            var listResponse = new List<PersiapanAkadTableResponse>();

            foreach (var res in data.Results)
            {
                var response = new PersiapanAkadTableResponse();

                response.Id = res.Id;
                response.App = res.App;
                response.Prescreening = res.Prescreening;
                response.SPPK = res.SPPK;
                response.Age = res.Age;
                response.Analisa = res.Analisa;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<PersiapanAkadTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}