using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTenorMappings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTenorMappings.Queries
{
    public class RFTenorMappingsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTenorMappingResponseDto>>>
    {
    }

    public class GetFilterRFTenorMappingQueryHandler : IRequestHandler<RFTenorMappingsGetFilterQuery, PagedResponse<IEnumerable<RFTenorMappingResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTenorMapping> _RFTenorMapping;
        private readonly IMapper _mapper;

        public GetFilterRFTenorMappingQueryHandler(IGenericRepositoryAsync<RFTenorMapping> RFTenorMapping, IMapper mapper)
        {
            _RFTenorMapping = RFTenorMapping;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTenorMappingResponseDto>>> Handle(RFTenorMappingsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFTenorMapping.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTenorMappingResponseDto>>(data.Results);
            IEnumerable<RFTenorMappingResponseDto> dataVm;
            var listResponse = new List<RFTenorMappingResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFTenorMappingResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTenorMappingResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}