using AutoMapper;
using MediatR;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.UMKM.Data.Constants;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SIKPs.SIKP
{
    public class SIKPProcessCommand : LoanApplicationProcessRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class SIKPProcessCommandHandler : IRequestHandler<SIKPProcessCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<NewLMS.UMKM.Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
        private IGenericRepositoryAsync<SIKPResponse> _sikpResponse;
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private IGenericRepositoryAsync<RfGender> _rfGender;
        private IGenericRepositoryAsync<RfJob> _rfJob;
        private IGenericRepositoryAsync<RfMarital> _rfMarital;
        private IGenericRepositoryAsync<RfEducation> _rfEducation;
        private IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private IGenericRepositoryAsync<RfLinkAge> _rfLinkage;
        private ISIKPService _sikpService;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public SIKPProcessCommandHandler(IMapper mapper, IGenericRepositoryAsync<NewLMS.UMKM.Data.Entities.SIKP> sikp, IGenericRepositoryAsync<SIKPRequest> sikpRequest, ISIKPService sikpService, IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IGenericRepositoryAsync<SIKPResponse> sikpResponse, IGenericRepositoryAsync<RfGender> rfGender, IGenericRepositoryAsync<RfJob> rfJob, IGenericRepositoryAsync<RfMarital> rfMarital, IGenericRepositoryAsync<RfEducation> rfEducation, IGenericRepositoryAsync<RfZipCode> rfZipCode, IGenericRepositoryAsync<RfLinkAge> rfLinkage, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _sikp = sikp;
            _sikpRequest = sikpRequest;
            _sikpService = sikpService;
            _rfSectorLBU3 = rfSectorLBU3;
            _sikpResponse = sikpResponse;
            _rfGender = rfGender;
            _rfJob = rfJob;
            _rfMarital = rfMarital;
            _rfEducation = rfEducation;
            _rfZipCode = rfZipCode;
            _rfLinkage = rfLinkage;
            _currentUser = currentUser;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPProcessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sikp = await _sikp.GetByIdAsync(request.AppId, "Id", new string[] { "LoanApplication" });
                var loanApplicationStageSLIK = new LoanApplicationStage
                {
                    Id = Guid.NewGuid(),
                    StageId = UMKMConst.Stages["SLIKRequest"],
                    OwnerRoleId = UMKMConst.Roles["AccountOfficerUMKM"],
                    OwnerUserId = Guid.Parse(_currentUser.Id),
                    LoanApplicationId = sikp.Id,
                    Processed = false,
                };
                var loanApplicationStageAppraisal = new LoanApplicationStage
                {
                    Id = Guid.NewGuid(),
                    StageId = UMKMConst.Stages["AppraisalAsignment"],
                    OwnerRoleId = UMKMConst.Roles["Supervisor"],
                    OwnerUserId = null,
                    LoanApplicationId = sikp.Id,
                    Processed = false,
                };
                var currentUser = _currentUser;
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}

