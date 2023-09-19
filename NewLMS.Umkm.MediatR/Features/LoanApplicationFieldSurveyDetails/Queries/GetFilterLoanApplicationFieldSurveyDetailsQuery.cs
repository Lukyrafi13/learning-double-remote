using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationFieldSurveyDetails.Queries
{
    public class GetFilterLoanApplicationFieldSurveyDetailsQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>>
    {
    }

    public class GetFilterLoanApplicationFieldSurveyDetailsQueryHandler : IRequestHandler<GetFilterLoanApplicationFieldSurveyDetailsQuery, PagedResponse<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> _core;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationFieldSurveyDetailsQueryHandler(IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>> Handle(GetFilterLoanApplicationFieldSurveyDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                "PaymentMethod",
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>(dataVm, data.Info, request.Page, request.Length)
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
