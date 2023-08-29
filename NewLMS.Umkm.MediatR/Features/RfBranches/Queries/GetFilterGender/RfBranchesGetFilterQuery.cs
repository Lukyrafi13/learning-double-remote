using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfBranchess;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RfBranchess.Queries
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
            _RfBranches = RfBranches;
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