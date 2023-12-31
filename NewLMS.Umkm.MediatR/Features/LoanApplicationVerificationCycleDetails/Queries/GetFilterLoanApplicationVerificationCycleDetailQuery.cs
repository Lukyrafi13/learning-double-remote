﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationCycleDetails.Queries
{
    public class GetFilterLoanApplicationVerificationCycleDetailQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>>
    {
    }

    public class GetFilterLoanApplicationVerificationCycleDetailQueryHandler : IRequestHandler<GetFilterLoanApplicationVerificationCycleDetailQuery, PagedResponse<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> _core;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationVerificationCycleDetailQueryHandler(IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>> Handle(GetFilterLoanApplicationVerificationCycleDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>(dataVm, data.Info, request.Page, request.Length)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
