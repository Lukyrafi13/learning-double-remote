using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStagess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFStagess.Queries
{
    public class RFStagessGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFStagesResponseDto>>>
    {
    }

    public class GetFilterRFStagesQueryHandler : IRequestHandler<RFStagessGetFilterQuery, PagedResponse<IEnumerable<RFStagesResponseDto>>>
    {
        private IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IMapper _mapper;

        public GetFilterRFStagesQueryHandler(IGenericRepositoryAsync<RFStages> RFStages, IMapper mapper)
        {
            _RFStages = RFStages;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFStagesResponseDto>>> Handle(RFStagessGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFStages.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFStagesResponseDto>>(data.Results);
            IEnumerable<RFStagesResponseDto> dataVm;
            var listResponse = new List<RFStagesResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFStagesResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFStagesResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}