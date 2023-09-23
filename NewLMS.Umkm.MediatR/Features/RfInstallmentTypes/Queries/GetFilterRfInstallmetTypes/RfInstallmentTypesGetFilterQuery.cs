using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfInstallmentTypes;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfInstallmentTypes.Queries.GetFilterRfInstalmetTypes
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
