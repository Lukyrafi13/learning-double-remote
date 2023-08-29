using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBranches.Queries
{
    public class RfBranchGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBranchResponseDto>>>
    {
    }

    public class RfBranchGetFilterQueryHandler : IRequestHandler<RfBranchGetFilterQuery, PagedResponse<IEnumerable<RfBranchResponseDto>>>
    {
        private IGenericRepositoryAsync<RfBranch> _RfBranch;
        private readonly IMapper _mapper;

        public RfBranchGetFilterQueryHandler(IGenericRepositoryAsync<RfBranch> RfBranch, IMapper mapper)
        {
            _RfBranch = RfBranch;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBranchResponseDto>>> Handle(RfBranchGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfBranch.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfBranchResponseDto>>(data.Results);
            IEnumerable<RfBranchResponseDto> dataVm;
            var listResponse = new List<RfBranchResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RfBranchResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfBranchResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}