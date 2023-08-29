using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationCols;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFRelationCols.Queries
{
    public class RFRelationColsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFRelationColResponseDto>>>
    {
    }

    public class GetFilterRFRelationColQueryHandler : IRequestHandler<RFRelationColsGetFilterQuery, PagedResponse<IEnumerable<RFRelationColResponseDto>>>
    {
        private IGenericRepositoryAsync<RFRelationCol> _RFRelationCol;
        private readonly IMapper _mapper;

        public GetFilterRFRelationColQueryHandler(IGenericRepositoryAsync<RFRelationCol> RFRelationCol, IMapper mapper)
        {
            _RFRelationCol = RFRelationCol;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFRelationColResponseDto>>> Handle(RFRelationColsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFRelationCol.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFRelationColResponseDto>>(data.Results);
            IEnumerable<RFRelationColResponseDto> dataVm;
            var listResponse = new List<RFRelationColResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFRelationColResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFRelationColResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}