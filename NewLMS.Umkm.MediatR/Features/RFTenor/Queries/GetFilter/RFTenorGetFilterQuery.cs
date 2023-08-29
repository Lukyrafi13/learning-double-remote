using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenors.Queries
{
    public class RFTenorsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTenorResponseDto>>>
    {
    }

    public class GetFilterRFTenorQueryHandler : IRequestHandler<RFTenorsGetFilterQuery, PagedResponse<IEnumerable<RFTenorResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public GetFilterRFTenorQueryHandler(IGenericRepositoryAsync<RFTenor> RFTenor, IMapper mapper)
        {
            _RFTenor = RFTenor;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTenorResponseDto>>> Handle(RFTenorsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFTenor.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTenorResponseDto>>(data.Results);
            IEnumerable<RFTenorResponseDto> dataVm;
            var listResponse = new List<RFTenorResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFTenorResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTenorResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}