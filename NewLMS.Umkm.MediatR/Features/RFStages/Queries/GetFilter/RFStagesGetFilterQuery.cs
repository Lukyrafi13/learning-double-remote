using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfStages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfStages.Queries
{
    public class RfStageGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfStageResponseDto>>>
    {
    }

    public class GetFilterRfStageQueryHandler : IRequestHandler<RfStageGetFilterQuery, PagedResponse<IEnumerable<RfStageResponseDto>>>
    {
        private IGenericRepositoryAsync<RfStage> _RfStage;
        private readonly IMapper _mapper;

        public GetFilterRfStageQueryHandler(IGenericRepositoryAsync<RfStage> RfStage, IMapper mapper)
        {
            _RfStage = RfStage;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfStageResponseDto>>> Handle(RfStageGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfStage.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfStageResponseDto>>(data.Results);
            IEnumerable<RfStageResponseDto> dataVm;
            var listResponse = new List<RfStageResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RfStageResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfStageResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}