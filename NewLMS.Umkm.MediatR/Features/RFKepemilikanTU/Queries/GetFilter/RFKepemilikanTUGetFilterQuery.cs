using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKepemilikanTUs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanTUs.Queries
{
    public class RFKepemilikanTUsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFKepemilikanTUResponseDto>>>
    {
    }

    public class GetFilterRFKepemilikanTUQueryHandler : IRequestHandler<RFKepemilikanTUsGetFilterQuery, PagedResponse<IEnumerable<RFKepemilikanTUResponseDto>>>
    {
        private IGenericRepositoryAsync<RFKepemilikanTU> _RFKepemilikanTU;
        private readonly IMapper _mapper;

        public GetFilterRFKepemilikanTUQueryHandler(IGenericRepositoryAsync<RFKepemilikanTU> RFKepemilikanTU, IMapper mapper)
        {
            _RFKepemilikanTU = RFKepemilikanTU;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFKepemilikanTUResponseDto>>> Handle(RFKepemilikanTUsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFKepemilikanTU.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFKepemilikanTUResponseDto>>(data.Results);
            IEnumerable<RFKepemilikanTUResponseDto> dataVm;
            var listResponse = new List<RFKepemilikanTUResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFKepemilikanTUResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFKepemilikanTUResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}