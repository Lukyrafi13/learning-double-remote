using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBranchInsComps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBranchInsComps.Queries
{
    public class RFBranchInsCompsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBranchInsCompResponseDto>>>
    {
    }

    public class RFBranchInsCompsGetFilterQueryHandler : IRequestHandler<RFBranchInsCompsGetFilterQuery, PagedResponse<IEnumerable<RFBranchInsCompResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBranchInsComp> _RFBranchInsComp;
        private readonly IMapper _mapper;

        public RFBranchInsCompsGetFilterQueryHandler(IGenericRepositoryAsync<RFBranchInsComp> RFBranchInsComp, IMapper mapper)
        {
            _RFBranchInsComp = RFBranchInsComp;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBranchInsCompResponseDto>>> Handle(RFBranchInsCompsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFBranchInsComp.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBranchInsCompResponseDto>>(data.Results);
            IEnumerable<RFBranchInsCompResponseDto> dataVm;
            var listResponse = new List<RFBranchInsCompResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFBranchInsCompResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBranchInsCompResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}