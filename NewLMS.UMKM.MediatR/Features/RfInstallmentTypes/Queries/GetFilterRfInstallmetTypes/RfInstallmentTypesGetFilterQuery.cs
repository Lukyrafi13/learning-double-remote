using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfInstallmentTypes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfInstallmentTypes.Queries.GetFilterRfInstalmetTypes
{
    public class RfInstallmentTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfInstallmentTypeResponse>>>
    {
    }

    public class RfInstallmentTypesGetFilterQueryHandler : IRequestHandler<RfInstallmentTypesGetFilterQuery, PagedResponse<IEnumerable<RfInstallmentTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfInstallmentType> _rfInstalmentType;
        private readonly IMapper _mapper;

        public RfInstallmentTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfInstallmentType> rfInstalmentType, IMapper mapper)
        {
            _rfInstalmentType = rfInstalmentType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfInstallmentTypeResponse>>> Handle(RfInstallmentTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfInstalmentType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfInstallmentTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfInstallmentTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
