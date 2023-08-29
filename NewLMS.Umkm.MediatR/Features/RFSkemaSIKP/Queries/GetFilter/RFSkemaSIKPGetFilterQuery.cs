using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSkemaSIKPs.Queries
{
    public class RFSkemaSIKPsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSkemaSIKPResponseDto>>>
    {
    }

    public class GetFilterRFSkemaSIKPQueryHandler : IRequestHandler<RFSkemaSIKPsGetFilterQuery, PagedResponse<IEnumerable<RFSkemaSIKPResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public GetFilterRFSkemaSIKPQueryHandler(IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP, IMapper mapper)
        {
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSkemaSIKPResponseDto>>> Handle(RFSkemaSIKPsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSkemaSIKP.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSkemaSIKPResponseDto>>(data.Results);
            IEnumerable<RFSkemaSIKPResponseDto> dataVm;
            var listResponse = new List<RFSkemaSIKPResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSkemaSIKPResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSkemaSIKPResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}