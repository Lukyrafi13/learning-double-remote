using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsRateMappings;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFInsRateMappings.Queries
{
    public class RFInsRateMappingsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFInsRateMappingResponseDto>>>
    {
    }

    public class RFInsRateMappingsGetFilterQueryHandler : IRequestHandler<RFInsRateMappingsGetFilterQuery, PagedResponse<IEnumerable<RFInsRateMappingResponseDto>>>
    {
        private IGenericRepositoryAsync<RFInsRateMapping> _RFInsRateMapping;
        private readonly IMapper _mapper;

        public RFInsRateMappingsGetFilterQueryHandler(IGenericRepositoryAsync<RFInsRateMapping> RFInsRateMapping, IMapper mapper)
        {
            _RFInsRateMapping = RFInsRateMapping;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFInsRateMappingResponseDto>>> Handle(RFInsRateMappingsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFInsRateMapping.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFInsRateMappingResponseDto>>(data.Results);
            IEnumerable<RFInsRateMappingResponseDto> dataVm;
            var listResponse = new List<RFInsRateMappingResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFInsRateMappingResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFInsRateMappingResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}