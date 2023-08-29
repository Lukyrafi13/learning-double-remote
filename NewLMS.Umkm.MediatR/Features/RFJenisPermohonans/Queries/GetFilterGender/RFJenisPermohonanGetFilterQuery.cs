using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Queries
{
    public class RFJenisPermohonansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisPermohonanResponseDto>>>
    {
    }

    public class GetFilterRFJenisPermohonanQueryHandler : IRequestHandler<RFJenisPermohonansGetFilterQuery, PagedResponse<IEnumerable<RFJenisPermohonanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisPermohonan> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public GetFilterRFJenisPermohonanQueryHandler(IGenericRepositoryAsync<RFJenisPermohonan> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisPermohonanResponseDto>>> Handle(RFJenisPermohonansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfJenisPermohonan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisPermohonanResponseDto>>(data.Results);
            IEnumerable<RFJenisPermohonanResponseDto> dataVm;
            var listResponse = new List<RFJenisPermohonanResponseDto>();

            foreach (var permohonan in data.Results){

                var response = _mapper.Map<RFJenisPermohonanResponseDto>(permohonan);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisPermohonanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}