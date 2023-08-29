using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Queries
{
    public class RfCompanyGroupsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyGroupResponseDto>>>
    {
    }

    public class GetFilterRfCompanyGroupQueryHandler : IRequestHandler<RfCompanyGroupsGetFilterQuery, PagedResponse<IEnumerable<RfCompanyGroupResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCompanyGroup> _RfCompanyGroup;
        private readonly IMapper _mapper;

        public GetFilterRfCompanyGroupQueryHandler(IGenericRepositoryAsync<RfCompanyGroup> RfCompanyGroup, IMapper mapper)
        {
            _RfCompanyGroup = RfCompanyGroup;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyGroupResponseDto>>> Handle(RfCompanyGroupsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyGroup.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyGroupResponseDto>>(data.Results);
            IEnumerable<RfCompanyGroupResponseDto> dataVm;
            var listResponse = new List<RfCompanyGroupResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RfCompanyGroupResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCompanyGroupResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}