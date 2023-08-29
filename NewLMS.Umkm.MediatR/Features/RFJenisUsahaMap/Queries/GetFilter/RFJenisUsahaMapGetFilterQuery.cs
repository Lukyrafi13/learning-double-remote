using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Queries
{
    public class RFJenisUsahaMapsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisUsahaMapResponseDto>>>
    {
    }

    public class GetFilterRFJenisUsahaMapQueryHandler : IRequestHandler<RFJenisUsahaMapsGetFilterQuery, PagedResponse<IEnumerable<RFJenisUsahaMapResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
                private IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFJenisUsahaMapQueryHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisUsahaMapResponseDto>>> Handle(RFJenisUsahaMapsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisUsahaMap.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisUsahaMapResponseDto>>(data.Results);
            IEnumerable<RFJenisUsahaMapResponseDto> dataVm;
            var listResponse = new List<RFJenisUsahaMapResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJenisUsahaMapResponseDto>(res);

                var jenisUsaha = await _RFJenisUsaha.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

                if (jenisUsaha != null){
                    response.ANL_DESC = jenisUsaha.ANL_DESC;
                    response.ANL_ACTIVE = jenisUsaha.ACTIVE??false;
                }

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisUsahaMapResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}