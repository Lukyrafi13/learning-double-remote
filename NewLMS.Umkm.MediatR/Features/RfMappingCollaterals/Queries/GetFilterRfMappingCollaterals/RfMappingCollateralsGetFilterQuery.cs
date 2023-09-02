using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMappingCollateral;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfMappingCollaterals.Queries.GetFilterRfMappingCollaterals
{
    public class RfMappingCollateralsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMappingCollateralResponse>>>
    {
    }

    public class RfMappingCollateralsGetFilterQueryHandler : IRequestHandler<RfMappingCollateralsGetFilterQuery, PagedResponse<IEnumerable<RfMappingCollateralResponse>>>
    {
        private IGenericRepositoryAsync<RfMappingCollateral> _rfMappingCollateral;
        private readonly IMapper _mapper;

        public RfMappingCollateralsGetFilterQueryHandler(IGenericRepositoryAsync<RfMappingCollateral> rfMappingCollateral, IMapper mapper)
        {
            _rfMappingCollateral = rfMappingCollateral;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMappingCollateralResponse>>> Handle(RfMappingCollateralsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
                "RfCollateralBC",
            };
            var data = await _rfMappingCollateral.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfMappingCollateralResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMappingCollateralResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
