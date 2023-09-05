using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfInstalmentType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfInstalmentTypes.Queries.GetFilterRfInstalmetTypes
{
    public class RfInstalmentTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfInstalmentTypeResponse>>>
    {
    }

    public class RfInstalmentTypesGetFilterQueryHandler : IRequestHandler<RfInstalmentTypesGetFilterQuery, PagedResponse<IEnumerable<RfInstalmentTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfInstalmentType> _rfInstalmentType;
        private readonly IMapper _mapper;

        public RfInstalmentTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfInstalmentType> rfInstalmentType, IMapper mapper)
        {
            _rfInstalmentType = rfInstalmentType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfInstalmentTypeResponse>>> Handle(RfInstalmentTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfInstalmentType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfInstalmentTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfInstalmentTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
