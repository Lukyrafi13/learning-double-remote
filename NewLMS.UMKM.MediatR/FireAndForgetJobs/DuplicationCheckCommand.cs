using AutoMapper;
using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.DuplicateLoanApplications;
using NewLMS.Umkm.Data.Dto.MSearch;
using NewLMS.Umkm.Domain.Dwh.Services;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Domain.Dwh.Entities;
using NewLMS.Umkm.Domain.Dwh.Context;
using NewLMS.Umkm.DomainDHN.Context;

namespace NewLMS.Umkm.MediatR.FireAndForgetJobs
{
    public interface IFireAndForgetDuplicationCheck
    {
        Task DuplicationCheck(Guid loanAppId);
    }

    public class FireAndForgetDuplicationCheck : IFireAndForgetDuplicationCheck
    {
        public readonly IDWHService _dwhService;
        public readonly IGenericRepositoryAsync<Debtor> _debtor;
        public readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        public readonly IGenericRepositoryAsync<MSearch> _mSearch;
        public readonly IGenericRepositoryDWHAsync<STG_CIF> _stgCIF;
        public readonly IGenericRepositoryAsync<LoanApplicationDuplication> _loanApplicationDuplication;
        public readonly DWHContext _dwhContext;
        public readonly IMapper _mapper;
        private readonly DHNContext _dhnContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FireAndForgetDuplicationCheck(IDWHService dwhService, IGenericRepositoryAsync<Debtor> debtor, IGenericRepositoryAsync<LoanApplication> loanApplication, IGenericRepositoryAsync<MSearch> mSearch, IGenericRepositoryDWHAsync<STG_CIF> stgCIF, DWHContext dwhContext, IGenericRepositoryAsync<LoanApplicationDuplication> loanApplicationDuplication, IMapper mapper, DHNContext dhnContext, IHostingEnvironment hostingEnvironment)
        {
            _dwhService = dwhService;
            _debtor = debtor;
            _loanApplication = loanApplication;
            _mSearch = mSearch;
            _stgCIF = stgCIF;
            _dwhContext = dwhContext;
            _mapper = mapper;
            _loanApplicationDuplication = loanApplicationDuplication;
            _dhnContext = dhnContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task DuplicationCheck(Guid loanAppId)
        {
            var loanApplicationIncludes = new string[] {
                    "RfStage",
                    "Debtor",
                    "DebtorCompany.DebtorCompanyLegal",
                    };
            var loanApplication = await _loanApplication.GetByIdAsync(loanAppId, "Id", loanApplicationIncludes) ?? throw new Exception("Loan Application not found.");
            var mSearch = await _mSearch.GetAllAsync();
            var duplicateInLMS = false;
            var duplicateInCore = false;
            var duplicateINDHN = false;
            List<MSearchResponse> SearchResultLMS = new();
            List<MSearchResponse> SearchResultCore = new();
            List<MSearchResponse> SearchResultDHN = new();
            List<MSearchResponse> SearchAgunan = new();

            #region LMS
            #region Fullname And Date Of Birth
            var IsDuplicateFirstNameAndDateOfBirthLMS = await _loanApplication.GetListByPredicate(x =>
            x.Debtor.Fullname == loanApplication.Debtor.Fullname
            && x.Debtor.DateOfBirth == loanApplication.Debtor.DateOfBirth
            && x.LoanApplicationId != loanApplication.LoanApplicationId
            , loanApplicationIncludes, true);
            #endregion

            #region No Identity
            var IsDuplicateNoIdentity = await _loanApplication.GetListByPredicate(x =>
            x.Debtor.NoIdentity == loanApplication.Debtor.NoIdentity
            && x.LoanApplicationId != loanApplication.LoanApplicationId
            , loanApplicationIncludes, true);
            #endregion
            if (IsDuplicateFirstNameAndDateOfBirthLMS.Count > 0 || IsDuplicateNoIdentity.Count > 0)
                duplicateInLMS = true;
            if (IsDuplicateFirstNameAndDateOfBirthLMS.Count > 0)
            {
                var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_LOS"
                && x.SearchId.Contains("i001_NM_DOB"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();

                foreach (var item in IsDuplicateFirstNameAndDateOfBirthLMS)
                {
                    msearch.ApplicationNo = item.LoanApplicationId;
                    msearch.Stage = item.RfStage.Code;
                    msearch.Branch = item.RfBookingBranch?.Code ?? item.RfBranch?.Code;
                    msearch.Cif = item?.Debtor?.CIF;
                    msearch.DateOfBirth = item?.Debtor?.DateOfBirth;
                    msearch.Fullname = item?.Debtor?.Fullname;
                    msearch.NoIdentity = item?.Debtor?.NoIdentity;
                    msearch.NPWP = item?.Debtor?.NPWP;
                    SearchResultLMS.Add(msearch);
                }
            }

            if (IsDuplicateNoIdentity.Count > 0)
            {
                var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_LOS"
                && x.SearchId.Contains("i003_ID"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();
                foreach (var item in IsDuplicateNoIdentity)
                {
                    msearch.ApplicationNo = item.LoanApplicationId;
                    msearch.Stage = item.RfStage.Code;
                    msearch.Branch = item.RfBookingBranch?.Code ?? item.RfBranch?.Code;
                    msearch.Cif = item?.Debtor?.CIF;
                    msearch.DateOfBirth = item?.Debtor?.DateOfBirth;
                    msearch.Fullname = item?.Debtor?.Fullname;
                    msearch.NoIdentity = item?.Debtor?.NoIdentity;
                    msearch.NPWP = item?.Debtor?.NPWP;
                    SearchResultLMS.Add(msearch);
                }
            }

            #endregion

            #region Core / DWH
            #region Fullname And Date Of Birth DWH
            var IsDuplicateFirstNameAndDateOfBirthDWH =
            await (from cif in _dwhContext.STG_CIF
                   join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                   from loan in joinedLoan.DefaultIfEmpty()
                   where
                    cif.CUST_FULL_NAME == loanApplication.Debtor.Fullname
                    && cif.BIRTH_DATE.Date == loanApplication.Debtor.DateOfBirth
                   select new
                   {
                       cif.CIF,
                       cif.BRANCH,
                       cif.CUSTOMER_TYPE,
                       cif.CUST_FULL_NAME,
                       cif.ID_NUMBER,
                       cif.NPWP,
                       cif.BIRTH_DATE,
                       DEAL_TYPE = loan != null ? loan.DEAL_TYPE : null,
                       PLAFOND = loan != null ? loan.PLAFOND : 0,
                       OUTSTANDING = loan != null ? loan.OUTSTANDING : 0,
                   }
                   ).ToListAsync();

            #endregion

            #region NPWP COMP
            var compNPWP = loanApplication.DebtorCompany?.DebtorCompanyLegal?.NPWP ?? "";
            var IsDuplicateNPWPComp = await (from cif in _dwhContext.STG_CIF
                                             join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                                             from loan in joinedLoan.DefaultIfEmpty()
                                             where
                                                 !string.IsNullOrEmpty(compNPWP) && cif.NPWP == compNPWP
                                             select new
                                             {
                                                 cif.CIF,
                                                 cif.BRANCH,
                                                 cif.CUSTOMER_TYPE,
                                                 cif.CUST_FULL_NAME,
                                                 cif.ID_NUMBER,
                                                 cif.NPWP,
                                                 cif.BIRTH_DATE,
                                                 DEAL_TYPE = loan != null ? loan.DEAL_TYPE : null,
                                                 DEAL_REF = loan != null ? loan.DEAL_REF : null,
                                                 PLAFOND = loan != null ? loan.PLAFOND : 0,
                                                 OUTSTANDING = loan != null ? loan.OUTSTANDING : 0,
                                             }).ToListAsync();
            #endregion

            #region No Identity
            var IsDuplicateNoIdentityDWH = await (from cif in _dwhContext.STG_CIF
                                                  join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS)
                                                  where
                                                   cif.ID_NUMBER == loanApplication.Debtor.NoIdentity
                                                  select new
                                                  {
                                                      cif.CIF,
                                                      cif.BRANCH,
                                                      cif.CUSTOMER_TYPE,
                                                      cif.CUST_FULL_NAME,
                                                      cif.ID_NUMBER,
                                                      cif.NPWP,
                                                      cif.BIRTH_DATE,
                                                      DEAL_TYPE = loan != null ? loan.DEAL_TYPE : null,
                                                      PLAFOND = loan != null ? loan.PLAFOND : 0,
                                                      OUTSTANDING = loan != null ? loan.OUTSTANDING : 0,
                                                  }
                   ).ToListAsync();
            if (IsDuplicateFirstNameAndDateOfBirthDWH.Count > 0 || IsDuplicateNoIdentityDWH.Count > 0)
                duplicateInCore = true;
            if (IsDuplicateFirstNameAndDateOfBirthDWH.Count > 0)
            {
                var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_CORE"
                && x.SearchId.Contains("c001_NM_DOB"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();

                foreach (var item in IsDuplicateFirstNameAndDateOfBirthDWH)
                {
                    msearch.Branch = item.BRANCH;
                    msearch.Cif = item.CIF;
                    msearch.DateOfBirth = item.BIRTH_DATE;
                    msearch.Fullname = item.CUST_FULL_NAME;
                    msearch.Outstanding = item.OUTSTANDING;
                    msearch.LoanType = item.DEAL_TYPE;
                    msearch.NoIdentity = item.ID_NUMBER;
                    msearch.NPWP = item.NPWP;
                    msearch.CustType = item.CUSTOMER_TYPE;
                    msearch.Limit = item.PLAFOND;
                    SearchResultCore.Add(msearch);
                }
            }


            if (IsDuplicateNoIdentityDWH.Count > 0)
            {
                var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_CORE"
                && x.SearchId.Contains("c003_ID"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();

                foreach (var item in IsDuplicateNoIdentityDWH)
                {
                    msearch.Branch = item.BRANCH;
                    msearch.Cif = item.CIF;
                    msearch.DateOfBirth = item.BIRTH_DATE;
                    msearch.Fullname = item.CUST_FULL_NAME.Trim();
                    msearch.Outstanding = item.OUTSTANDING;
                    msearch.LoanType = item.DEAL_TYPE;
                    msearch.NoIdentity = item.ID_NUMBER.Trim();
                    msearch.NPWP = item.NPWP.Trim();
                    msearch.CustType = item.CUSTOMER_TYPE;
                    msearch.Limit = item.PLAFOND;
                    SearchResultCore.Add(msearch);
                }
            }

            if (IsDuplicateNPWPComp.Count > 0)
            {
                var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_CORE"
                && x.SearchId.Contains("c004_NPWP"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();

                foreach (var item in IsDuplicateFirstNameAndDateOfBirthDWH)
                {
                    msearch.Branch = item.BRANCH;
                    msearch.Cif = item.CIF;
                    msearch.DateOfBirth = item.BIRTH_DATE;
                    msearch.Fullname = item.CUST_FULL_NAME;
                    msearch.Outstanding = item.OUTSTANDING;
                    msearch.LoanType = item.DEAL_TYPE;
                    msearch.NoIdentity = item.ID_NUMBER;
                    //msearch.NPWP = item.NPWP;
                    msearch.CustType = item.CUSTOMER_TYPE;
                    msearch.Limit = item.PLAFOND;
                    SearchResultCore.Add(msearch);
                    SearchResultLMS.Add(msearch);
                }
            }
            #endregion
            #endregion

            #region DHN
            #region Fullname and datebirth
            if (_hostingEnvironment.IsProduction())
            {
                var debtorDob = loanApplication.Debtor?.DateOfBirth ?? DateTime.MaxValue;
                var IsDuplicateFirstNameAndDateOfBirthDHN = await _dhnContext.DHNLists.Where(x => x.CustomerName.ToLower() == loanApplication.Debtor.Fullname
                && x.BirthDate == debtorDob.ToString("ddMMyyyy")).ToListAsync();
                var IsDuplicateNoIdentityDHN = await _dhnContext.DHNLists.Where(x => x.IdNumber == loanApplication.Debtor.NoIdentity).ToListAsync();
                if (IsDuplicateFirstNameAndDateOfBirthDHN.Count > 0 || IsDuplicateNoIdentityDHN.Count > 0)
                    duplicateINDHN = true;
                if (IsDuplicateFirstNameAndDateOfBirthDHN.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "BLACKLIST"
                    && x.SearchId.Contains("b001_NM_DOB"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateFirstNameAndDateOfBirthDHN)
                    {
                        msearch.Branch = "-";
                        msearch.Cif = "-";
                        msearch.DateOfBirth = DateTime.ParseExact(item.BirthDate, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.Fullname = item.CustomerName;
                        msearch.Outstanding = 0;
                        msearch.LoanType = "-";
                        msearch.NoIdentity = item.IdNumber;
                        msearch.NPWP = item.NPWP;
                        msearch.CustType = "-";
                        msearch.Limit = 0;
                        msearch.BankName = item.BankName;
                        msearch.Expired = DateTime.ParseExact(item.Expired, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.ReferenceNo = item.ReferenceNo;
                        SearchResultDHN.Add(msearch);
                    }
                }
                if (IsDuplicateNoIdentityDHN.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "BLACKLIST"
                    && x.SearchId.Contains("b003_ID"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateNoIdentityDHN)
                    {
                        msearch.Branch = "-";
                        msearch.Cif = "-";
                        msearch.DateOfBirth = DateTime.ParseExact(item.BirthDate, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.Fullname = item.CustomerName;
                        msearch.Outstanding = 0;
                        msearch.LoanType = "-";
                        msearch.NoIdentity = item.IdNumber;
                        msearch.NPWP = item.NPWP;
                        msearch.CustType = "-";
                        msearch.Limit = 0;
                        msearch.BankName = item.BankName;
                        msearch.Expired = DateTime.ParseExact(item.Expired, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.ReferenceNo = item.ReferenceNo;
                        SearchResultDHN.Add(msearch);
                    }
                }
            }


            #endregion
            #endregion
            DuplicateLoanApplicationResponse duplicateLoanApplication = new()
            {
                Internal = new DuplicateLoanApplicationLMSResponse
                {
                    IsDuplicate = duplicateInLMS,
                    MSearch = SearchResultLMS
                },
                Core = new DuplicateLoanApplicationLMSResponse
                {
                    IsDuplicate = duplicateInCore,
                    MSearch = SearchResultCore
                },
                DHN = new DuplicateLoanApplicationLMSResponse
                {
                    IsDuplicate = duplicateINDHN,
                    MSearch = SearchResultDHN
                }
            };
            var lmsDups = _mapper.Map<List<LoanApplicationDuplication>>(SearchResultLMS);
            var coreDups = _mapper.Map<List<LoanApplicationDuplication>>(SearchResultCore);
            var dhnDups = _mapper.Map<List<LoanApplicationDuplication>>(SearchResultDHN);

            foreach (LoanApplicationDuplication lmsDup in lmsDups)
            {
                lmsDup.LoanApplicationGuid = loanAppId;
            }

            foreach (LoanApplicationDuplication coreDup in coreDups)
            {
                coreDup.LoanApplicationGuid = loanAppId;
            }

            foreach (LoanApplicationDuplication dhndup in dhnDups)
            {
                dhndup.LoanApplicationGuid = loanAppId;
            }

            await _loanApplicationDuplication.AddRangeAsync(lmsDups);
            await _loanApplicationDuplication.AddRangeAsync(coreDups);
            await _loanApplicationDuplication.AddRangeAsync(dhnDups);
        }
    }
}