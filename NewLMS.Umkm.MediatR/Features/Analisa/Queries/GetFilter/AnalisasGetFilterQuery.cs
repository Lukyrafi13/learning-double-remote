using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Analisas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;

namespace NewLMS.Umkm.MediatR.Features.Analisas.Queries
{
    public class AnalisasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaTableResponse>>>
    {
    }

    public class AnalisasGetFilterQueryHandler : IRequestHandler<AnalisasGetFilterQuery, PagedResponse<IEnumerable<AnalisaTableResponse>>>
    {
        private IGenericRepositoryAsync<Analisa> _Analisa;
        private readonly IMapper _mapper;

        public AnalisasGetFilterQueryHandler(
            IGenericRepositoryAsync<Analisa> Analisa,
            IMapper mapper)
        {
            _Analisa = Analisa;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AnalisaTableResponse>>> Handle(AnalisasGetFilterQuery request, CancellationToken cancellationToken)
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
                "Prescreening",
                "Survey",
                "SlikRequest",
            };

            var data = await _Analisa.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<AnalisaTableResponse>>(data.Results);
            IEnumerable<AnalisaTableResponse> dataVm;
            var listResponse = new List<AnalisaTableResponse>();

            foreach (var res in data.Results){
                var response = new AnalisaTableResponse();

                response.Id = res.Id;
                response.App = res.App;
                response.Prescreening = res.Prescreening;
                response.Survey = res.Survey;
                response.SlikRequest = res.SlikRequest;
                response.Age = res.Age;
                
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<AnalisaTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}