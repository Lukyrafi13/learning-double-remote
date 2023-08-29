using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Queries
{
    public class RFJenisUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisUsahaResponseDto>>>
    {
    }

    public class GetFilterRFJenisUsahaQueryHandler : IRequestHandler<RFJenisUsahasGetFilterQuery, PagedResponse<IEnumerable<RFJenisUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFJenisUsahaQueryHandler(IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisUsahaResponseDto>>> Handle(RFJenisUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisUsahaResponseDto>>(data.Results);
            IEnumerable<RFJenisUsahaResponseDto> dataVm;
            var listResponse = new List<RFJenisUsahaResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJenisUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}