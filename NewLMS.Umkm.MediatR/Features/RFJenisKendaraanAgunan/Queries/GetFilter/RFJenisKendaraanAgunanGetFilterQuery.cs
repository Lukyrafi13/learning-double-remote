using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisKendaraanAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisKendaraanAgunans.Queries
{
    public class RFJenisKendaraanAgunansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisKendaraanAgunanResponseDto>>>
    {
    }

    public class GetFilterRFJenisKendaraanAgunanQueryHandler : IRequestHandler<RFJenisKendaraanAgunansGetFilterQuery, PagedResponse<IEnumerable<RFJenisKendaraanAgunanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisKendaraanAgunan> _RFJenisKendaraanAgunan;
        private readonly IMapper _mapper;

        public GetFilterRFJenisKendaraanAgunanQueryHandler(IGenericRepositoryAsync<RFJenisKendaraanAgunan> RFJenisKendaraanAgunan, IMapper mapper)
        {
            _RFJenisKendaraanAgunan = RFJenisKendaraanAgunan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisKendaraanAgunanResponseDto>>> Handle(RFJenisKendaraanAgunansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisKendaraanAgunan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisKendaraanAgunanResponseDto>>(data.Results);
            IEnumerable<RFJenisKendaraanAgunanResponseDto> dataVm;
            var listResponse = new List<RFJenisKendaraanAgunanResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFJenisKendaraanAgunanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisKendaraanAgunanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}