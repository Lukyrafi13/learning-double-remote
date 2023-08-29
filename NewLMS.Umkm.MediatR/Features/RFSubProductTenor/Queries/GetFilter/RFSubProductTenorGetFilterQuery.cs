using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Queries
{
    public class RFSubProductTenorsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSubProductTenorResponseDto>>>
    {
    }

    public class GetFilterRFSubProductTenorQueryHandler : IRequestHandler<RFSubProductTenorsGetFilterQuery, PagedResponse<IEnumerable<RFSubProductTenorResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private readonly IMapper _mapper;

        public GetFilterRFSubProductTenorQueryHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper)
        {
            _RFSubProductTenor = RFSubProductTenor;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSubProductTenorResponseDto>>> Handle(RFSubProductTenorsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSubProductTenor.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSubProductTenorResponseDto>>(data.Results);
            IEnumerable<RFSubProductTenorResponseDto> dataVm;
            var listResponse = new List<RFSubProductTenorResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSubProductTenorResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSubProductTenorResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}