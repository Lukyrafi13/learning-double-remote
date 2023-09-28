using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Queries
{
    public class LoanApplicationVerificationNeedDetailsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>>
    {
    }

    public class LoanApplicationVerificationNeedDetailsGetFilterQueryHandler : IRequestHandler<LoanApplicationVerificationNeedDetailsGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> _core;
        private readonly IMapper _mapper;

        public LoanApplicationVerificationNeedDetailsGetFilterQueryHandler(IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>> Handle(LoanApplicationVerificationNeedDetailsGetFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>(dataVm, data.Info, request.Page, request.Length)
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
