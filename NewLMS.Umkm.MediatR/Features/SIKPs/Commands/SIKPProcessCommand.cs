using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Enums;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.SIKP.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.SIKP.Interfaces;

namespace NewLMS.Umkm.MediatR.Features.SIKPs.SIKP
{
    public class SIKPProcessCommand : LoanApplicationProcessRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class SIKPProcessCommandHandler : IRequestHandler<SIKPProcessCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private IGenericRepositoryAsync<LoanApplicationStage> _loanApplicationStage;
        private IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private IGenericRepositoryAsync<LoanApplicationAppraisal> _loanApplicationAppraisal;
        private readonly ISIKPService _sikpService;
        private readonly UserContext _userContext;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public SIKPProcessCommandHandler(IMapper mapper, IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> sikp, ICurrentUserService currentUser, UserContext userContext, IGenericRepositoryAsync<LoanApplicationStage> loanApplicationStage, IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral, IGenericRepositoryAsync<LoanApplicationAppraisal> loanApplicationAppraisal, IGenericRepositoryAsync<SLIKRequest> slikRequest, IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, ISIKPService sikpService)
        {
            _mapper = mapper;
            _sikp = sikp;
            _currentUser = currentUser;
            _userContext = userContext;
            _loanApplicationStage = loanApplicationStage;
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplicationAppraisal = loanApplicationAppraisal;
            _slikRequest = slikRequest;
            _slikRequestDebtor = slikRequestDebtor;
            _sikpService = sikpService;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPProcessCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var sikp = await _sikp.GetByIdAsync(request.AppId, "Id", new string[] {
                    "LoanApplication.RfOwnerCategory",
                    "LoanApplication.Debtor",
                    "LoanApplication.DebtorCompany",
                    "SIKPRequest.RfSectorLBU3",
					"SIKPRequest.RfGender",
					"SIKPRequest.RfMarital",
					"SIKPRequest.RfEducation",
					"SIKPRequest.RfJob",
					"SIKPRequest.DebtorRfZipCode",
					"SIKPRequest.DebtorCompanyRfZipCode",
					"SIKPRequest.DebtorCompanyRfLinkage",
                    "SIKPResponse"
                }) ?? throw new NullReferenceException("Data SIKP tidak ditemukan.");
                var sikpRequest = sikp.SIKPRequest;

                if (sikp.RegistrationNumber == null)
                {
                    var sikpCount = await _sikp.GetCountByPredicate(x => x.CreatedDate.Year == DateTime.Now.Year && x.CreatedDate.Month == DateTime.Now.Month);
                    var sikpRegist = $"{sikp.LoanApplication.BranchId}/{sikpCount + 1:D4}/{sikp.LoanApplication.CreatedDate:MM/yy}";

                    sikp.RegistrationNumber = sikpRegist;
                    await _sikp.UpdateAsync(sikp);
                }

                PostCalonDebiturRequestModel req = new()
                {
                    nik = sikpRequest.DebtorNoIdentity,
                    nmr_registry = sikp.RegistrationNumber,
                    nama = sikpRequest.Fullname,
                    tgl_lahir = sikpRequest.DateOfBirth.ToString("ddMMyyyy"),
                    jns_kelamin = await _userContext.RfGenders.Where(x => x.GenderCode == sikpRequest.DebtorGenderId).Select(x => x.GenderCodeSIKP).FirstOrDefaultAsync(),
                    maritas_sts = await _userContext.RfMaritals.Where(x => x.MaritalCode == sikpRequest.DebtorMaritalStatusId).Select(x => x.MaritalCodeSKIP).FirstOrDefaultAsync(),
                    pendidikan = await _userContext.RfEducations.Where(x => x.EducationCode == sikpRequest.DebtorEducationId).Select(x => x.EducationCodeSIKP).FirstOrDefaultAsync(),
                    pekerjaan = await _userContext.RfJobs.Where(x => x.JobCode == sikpRequest.DebtorJobId).Select(x => x.JobCodeSIKP).FirstOrDefaultAsync(),
                    alamat = sikpRequest.DebtorAddress ?? "",
                    kode_kabkota = await _userContext.RfZipCodes.Where(x => x.Id == sikpRequest.DebtorZipCodeId).Select(x => x.KodeKabupaten).FirstOrDefaultAsync(),
                    kode_pos = sikpRequest.DebtorZipCode ?? "",
                    npwp = sikpRequest.DebtorNPWP?.Substring(0, 15) ?? "",
                    mulai_usaha = sikpRequest.DebtorCompanyEstablishmentDate?.ToString("ddMMyyyy") ?? "",
                    alamat_usaha = sikpRequest.DebtorCompanyAddress ?? "",
                    ijin_usaha = sikpRequest.DebtorCompanyPermit ?? "",
                    modal_usaha = sikpRequest.DebtorCompanyVentureCapital.ToString(),
                    jml_pekerja = sikpRequest.DebtorCompanyEmployee.ToString(),
                    jml_kredit = sikpRequest.DebtorCompanyCreditValue.ToString(),
                    is_linkage = sikpRequest.DebtorCompanyLinkageId ?? "",
                    linkage = sikpRequest.DebtorCompanyLinkageTypeId ?? "",
                    no_hp = sikpRequest.DebtorCompanyPhone ?? "",
                    uraian_agunan = sikpRequest.DebtorCompanyCollaterals ?? "",
                    is_subsidized = sikpRequest.DebtorCompanySubisdyStatus ? "1" : "0",
                    subsidi_sebelumnya = sikpRequest.DebtorCompanyPreviousSubsidy ?? "",
                };
                sikp.RegistrationNumber = req.nmr_registry;

                var sikpCheck = (await _sikpService.PostCalonDebitur(req))?.data;

                if (!(bool)sikp.SIKPResponse.Valid && sikpCheck.error)
                {
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, $"Data SIKP tidak valid, silahkan periksa kembali: {string.Join(", ", sikp.SIKPResponse?.ValidationMessage?.Split(","))}");
                }

                var loanApplicationCollaterals = await _loanApplicationCollateral.GetListByPredicate(x => x.LoanApplicationId == sikp.Id);
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

                // Create Appraisals
                foreach (LoanApplicationCollateral collateral in loanApplicationCollaterals)
                {
                    await _loanApplicationAppraisal.AddAsync(new LoanApplicationAppraisal
                    {
                        AppraisalId = Guid.NewGuid(),
                        LoanApplicationId = collateral.LoanApplicationId,
                        LoanApplicationCollateralId = collateral.Id,
                        StageId = UMKMConst.Stages["AppraisalAsignment"]
                    });
                }

                // Create SLIK
                var slikRequest = await GenerateSLIKRequest(sikp.LoanApplication);
                await _slikRequest.AddAsync(slikRequest);

                await _loanApplicationStage.AddAsync(loanApplicationStageSLIK);
                await _loanApplicationStage.AddAsync(loanApplicationStageAppraisal);

                sikp.Status = EnumSIKPStatus.Processed;
                await _sikp.UpdateAsync(sikp);
                await transaction.CommitAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }

        private async Task<SLIKRequest> GenerateSLIKRequest(LoanApplication loanApplication)
        {
            var slikRequest = await _slikRequest.GetByIdAsync(loanApplication.Id, "Id", new string[] { "SLIKRequestDebtors" });

            if (slikRequest != null)
            {
                var slikRequestDebtors = _slikRequestDebtor.GetListByPredicate(x => x.SLIKRequestId == slikRequest.Id);
            }
            else
            {
                slikRequest = new SLIKRequest()
                {
                    Id = loanApplication.Id,
                    BranchCode = loanApplication.BranchId,
                    StageId = UMKMConst.Stages["SLIKRequest"],
                    Status = EnumSLIKStatus.Draft
                };

                List<SLIKRequestDebtor> slikRequestDebtors = new()
                {
                    new SLIKRequestDebtor {
                        Id = Guid.NewGuid(),
                        SLIKRequestId = slikRequest.Id,
                        Fullname = loanApplication.RfOwnerCategory?.Code == "001" ? loanApplication.Debtor?.Fullname : loanApplication.DebtorCompany?.Name,
                        NPWP = loanApplication.RfOwnerCategory?.Code == "001" ? loanApplication.Debtor?.NPWP : loanApplication.DebtorCompany?.DebtorCompanyLegal?.NPWP,
                        SLIKDebtorType = loanApplication.OwnerCategoryId
                    }
                };

                slikRequest.SLIKRequestDebtors = slikRequestDebtors;
            }

            return slikRequest;
        }
    }
}

