using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries
{
    public class RfCompanyTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyTypeResponseDto>>>
    {
    }

    public class GetFilterRfCompanyTypeQueryHandler : IRequestHandler<RfCompanyTypesGetFilterQuery, PagedResponse<IEnumerable<RfCompanyTypeResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public GetFilterRfCompanyTypeQueryHandler(IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyTypeResponseDto>>> Handle(RfCompanyTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyType.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeResponseDto>>(data.Results);
            IEnumerable<RfCompanyTypeResponseDto> dataVm;
            var listResponse = new List<RfCompanyTypeResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RfCompanyTypeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCompanyTypeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}