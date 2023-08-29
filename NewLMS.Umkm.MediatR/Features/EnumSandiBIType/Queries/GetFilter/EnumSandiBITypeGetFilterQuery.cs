using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Queries
{
    public class EnumSandiBITypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<EnumSandiBITypeResponseDto>>>
    {
    }

    public class EnumSandiBITypesGetFilterQueryHandler : IRequestHandler<EnumSandiBITypesGetFilterQuery, PagedResponse<IEnumerable<EnumSandiBITypeResponseDto>>>
    {
        private IGenericRepositoryAsync<EnumSandiBIType> _EnumSandiBIType;
        private readonly IMapper _mapper;

        public EnumSandiBITypesGetFilterQueryHandler(IGenericRepositoryAsync<EnumSandiBIType> EnumSandiBIType, IMapper mapper)
        {
            _EnumSandiBIType = EnumSandiBIType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<EnumSandiBITypeResponseDto>>> Handle(EnumSandiBITypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _EnumSandiBIType.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<EnumSandiBITypeResponseDto>>(data.Results);
            IEnumerable<EnumSandiBITypeResponseDto> dataVm;
            var listResponse = new List<EnumSandiBITypeResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<EnumSandiBITypeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<EnumSandiBITypeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}