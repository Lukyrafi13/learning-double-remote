using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfDocumentCollateral;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfDocumentCollaterals.Queries.GetFilterRfDocumentCollaterals
{
    public class RfDocumentCollateralsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfDocumentCollateralResponse>>>
    {
    }

    public class RfDocumentCollateralsGetFilterQueryHandler : IRequestHandler<RfDocumentCollateralsGetFilterQuery, PagedResponse<IEnumerable<RfDocumentCollateralResponse>>>
    {
        private IGenericRepositoryAsync<RfDocumentCollateral> _rfDocumentCollateral;
        private readonly IMapper _mapper;

        public RfDocumentCollateralsGetFilterQueryHandler(IGenericRepositoryAsync<RfDocumentCollateral> rfDocumentCollateral, IMapper mapper)
        {
            _rfDocumentCollateral = rfDocumentCollateral;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfDocumentCollateralResponse>>> Handle(RfDocumentCollateralsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfDocument",
                "RfCollateralBC",
            };
            var data = await _rfDocumentCollateral.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfDocumentCollateralResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfDocumentCollateralResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
