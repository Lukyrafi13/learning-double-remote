using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries.GetFilterRfCompanyTypes
{
    public class RfCompanyTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyTypeResponse>>>
    {
    }

    public class RfCompanyTypesGetFilterQueryHandler : IRequestHandler<RfCompanyTypesGetFilterQuery, PagedResponse<IEnumerable<RfCompanyTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfCompanyType> _rfCompanyType;
        private readonly IMapper _mapper;

        public RfCompanyTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfCompanyType> rfCompanyType, IMapper mapper)
        {
            _rfCompanyType = rfCompanyType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyTypeResponse>>> Handle(RfCompanyTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
            {
                "ParamCompanyGroup"
            };
            var data = await _rfCompanyType.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfCompanyTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
