using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.ApprChecklistReviews;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.ApprChecklistReviews.Commands
{
    public class ApprChecklistReviewPostCommand : ApprChecklistReviewPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostApprChecklistReviewCommandHandler : IRequestHandler<ApprChecklistReviewPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprChecklistReview> _coll;
        private readonly IMapper _mapper;

        public PostApprChecklistReviewCommandHandler(IGenericRepositoryAsync<ApprChecklistReview> coll, IMapper mapper)

        {
            _coll = coll;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprChecklistReviewPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new ApprChecklistReview
                {
                    ApprChecklistReviewGuid = Guid.NewGuid(),
                    AppraisalGuid = request.AppraisalGuid,
                    Sequence = request.Sequence,
                    Description = request.Description,
                    Yesno = request.Yesno,
                    Remarks = request.Remarks

                };
                await _coll.AddAsync(entity);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}
