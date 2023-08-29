using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaAsuransis.Queries
{
    public class AnalisaAsuransisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>>
    {
    }

    public class GetFilterAnalisaAsuransiQueryHandler : IRequestHandler<AnalisaAsuransisGetFilterQuery, PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>>
    {
        private IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
        private readonly IMapper _mapper;

        public GetFilterAnalisaAsuransiQueryHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper)
        {
            _AnalisaAsuransi = AnalisaAsuransi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>> Handle(AnalisaAsuransisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "Analisa",
                    "Analisa.Survey",
                    "RFJenisAsuransi",
                };

            var data = await _AnalisaAsuransi.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<AnalisaAsuransiResponseDto>>(data.Results);
            IEnumerable<AnalisaAsuransiResponseDto> dataVm;
            var listResponse = new List<AnalisaAsuransiResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<AnalisaAsuransiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}