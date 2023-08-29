using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBentukLahans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBentukLahans.Queries
{
    public class RFBentukLahansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBentukLahanResponseDto>>>
    {
    }

    public class GetFilterRFBentukLahanQueryHandler : IRequestHandler<RFBentukLahansGetFilterQuery, PagedResponse<IEnumerable<RFBentukLahanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBentukLahan> _RFBentukLahan;
        private readonly IMapper _mapper;

        public GetFilterRFBentukLahanQueryHandler(IGenericRepositoryAsync<RFBentukLahan> RFBentukLahan, IMapper mapper)
        {
            _RFBentukLahan = RFBentukLahan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBentukLahanResponseDto>>> Handle(RFBentukLahansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFBentukLahan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBentukLahanResponseDto>>(data.Results);
            IEnumerable<RFBentukLahanResponseDto> dataVm;
            var listResponse = new List<RFBentukLahanResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFBentukLahanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBentukLahanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}