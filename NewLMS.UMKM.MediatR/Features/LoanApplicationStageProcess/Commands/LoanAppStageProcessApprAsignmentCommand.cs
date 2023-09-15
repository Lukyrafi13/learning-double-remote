using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationStageProcess;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationStageProcess.Commands
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
                    appraisalData.StageId = Guid.Parse("453019B3-7950-4AE0-8387-2973E8C274B2");//Appr Surveyor
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
