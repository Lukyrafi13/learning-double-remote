using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBIGroups;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBIGroups.Queries
{
    public class EnumSandiBIGroupsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<EnumSandiBIGroupResponseDto>>>
    {
    }

    public class EnumSandiBIGroupsGetFilterQueryHandler : IRequestHandler<EnumSandiBIGroupsGetFilterQuery, PagedResponse<IEnumerable<EnumSandiBIGroupResponseDto>>>
    {
        private IGenericRepositoryAsync<EnumSandiBIGroup> _EnumSandiBIGroup;
        private readonly IMapper _mapper;

        public EnumSandiBIGroupsGetFilterQueryHandler(IGenericRepositoryAsync<EnumSandiBIGroup> EnumSandiBIGroup, IMapper mapper)
        {
            _EnumSandiBIGroup = EnumSandiBIGroup;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<EnumSandiBIGroupResponseDto>>> Handle(EnumSandiBIGroupsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _EnumSandiBIGroup.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<EnumSandiBIGroupResponseDto>>(data.Results);
            IEnumerable<EnumSandiBIGroupResponseDto> dataVm;
            var listResponse = new List<EnumSandiBIGroupResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<EnumSandiBIGroupResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<EnumSandiBIGroupResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}