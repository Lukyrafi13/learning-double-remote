using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDecisionSKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDecisionSKs.Queries
{
    public class RFDecisionSKsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFDecisionSKResponseDto>>>
    {
    }

    public class GetFilterRFDecisionSKQueryHandler : IRequestHandler<RFDecisionSKsGetFilterQuery, PagedResponse<IEnumerable<RFDecisionSKResponseDto>>>
    {
        private IGenericRepositoryAsync<RFDecisionSK> _RFDecisionSK;
        private readonly IMapper _mapper;

        public GetFilterRFDecisionSKQueryHandler(IGenericRepositoryAsync<RFDecisionSK> RFDecisionSK, IMapper mapper)
        {
            _RFDecisionSK = RFDecisionSK;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFDecisionSKResponseDto>>> Handle(RFDecisionSKsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFDecisionSK.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFDecisionSKResponseDto>>(data.Results);
            IEnumerable<RFDecisionSKResponseDto> dataVm;
            var listResponse = new List<RFDecisionSKResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFDecisionSKResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFDecisionSKResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}