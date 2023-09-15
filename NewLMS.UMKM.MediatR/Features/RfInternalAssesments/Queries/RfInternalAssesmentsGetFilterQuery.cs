using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfInternalAssesments;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfInternalAssesments.Queries
{
    public class RfInternalAssesmentsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfInternalAssesmentsResponse>>>
    {
    }

    public class RfInternalAssesmentsGetFilterQueryHandler : IRequestHandler<RfInternalAssesmentsGetFilterQuery, PagedResponse<IEnumerable<RfInternalAssesmentsResponse>>>
    {
        private IGenericRepositoryAsync<User> _user;
        private IGenericRepositoryAsync<Appraisal> _appraisal;
        private readonly IMapper _mapper;

        public RfInternalAssesmentsGetFilterQueryHandler(
            IGenericRepositoryAsync<User> user, 
            IGenericRepositoryAsync<Appraisal> appraisal, 
            IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
            _appraisal = appraisal;
        }

        public async Task<PagedResponse<IEnumerable<RfInternalAssesmentsResponse>>> Handle(RfInternalAssesmentsGetFilterQuery request, CancellationToken cancellationToken)
        {
            //filter by stage Analyst CR
            var filters = request.Filters;
            filters.Add(new RequestFilterParameter()
            {
                Field = "idFungsi",
                ComparisonOperator = "=",
                Type = "string",
                Value = "1314",
            });

            request.Filters = filters;

            var data = await _user.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfInternalAssesmentsResponse>>(data.Results);
            foreach(var dVM in dataVm)
            {
                int loanAppApprInternalAssesmentCount = 0;
                var loanAppInternalAssesment = await _appraisal.GetListByPredicate(x => x.Estimator == dVM.UserId);
                if(loanAppInternalAssesment != null)
                {
                    loanAppApprInternalAssesmentCount = loanAppInternalAssesment.Count();
                }
                dVM.InternalAssesmentDataCount = loanAppApprInternalAssesmentCount;
            }
            return new PagedResponse<IEnumerable<RfInternalAssesmentsResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
