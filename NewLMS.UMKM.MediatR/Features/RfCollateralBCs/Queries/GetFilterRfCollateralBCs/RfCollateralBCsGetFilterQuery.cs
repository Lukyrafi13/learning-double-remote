﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCollateralBCs.Queries.GetFilterRfCollateralBCs
{
    public class RfCollateralBCsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCollateralBCResponse>>>
    {
    }

    public class RfCollateralBCsGetFilterQueryHandler : IRequestHandler<RfCollateralBCsGetFilterQuery, PagedResponse<IEnumerable<RfCollateralBCResponse>>>
    {
        private IGenericRepositoryAsync<RfCollateralBC> _rfCollateralBC;
        private readonly IMapper _mapper;

        public RfCollateralBCsGetFilterQueryHandler(IGenericRepositoryAsync<RfCollateralBC> rfCollateralBC, IMapper mapper)
        {
            _rfCollateralBC = rfCollateralBC;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCollateralBCResponse>>> Handle(RfCollateralBCsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfCollateralBC.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfCollateralBCResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfCollateralBCResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
