using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Queries
{
    public class RFJenisTempatUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisTempatUsahaResponseDto>>>
    {
    }

    public class GetFilterRFJenisTempatUsahaQueryHandler : IRequestHandler<RFJenisTempatUsahasGetFilterQuery, PagedResponse<IEnumerable<RFJenisTempatUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisTempatUsaha> _RFJenisTempatUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFJenisTempatUsahaQueryHandler(IGenericRepositoryAsync<RFJenisTempatUsaha> RFJenisTempatUsaha, IMapper mapper)
        {
            _RFJenisTempatUsaha = RFJenisTempatUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisTempatUsahaResponseDto>>> Handle(RFJenisTempatUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisTempatUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisTempatUsahaResponseDto>>(data.Results);
            IEnumerable<RFJenisTempatUsahaResponseDto> dataVm;
            var listResponse = new List<RFJenisTempatUsahaResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJenisTempatUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisTempatUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}