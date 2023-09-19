using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ApprChecklistReviews;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ApprChecklistReviews.Queries
{
    public class GetByAppraisalQuery : IRequest<ServiceResponse<IEnumerable<ApprChecklistReviewResponse>>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetByAppraisalQueryHandler : IRequestHandler<GetByAppraisalQuery, ServiceResponse<IEnumerable<ApprChecklistReviewResponse>>>
    {
        private IGenericRepositoryAsync<ApprChecklistReview> _ApprChecklistReview;
        private IMapper _mapper;

        public GetByAppraisalQueryHandler(IGenericRepositoryAsync<ApprChecklistReview> ApprChecklistReview, IMapper mapper)
        {
            _ApprChecklistReview = ApprChecklistReview;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<ApprChecklistReviewResponse>>> Handle(GetByAppraisalQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
            {
                "LoanApplicationAppraisal"
            };
            var data = await _ApprChecklistReview.GetListByPredicate(x => x.AppraisalGuid == request.AppraisalGuid, includes);
            var dataVm = _mapper.Map<IEnumerable<ApprChecklistReviewResponse>>(data);

            return ServiceResponse<IEnumerable<ApprChecklistReviewResponse>>.ReturnResultWith200(dataVm);
        }
    }
}
