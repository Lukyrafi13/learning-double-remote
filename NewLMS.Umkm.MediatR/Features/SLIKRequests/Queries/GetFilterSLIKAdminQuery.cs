﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequests.Queries
{
    public class GetFilterSLIKAdminQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SLIKRequestTableResponse>>>
    {
    }

    public class GetFilterSLIKAdminQueryHandler : IRequestHandler<GetFilterSLIKAdminQuery, PagedResponse<IEnumerable<SLIKRequestTableResponse>>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IMapper _mapper;

        public GetFilterSLIKAdminQueryHandler(IMapper mapper, IGenericRepositoryAsync<SLIKRequest> slikRequest)
        {
            _mapper = mapper;
            _slikRequest = slikRequest;
        }

        public async Task<PagedResponse<IEnumerable<SLIKRequestTableResponse>>> Handle(GetFilterSLIKAdminQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    "LoanApplication.RfBookingBranch",
                    "LoanApplication.Debtor",
                    "LoanApplication.DebtorCompany",
                    "LoanApplication.RfOwnerCategory",
                    "SLIKRequestDebtors"
                };

            request.Filters.Add(new RequestFilterParameter
            {
                Field = "AdminVerified",
                ComparisonOperator = "=",
                Type = "bool",
                Value = "false"
            });

            request.Filters.Add(new RequestFilterParameter
            {
                Field = "StageId",
                ComparisonOperator = "=",
                Type = "string",
                Value = UMKMConst.Stages["SLIKAdmin"].ToString()
            });
            var data = await _slikRequest.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<SLIKRequestTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<SLIKRequestTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
