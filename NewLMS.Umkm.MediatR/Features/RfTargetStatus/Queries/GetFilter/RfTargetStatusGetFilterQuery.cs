using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfTargetStatuses;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Queries
{
    public class RfTargetStatusGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfTargetStatusResponseDto>>>
    {
    }

    public class GetFilterRfTargetStatusQueryHandler : IRequestHandler<RfTargetStatusGetFilterQuery, PagedResponse<IEnumerable<RfTargetStatusResponseDto>>>
    {
        private IGenericRepositoryAsync<RfTargetStatus> _rfStatusTarget;
        private readonly IMapper _mapper;

        public GetFilterRfTargetStatusQueryHandler(IGenericRepositoryAsync<RfTargetStatus> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfTargetStatusResponseDto>>> Handle(RfTargetStatusGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfStatusTarget.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfTargetStatusResponseDto>>(data.Results);
            IEnumerable<RfTargetStatusResponseDto> dataVm;
            var listResponse = new List<RfTargetStatusResponseDto>();

            foreach (var res in data.Results){
                var response = new RfTargetStatusResponseDto();
                
                response.Id = res.Id;
                response.Active = res.Active;
                response.StatusCode = res.StatusCode;
                response.StatusDesc = res.StatusDesc;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfTargetStatusResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}