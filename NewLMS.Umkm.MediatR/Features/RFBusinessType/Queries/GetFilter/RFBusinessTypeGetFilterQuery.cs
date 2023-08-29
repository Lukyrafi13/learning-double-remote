using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Queries
{
    public class RFBusinessTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBusinessTypeResponseDto>>>
    {
    }

    public class RFBusinessTypesGetFilterQueryHandler : IRequestHandler<RFBusinessTypesGetFilterQuery, PagedResponse<IEnumerable<RFBusinessTypeResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBusinessType> _RFBusinessType;
        private readonly IMapper _mapper;

        public RFBusinessTypesGetFilterQueryHandler(IGenericRepositoryAsync<RFBusinessType> RFBusinessType, IMapper mapper)
        {
            _RFBusinessType = RFBusinessType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBusinessTypeResponseDto>>> Handle(RFBusinessTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFBusinessType.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBusinessTypeResponseDto>>(data.Results);
            IEnumerable<RFBusinessTypeResponseDto> dataVm;
            var listResponse = new List<RFBusinessTypeResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFBusinessTypeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBusinessTypeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}