using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Queries
{
    public class RFNegaraPenempatansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFPlacementCountryResponseDto>>>
    {
    }

    public class GetFilterRFNegaraPenempatanQueryHandler : IRequestHandler<RFNegaraPenempatansGetFilterQuery, PagedResponse<IEnumerable<RFPlacementCountryResponseDto>>>
    {
        private IGenericRepositoryAsync<RFPlacementCountry> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public GetFilterRFNegaraPenempatanQueryHandler(IGenericRepositoryAsync<RFPlacementCountry> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFPlacementCountryResponseDto>>> Handle(RFNegaraPenempatansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFNegaraPenempatan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFNegaraPenempatanResponseDto>>(data.Results);
            IEnumerable<RFPlacementCountryResponseDto> dataVm;
            var listResponse = new List<RFPlacementCountryResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFPlacementCountryResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFPlacementCountryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}