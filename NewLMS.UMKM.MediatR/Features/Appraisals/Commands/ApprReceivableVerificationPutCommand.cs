using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalReceivable;
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

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands
{
    public class ApprReceivableVerificationPutCommand : ApprReceivableVerificationPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprReceivableVerificationPutCommandHandler : IRequestHandler<ApprReceivableVerificationPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprReceivableVerification> _appr;
        private readonly IMapper _mapper;

        public ApprReceivableVerificationPutCommandHandler(IGenericRepositoryAsync<ApprReceivableVerification> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprReceivableVerificationPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataLand = await _appr.GetByPredicate(x => x.AppraisalGuid == request.AppraisalGuid);
                if (dataLand != null)
                {
                    dataLand.ObjectType = request.ObjectType;
                    dataLand.InspectionDate = request.InspectionDate;
                    dataLand.Document = request.Document;
                    dataLand.DocumentNo = request.DocumentNo;
                    dataLand.Method = request.Method;
                    dataLand.Population = request.Population;
                    dataLand.VerificationResult = request.VerificationResult;
                    dataLand.Remarks = request.Remarks;
                    dataLand.ObjectStatus = request.ObjectStatus;
                    dataLand.VerificationBy = request.VerificationBy;
                    dataLand.CollateralOwner = request.CollateralOwner;
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
