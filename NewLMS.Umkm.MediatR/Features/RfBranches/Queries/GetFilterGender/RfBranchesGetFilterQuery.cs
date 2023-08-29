using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranchess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBranchess.Queries
{
    public class RfBranchessGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBranchesResponseDto>>>
    {
    }

    public class GetFilterRfBranchesQueryHandler : IRequestHandler<RfBranchessGetFilterQuery, PagedResponse<IEnumerable<RfBranchesResponseDto>>>
    {
        private IGenericRepositoryAsync<RfBranches> _RfBranches;
        private readonly IMapper _mapper;

        public GetFilterRfBranchesQueryHandler(IGenericRepositoryAsync<RfBranches> RfBranches, IMapper mapper)
        {
            _RfBranch = RfBranches;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBranchesResponseDto>>> Handle(RfBranchessGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfBranches.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfBranchesResponseDto>>(data.Results);
            IEnumerable<RfBranchesResponseDto> dataVm;
            var listResponse = new List<RfBranchesResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RfBranchesResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfBranchesResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}