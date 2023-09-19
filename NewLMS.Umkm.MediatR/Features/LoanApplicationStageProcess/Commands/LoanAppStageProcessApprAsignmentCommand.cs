using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationStageProcess;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationStageProcess.Commands
{
    public class LoanAppStageProcessApprAsignmentCommand : LoanApplicationStageProcessRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanAppStageProcessApprAsignmentCommandHandler : IRequestHandler<LoanAppStageProcessApprAsignmentCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IMapper _mapper;

        public LoanAppStageProcessApprAsignmentCommandHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal, 
            IMapper mapper)
        {
            _appraisal = appraisal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppStageProcessApprAsignmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appraisalData = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId);
                if (appraisalData != null)
                {
                    appraisalData.StageId = LMSUMKMStages.AppraisalSurveyor.StageId;//Appr Surveyor
                    await _appraisal.UpdateAsync(appraisalData);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data Tidak Ditemukan, Gagal Proses Stage");
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
