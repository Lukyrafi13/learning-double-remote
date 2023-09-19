using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ApprChecklistReviews;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ApprChecklistReviews.Commands
{
    public class ApprChecklistReviewPutCommand : ApprChecklistReviewPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutApprChecklistReviewCommandHandler : IRequestHandler<ApprChecklistReviewPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprChecklistReview> _coll;
        private readonly IMapper _mapper;

        public PutApprChecklistReviewCommandHandler(IGenericRepositoryAsync<ApprChecklistReview> coll, IMapper mapper)

        {
            _coll = coll;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprChecklistReviewPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _coll.GetByIdAsync(request.ApprChecklistReviewGuid, "ApprChecklistReviewGuid");

                data.Yesno = request.Yesno;
                data.Remarks = request.Remarks;
                data.ModifiedDate = DateTime.Now;
                await _coll.UpdateAsync(data);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}
