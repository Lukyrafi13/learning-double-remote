﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfBranches.Queries
{
    public class RfBranchGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBranchResponse>>>
    {
    }

    public class RfBranchGetFilterQueryHandler : IRequestHandler<RfBranchGetFilterQuery, PagedResponse<IEnumerable<RfBranchResponse>>>
    {
        private IGenericRepositoryAsync<RfBranch> _rfBranch;
        private readonly IMapper _mapper;

        public RfBranchGetFilterQueryHandler(IGenericRepositoryAsync<RfBranch> rfBranch, IMapper mapper)
        {
            _rfBranch = rfBranch;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBranchResponse>>> Handle(RfBranchGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBranch.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBranchResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBranchResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
