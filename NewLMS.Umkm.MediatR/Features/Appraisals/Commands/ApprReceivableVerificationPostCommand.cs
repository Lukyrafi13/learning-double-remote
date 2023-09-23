using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalReceivable;
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

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands
{
    public class ApprReceivableVerificationPostCommand : ApprReceivableVerificationPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostApprReceivableVerificationCommandHandler : IRequestHandler<ApprReceivableVerificationPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprReceivableVerification> _appr;
        private readonly IMapper _mapper;

        public PostApprReceivableVerificationCommandHandler(IGenericRepositoryAsync<ApprReceivableVerification> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprReceivableVerificationPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataLand = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (dataLand == null)
                {
                    var apprEntity = new ApprReceivableVerification
                    {
                        ApprReceivableVerificationGuid = Guid.NewGuid(),
                        AppraisalGuid = request.AppraisalGuid,
                        ObjectType = request.ObjectType,
                        InspectionDate = request.InspectionDate,
                        Document = request.Document,
                        DocumentNo = request.DocumentNo,
                        Method = request.Method,
                        Population = request.Population,
                        VerificationResult = request.VerificationResult,
                        ObjectStatus = request.ObjectStatus,
                        VerificationBy = request.VerificationBy,
                        CollateralOwner = request.CollateralOwner,
                        Remarks = request.Remarks

                    };
                    await _appr.AddAsync(apprEntity);

                }
                else
                {

                    dataLand.ObjectType = request.ObjectType;
                    dataLand.InspectionDate = request.InspectionDate;

                    dataLand.ModifiedDate = DateTime.Now;
                    await _appr.UpdateAsync(dataLand);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
