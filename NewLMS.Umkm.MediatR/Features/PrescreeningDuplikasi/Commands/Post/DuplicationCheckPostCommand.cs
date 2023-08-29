using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.DomainDHN.Context;
using NewLMS.Umkm.Domain.Dwh.Context;
using NewLMS.Umkm.Domain.Dwh.Services;
using NewLMS.Umkm.Data;
using static NewLMS.Umkm.MediatR.Features.Globals;
using NewLMS.Umkm.Data.Dto.MSearchs;
using NewLMS.Umkm.Data.Dto.SlikRequestDuplikasis;
using MediatR;
using NewLMS.Umkm.Helper;
using System.Threading;
using Org.BouncyCastle.Ocsp;
using System.Net;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Domain.Dwh.Entities;
using DocumentFormat.OpenXml.Bibliography;
using NewLMS.Umkm.DomainDHN.Entities;

namespace NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Commands
{
    public class DuplicationCheckPostCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid SlikRequestId {get; set;}
    }
    public class DuplicationCheckPostCommandHandler : IRequestHandler<DuplicationCheckPostCommand, ServiceResponse<Unit>>
    {
        public readonly IDWHService _dwhService;
        public readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        public readonly IGenericRepositoryAsync<SlikRequest> _slikRequest;
        public readonly IGenericRepositoryAsync<SlikRequestObject> _slikRequestObject;
        public readonly IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        public readonly IGenericRepositoryAsync<App> _loanApplication;
        public readonly IGenericRepositoryAsync<MSearch> _mSearch;
        public readonly IGenericRepositoryDWHAsync<STG_CIF> _stgCIF;
        public readonly IGenericRepositoryDWHAsync<COLLATERAL> _collateral;
        public readonly IGenericRepositoryDWHAsync<PH_GABUNGAN> _phgabungan;
        public readonly IGenericRepositoryAsync<SlikRequestDuplikasi> _loanApplicationDuplication;
        public readonly DWHContext _dwhContext;
        public readonly IMapper _mapper;
        private readonly UserContext _userContext;
        private readonly DHNContext _dhnContext;

        public DuplicationCheckPostCommandHandler(
            IDWHService dwhService,
            IGenericRepositoryAsync<App> loanApplication,
            IGenericRepositoryAsync<Prescreening> Prescreening,
            IGenericRepositoryAsync<SlikRequest> slikRequest,
            IGenericRepositoryAsync<SlikRequestObject> slikRequestObject,
            IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi,
            DWHContext dwhContext,
            IGenericRepositoryAsync<MSearch> mSearch,
            IGenericRepositoryDWHAsync<STG_CIF>stgCIF,
            IGenericRepositoryDWHAsync<COLLATERAL>collateral,
            IGenericRepositoryDWHAsync<PH_GABUNGAN>ph_gabungan,
            IGenericRepositoryAsync<SlikRequestDuplikasi> loanApplicationDuplication,
            IMapper mapper,
            UserContext userContext,
            DHNContext dhnContext)
        {
            _dwhService = dwhService;
            _loanApplication = loanApplication;
            _Prescreening = Prescreening;
            _slikRequest = slikRequest;
            _slikRequestObject = slikRequestObject;
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mSearch = mSearch;
            _stgCIF = stgCIF;
            _collateral = collateral;
            _phgabungan = ph_gabungan;
            _dwhContext = dwhContext;
            _mapper = mapper;
            _loanApplicationDuplication = loanApplicationDuplication;
            _dhnContext = dhnContext;
            _userContext = userContext;
        }
        public static string RemoveExcessWhitespace(string input)
        {
            // Split the input by whitespace characters and filter out empty entries
            string[] words = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Join the words back together with a single space separator
            string result = string.Join(" ", words);

            return result;
        }

        public async Task<ServiceResponse<Unit>> Handle(DuplicationCheckPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<MSearchResponse> SearchResultLMS = new List<MSearchResponse>();
                List<MSearchResponse> SearchResultCore = new List<MSearchResponse>();
                List<MSearchResponse> SearchResultDHN = new List<MSearchResponse>();
                List<MSearchResponse> SearchResultCollateral = new List<MSearchResponse>();

                List<DuplicateLMS> IsDuplicateFirstNameAndDateOfBirth1 = new List<DuplicateLMS>();
                List<DuplicateLMS> IsDuplicateLastNameAndDateOfBirth1 = new List<DuplicateLMS>();
                List<DuplicateLMS> IsDuplicateNoIdentity1 = new List<DuplicateLMS>();
                List<DuplicateLMS> IsDuplicateCompanyNameAndInitialDate1 = new List<DuplicateLMS>();
                List<DuplicateLMS> IsDuplicateNoNPWP1 = new List<DuplicateLMS>();
                List<DuplicateLMS> IsDuplicateNoNPWPCompany1 = new List<DuplicateLMS>();

                var duplicateInLMS = false;
                var duplicateInCore = false;
                var duplicateINDHN = false;
                var duplicateINAgunan = false;
                var duplicateINHapusBuku = false;

                var mSearch = await _mSearch.GetAllAsync();

                var SlikRequest = await _slikRequest.GetByIdAsync(request.SlikRequestId, "Id", new string[] {
                    "SlikRequestObjects",
                    "App",
                    "App.TipeDebitur",
                }) ?? throw new Exception("Prescreening Application not found.");

                var includes = new string[]
                {
                    "BookingOffice",
                    "TipeDebitur",
                    "Prospect",
                    "Prospect.Stage",
                };

                var SlikIndividual = SlikRequest.SlikRequestObjects.Where(x => x.SlikObjectTypeId == 1 && (x.Automatic ?? false)).ToList();
                var SlikCompany = SlikRequest.SlikRequestObjects.Where(x => x.SlikObjectTypeId == 2 && (x.Automatic ?? false)).ToList();

                var cifIndividual = await _stgCIF.GetListByPredicate(x=> SlikIndividual.Select(y=> y.NoIdentity).ToList().Contains(x.ID_NUMBER));
                var cifCompany = await _stgCIF.GetListByPredicate(x=> SlikCompany.Select(y=> y.NoIdentity).ToList().Contains(x.ID_NUMBER));

                #region LMS
                #region Fullname And Date Of Birth
                //TODO : Add criteria stage when column is exists (Robby)
                var IsDuplicateFirstNameAndDateOfBirthLoanApp = await _loanApplication.GetListByPredicate(x =>
                SlikIndividual.Select(x => x.Fullname).ToList().Contains(x.NamaCustomer) &&
                x.Id != SlikRequest.App.Id &&
                x.TipeDebitur.OwnCode == "01" &&
                x.Prospect.Stage.GroupStage >= 2
                //&& x.CreatedBy != loanApplication.CreatedBy
                , includes, true);

                foreach (var item in IsDuplicateFirstNameAndDateOfBirthLoanApp)
                {
                    // Date validation
                    if (SlikIndividual.FirstOrDefault(x=> x.Fullname == item.NamaCustomer)?.DateOfBirth != item.TanggalLahir){
                        continue;
                    }

                    // Add the valid data to list
                    IsDuplicateFirstNameAndDateOfBirth1.Add(new DuplicateLMS
                    {
                        LoanApplicationGuid = item.Id,
                        LoanApplicationId = item.AplikasiId,
                        Stage = item.Prospect.Stage.Code,
                        BranchId = item.BookingOffice?.Code,
                        CIF = cifIndividual.FirstOrDefault(x=>RemoveExcessWhitespace(x.CUST_FULL_NAME) == item.NamaCustomer)?.CIF??"-",
                        DateOfBirth = item?.TanggalLahir,
                        FullName = item?.NamaCustomer,
                        NoIdentity = item?.NomorKTP,
                        NPWP = item?.NPWP
                    });
                }

                
                #region No Identity
                //TODO : Add criteria stage when column is exists (Robby)

                var IsDuplicateNoIdentityLoanApp = await _loanApplication.GetListByPredicate(x =>
                SlikIndividual.Select(x => x.NoIdentity).ToList().Contains(x.NomorKTP) &&
                x.Id != SlikRequest.App.Id &&
                x.TipeDebitur.OwnCode == "01" &&
                x.Prospect.Stage.GroupStage >= 2
                , includes, true);

                foreach (var item in IsDuplicateNoIdentityLoanApp)
                {
                    IsDuplicateNoIdentity1.Add(new DuplicateLMS
                    {
                        LoanApplicationGuid = item.Id,
                        LoanApplicationId = item.AplikasiId,
                        Stage = item.Prospect.Stage.Code,
                        BranchId = item.BookingOffice?.Code,
                        CIF = cifIndividual.FirstOrDefault(x=>RemoveExcessWhitespace(x.ID_NUMBER) == item.NomorKTP)?.CIF??"-",
                        DateOfBirth = item?.TanggalLahir,
                        FullName = item?.NamaCustomer,
                        NoIdentity = item?.NomorKTP,
                        NPWP = item?.NPWP
                    });
                }

                #endregion
                #region No NPWP

                var isDuplicateNoNPWP = await _loanApplication.GetListByPredicate(x =>
                SlikIndividual.Select(x => x.NPWP).ToList().Contains(x.NPWP) &&
                x.Id != SlikRequest.App.Id &&
                x.TipeDebitur.OwnCode == "01" &&
                x.Prospect.Stage.GroupStage >= 2
                , includes, true);

                foreach (var item in isDuplicateNoNPWP)
                {
                    if (item.NPWP == ""){
                        continue;
                    }
                    IsDuplicateNoNPWP1.Add(new DuplicateLMS
                    {
                        LoanApplicationGuid = item.Id,
                        LoanApplicationId = item.AplikasiId,
                        Stage = item.Prospect.Stage.Code,
                        BranchId = item.BookingOffice?.Code,
                        CIF = cifIndividual.FirstOrDefault(x=>RemoveExcessWhitespace(x.NPWP) == item.NPWP)?.CIF??"-",
                        DateOfBirth = item?.TanggalLahir,
                        FullName = item?.NamaCustomer,
                        NoIdentity = item?.NomorKTP,
                        NPWP = item?.NPWP
                    });
                }

                #endregion
                #region No NPWP Company
                
                var isDuplicateNoNPWPCompany = await _loanApplication.GetListByPredicate(x =>
                SlikCompany.Select(x => x.NPWP).ToList().Contains(x.NPWP) &&
                x.Id != SlikRequest.App.Id &&
                x.TipeDebitur.OwnCode != "01" &&
                x.Prospect.Stage.GroupStage >= 2
                , includes, true);
                foreach (var item in isDuplicateNoNPWPCompany)
                {

                    IsDuplicateNoNPWPCompany1.Add(new DuplicateLMS
                    {
                        LoanApplicationGuid = item.Id,
                        LoanApplicationId = item.AplikasiId,
                        Stage = item.Prospect.Stage.Code,
                        BranchId = item.BookingOffice?.Code,
                        CIF = cifCompany.FirstOrDefault(x=>RemoveExcessWhitespace(x.NPWP) == item.NamaCustomer)?.CIF??"-",
                        DateOfBirth = item?.TanggalLahir,
                        FullName = item?.NamaCustomer,
                        NoIdentity = item?.NomorKTP,
                        NPWP = item?.NPWP
                    });
                }

                #endregion
                #region Company name and Initial date
                
                var isDuplicateCompanyNameAndInitialDate = await _loanApplication.GetListByPredicate(x =>
                    SlikCompany.Select(x => x.Fullname).ToList().Contains(x.NamaCustomer) &&
                    x.Id != SlikRequest.App.Id &&
                    x.TipeDebitur.OwnCode != "01" &&
                    x.Prospect.Stage.GroupStage >= 2, includes, true
                );
                foreach (var item in isDuplicateCompanyNameAndInitialDate)
                {
                    // Date validation
                    if (SlikCompany.FirstOrDefault(x=> x.Fullname == item.NamaCustomer)?.DateOfBirth != item.TanggalAktaPendirian){
                        continue;
                    }
                    
                    IsDuplicateCompanyNameAndInitialDate1.Add(new DuplicateLMS
                    {
                        LoanApplicationGuid = item.Id,
                        LoanApplicationId = item.AplikasiId,
                        Stage = item.Prospect.Stage.Code,
                        BranchId = item.BookingOffice?.Code,
                        CIF = cifCompany.FirstOrDefault(x=>RemoveExcessWhitespace(x.CUST_FULL_NAME) == item.NamaCustomer)?.CIF??"-",
                        DateOfBirth = item?.TanggalLahir,
                        FullName = item?.NamaCustomer,
                        NoIdentity = item?.NomorKTP,
                        NPWP = item?.NPWP
                    });
                }


                #endregion

                if (IsDuplicateFirstNameAndDateOfBirth1.Count > 0 ||
                    IsDuplicateLastNameAndDateOfBirth1.Count > 0 ||
                    IsDuplicateNoIdentity1.Count > 0 ||
                    IsDuplicateNoNPWP1.Count > 0 ||
                    IsDuplicateCompanyNameAndInitialDate1.Count > 0 ||
                    IsDuplicateNoNPWPCompany1.Count > 0
                    )
                    duplicateInLMS = true;
                if (IsDuplicateFirstNameAndDateOfBirth1.Count > 0)
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

                    foreach (var item in IsDuplicateFirstNameAndDateOfBirth1)
                    {

                        msearch.AplikasiId = item.LoanApplicationId;
                        msearch.Stage = item.Stage;
                        msearch.Branch = item.BranchId;
                        msearch.Cif = item?.CIF;
                        msearch.DateOfBirth = item?.DateOfBirth;
                        msearch.Fullname = item?.FullName;
                        msearch.NoIdentity = item?.NoIdentity;
                        msearch.Npwp = item?.NPWP;
                        SearchResultLMS.Add(msearch);
                    }
                }

                if (IsDuplicateNoIdentity1.Count > 0)
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
                    foreach (var item in IsDuplicateNoIdentity1)
                    {

                        msearch.AplikasiId = item.LoanApplicationId;
                        msearch.Stage = item.Stage;
                        msearch.Branch = item.BranchId;
                        msearch.Cif = item?.CIF;
                        msearch.DateOfBirth = item?.DateOfBirth;
                        msearch.Fullname = item?.FullName;
                        msearch.NoIdentity = item?.NoIdentity;
                        msearch.Npwp = item?.NPWP;
                        SearchResultLMS.Add(msearch);
                    }
                }

                if (IsDuplicateNoNPWP1.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "DEDUP_LOS"
                    && x.SearchId.Contains("i004_NPWP"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateNoNPWP1)
                    {

                        msearch.AplikasiId = item.LoanApplicationId;
                        msearch.Stage = item.Stage;
                        msearch.Branch = item.BranchId;
                        msearch.Cif = item?.CIF;
                        msearch.DateOfBirth = item?.DateOfBirth;
                        msearch.Fullname = item?.FullName;
                        msearch.NoIdentity = item?.NoIdentity;
                        msearch.Npwp = item?.NPWP;
                        SearchResultLMS.Add(msearch);
                    }
                }

                if (IsDuplicateCompanyNameAndInitialDate1.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "DEDUP_LOS"
                    && x.SearchId.Contains("i005_NM_ESTDATE"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateCompanyNameAndInitialDate1)
                    {
                        msearch.AplikasiId = item.LoanApplicationId;
                        msearch.Stage = item.Stage;
                        msearch.Branch = item.BranchId;
                        msearch.Cif = item?.CIF;
                        msearch.DateOfBirth = item?.DateOfBirth;
                        msearch.Fullname = item?.FullName;
                        msearch.NoIdentity = item?.NoIdentity;
                        msearch.Npwp = item?.NPWP;
                        SearchResultLMS.Add(msearch);
                    }
                }
                if (IsDuplicateNoNPWPCompany1.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "DEDUP_LOS"
                    && x.SearchId.Contains("i006_COMPNPWP"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateNoNPWPCompany1)
                    {
                        msearch.AplikasiId = item.LoanApplicationId;
                        msearch.Stage = item.Stage;
                        msearch.Branch = item.BranchId;
                        msearch.Cif = item?.CIF;
                        msearch.DateOfBirth = item?.DateOfBirth;
                        msearch.Fullname = item?.FullName;
                        msearch.NoIdentity = item?.NoIdentity;
                        msearch.Npwp = item?.NPWP;
                        SearchResultLMS.Add(msearch);
                    }
                }
                #endregion
                #endregion

                #region Core / DWH
                #region Fullname And Date Of Birth DWH
                // TODO : Add criteria stage when column is exists (Robby)
                var IsDuplicateFirstNameAndDateOfBirthDWH =
                await (from cif in _dwhContext.STG_CIF
                       join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                       from loan in joinedLoan.DefaultIfEmpty()
                       where (
                            SlikIndividual.Select(x => x.Fullname).ToList().Contains(cif.CUST_FULL_NAME)
                        )
                        && SlikRequest.App.TipeDebitur.OwnCode == "01"
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
                #region CompanyName and EST date DWH

                var isDuplicateCompanyNameAndESTDateDWH =
                await (from cif in _dwhContext.STG_CIF
                       join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                       from loan in joinedLoan.DefaultIfEmpty()
                       where
                       (
                         cif.CUSTOMER_TYPE == "CO" &&
                         cif.CUST_FULL_NAME == SlikRequest.App.NamaCustomer &&
                         cif.BIRTH_DATE == SlikRequest.App.TanggalAktaPendirian
                       )
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
                #region No Identity DWH
                //TODO : Add criteria stage when column is exists (Robby)
                var IsDuplicateNoIdentityDWH = await (from cif in _dwhContext.STG_CIF
                                                      join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                                                      from loan in joinedLoan.DefaultIfEmpty()
                                                      where
                                                       cif.ID_NUMBER.Replace(" ", "") == SlikRequest.App.NomorKTP
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
                #region No NPWP Company DWH
                var isDuplicateNoNPWPCompanyDWH =
                await (from cif in _dwhContext.STG_CIF
                       join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                       from loan in joinedLoan.DefaultIfEmpty()
                       where
                       (
                        cif.CUSTOMER_TYPE == "CO" &&
                        cif.ID_NUMBER.Replace(" ", "") == SlikRequest.App.NPWP


                       )
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

                if (IsDuplicateFirstNameAndDateOfBirthDWH.Count > 0 ||
                    IsDuplicateNoIdentityDWH.Count > 0 ||
                    isDuplicateCompanyNameAndESTDateDWH.Count > 0 ||
                    isDuplicateNoNPWPCompanyDWH.Count > 0
                    )
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
                        // Date validation
                        if (SlikIndividual.FirstOrDefault(x=> x.Fullname == item.CUST_FULL_NAME)?.DateOfBirth != item.BIRTH_DATE){
                            continue;
                        }

                        msearch.Branch = item.BRANCH;
                        msearch.Cif = item.CIF;
                        msearch.DateOfBirth = item.BIRTH_DATE;
                        msearch.Fullname = item.CUST_FULL_NAME;
                        msearch.Outstanding = item.OUTSTANDING;
                        msearch.LoanType = item.DEAL_TYPE;
                        msearch.NoIdentity = item.ID_NUMBER;
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = item.CUSTOMER_TYPE;
                        msearch.Limit = item.PLAFOND;
                        SearchResultCore.Add(msearch);
                    }
                }

                if (isDuplicateCompanyNameAndESTDateDWH.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "DEDUP_CORE"
                    && x.SearchId.Contains("c002_NM_DOB"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in isDuplicateCompanyNameAndESTDateDWH)
                    {
                        msearch.Branch = item.BRANCH;
                        msearch.Cif = item.CIF;
                        msearch.DateOfBirth = item.BIRTH_DATE;
                        msearch.Fullname = item.CUST_FULL_NAME;
                        msearch.Outstanding = item.OUTSTANDING;
                        msearch.LoanType = item.DEAL_TYPE;
                        msearch.NoIdentity = item.ID_NUMBER;
                        msearch.Npwp = item.NPWP;
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
                        msearch.Npwp = item.NPWP.Trim();
                        msearch.CustType = item.CUSTOMER_TYPE;
                        msearch.Limit = item.PLAFOND;
                        SearchResultCore.Add(msearch);
                    }
                }

                if (isDuplicateNoNPWPCompany.Count > 0)
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

                    foreach (var item in isDuplicateNoNPWPCompanyDWH)
                    {
                        msearch.Branch = item.BRANCH;
                        msearch.Cif = item.CIF;
                        msearch.DateOfBirth = item.BIRTH_DATE;
                        msearch.Fullname = item.CUST_FULL_NAME;
                        msearch.Outstanding = item.OUTSTANDING;
                        msearch.LoanType = item.DEAL_TYPE;
                        msearch.NoIdentity = item.ID_NUMBER;
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = item.CUSTOMER_TYPE;
                        msearch.Limit = item.PLAFOND;
                        SearchResultCore.Add(msearch);
                    }
                }
                #endregion
                #endregion

                #region DWH / COLLATERAL
                #region Fullname And Date Of Birth DWH Coll

                var isDuplicateFirstNameAndDateOfBirthDWHColl =
                await (from coll in _dwhContext.COLLATERAL
                       join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(coll.CIF_MNEMONIC, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                       from loan in joinedLoan.DefaultIfEmpty()
                       join cif in _dwhContext.STG_CIF on EF.Functions.Collate(coll.CIF_MNEMONIC, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedCif
                       from cif in joinedCif.DefaultIfEmpty()
                       where
                        // coll.COLLATERAL_REF == " " &&
                        cif.NPWP == SlikRequest.App.NPWP
                       // coll.
                       select new
                       {
                           coll.CIF_MNEMONIC,
                           // hbk.CIF,
                           cif.BRANCH,
                           cif.CUSTOMER_TYPE,
                           cif.CUST_FULL_NAME,
                           cif.ID_NUMBER,
                           cif.NPWP,
                           cif.BIRTH_DATE,
                           DEAL_TYPE = loan != null ? loan.DEAL_TYPE : null,
                           PLAFOND = loan != null ? loan.PLAFOND : 0,
                           OUTSTANDING = loan != null ? loan.OUTSTANDING : 0,
                       }).ToListAsync();

                if (isDuplicateFirstNameAndDateOfBirthDWHColl.Count > 0)
                {
                    duplicateINAgunan = true;

                    var msearch = mSearch.Where(x =>
                    x.SearchType == "DEDUP_COLLATERAL"
                    && x.SearchId.Contains("l001_ZIP_CER"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in isDuplicateFirstNameAndDateOfBirthDWHColl)
                    {
                        msearch.Branch = item?.BRANCH;
                        msearch.Cif = item?.CIF_MNEMONIC;
                        msearch.DateOfBirth = item?.BIRTH_DATE;
                        msearch.Fullname = item?.CUST_FULL_NAME;
                        msearch.Outstanding = item.OUTSTANDING;
                        msearch.LoanType = item?.DEAL_TYPE;
                        msearch.NoIdentity = item?.ID_NUMBER;
                        msearch.Npwp = item?.NPWP;
                        msearch.CustType = item?.CUSTOMER_TYPE;
                        msearch.Limit = item.PLAFOND;
                        SearchResultCollateral.Add(msearch);
                    }
                }
                #endregion
                #endregion

                #region DWH / Hapus Buku
                #region Fullname and Date of Birth
                var isDuplicateNameAndDoBDWHHapusBuku =
                await (from hbk in _dwhContext.PH_GABUNGAN
                       join loan in _dwhContext.STG_LOAN on EF.Functions.Collate(hbk.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(loan.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedLoan
                       from loan in joinedLoan.DefaultIfEmpty()
                       join cif in _dwhContext.STG_CIF on EF.Functions.Collate(hbk.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) equals EF.Functions.Collate(cif.CIF, CommonConstant.SQLLatin1GeneralCP1CSAS) into joinedcif
                       from cif in joinedcif.DefaultIfEmpty()
                       where
                        hbk.NPWP == SlikRequest.App.NPWP
                       //  hbk.ta
                       select new
                       {
                           hbk.CIF,
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

                if (isDuplicateNameAndDoBDWHHapusBuku.Count > 0)
                    duplicateINHapusBuku = true;
                if (isDuplicateNameAndDoBDWHHapusBuku.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                x.SearchType == "DEDUP_PH"
                && x.SearchId.Contains("p001_NPWP"))
                .Select(x => new MSearchResponse
                {
                    ResultType = x.ResultType,
                    SearchDesc = x.SearchDesc,
                    SearchId = x.SearchId,
                    SearchType = x.SearchType,
                    TypeId = x.TypeId
                }).FirstOrDefault();

                    foreach (var item in isDuplicateNameAndDoBDWHHapusBuku)
                    {
                        msearch.Branch = item.BRANCH;
                        msearch.Cif = item.CIF;
                        msearch.DateOfBirth = item.BIRTH_DATE;
                        msearch.Fullname = item.CUST_FULL_NAME;
                        msearch.Outstanding = item.OUTSTANDING;
                        msearch.LoanType = item.DEAL_TYPE;
                        msearch.NoIdentity = item.ID_NUMBER;
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = item.CUSTOMER_TYPE;
                        msearch.Limit = item.PLAFOND;
                        SearchResultCore.Add(msearch);
                    }
                }
                #endregion
                #endregion

                #region DHN

                var initDate = SlikRequest.App.TanggalAktaPendirian?.ToString("ddmmyyyy")??"[N/A]";

                #region Fullname and datebirth
                var IsDuplicateFirstNameAndDateOfBirthDHN = await _dhnContext.DHNLists.Where(x =>
                (
                    SlikIndividual.Select(x => x.Fullname).ToList().Contains(x.CustomerName??"")
                )).ToListAsync();

                #endregion
                #region No Identity DHN

                var IsDuplicateNoIdentityDHN = await _dhnContext.DHNLists.Where(x =>
                        x.IdNumber == SlikRequest.App.NomorKTP
                        && SlikRequest.App.TipeDebitur.OwnCode == "01"
                    ).ToListAsync();
                #endregion
                #region Companyname and EST Date DHN

                var IsDuplicateCompanyNameAndESTDateDHN = new List<DHNList>();
                if (SlikRequest.App.TipeDebitur.OwnCode != "01")
                {
                    IsDuplicateCompanyNameAndESTDateDHN = await _dhnContext.DHNLists.Where(x =>
                        x.CustomerName == SlikRequest.App.NamaCustomer &&
                        x.BirthDate == initDate &&
                        SlikRequest.App.TipeDebitur.OwnCode != "01"
                    ).ToListAsync();
                }
                #endregion 
                #region No NPWP DHN

                var IsDuplicateNoNPWPDHN = await _dhnContext.DHNLists.Where(x =>
                    x.NPWP == SlikRequest.App.NPWP
                ).ToListAsync();
                #endregion
                if (IsDuplicateFirstNameAndDateOfBirthDHN.Count > 0 ||
                    IsDuplicateNoIdentityDHN.Count > 0 ||
                    IsDuplicateCompanyNameAndESTDateDHN.Count > 0 ||
                    IsDuplicateNoNPWPDHN.Count > 0)
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
                        if (SlikIndividual.FirstOrDefault(x=> x.Fullname == item.CustomerName)?.DateOfBirth.ToString("ddmmyyyy") != item.BirthDate){
                            continue;
                        }

                        msearch.Branch = "-";
                        msearch.Cif = "-";
                        msearch.DateOfBirth = DateTime.ParseExact(item.BirthDate, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.Fullname = item.CustomerName;
                        msearch.Outstanding = 0;
                        msearch.LoanType = "-";
                        msearch.NoIdentity = item.IdNumber;
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = "-";
                        msearch.Limit = 0;
                        msearch.BankName = item.BankName;
                        msearch.Expired = DateTime.ParseExact(item.Expired, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.ReferenceNo = item.ReferenceNo;
                        SearchResultDHN.Add(msearch);
                    }
                }

                if (IsDuplicateCompanyNameAndESTDateDHN.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "BLACKLIST"
                    && x.SearchId.Contains("b002_NM_ESTDATE"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateCompanyNameAndESTDateDHN)
                    {
                        msearch.Branch = "-";
                        msearch.Cif = "-";
                        msearch.DateOfBirth = DateTime.ParseExact(item.BirthDate, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.Fullname = item.CustomerName;
                        msearch.Outstanding = 0;
                        msearch.LoanType = "-";
                        msearch.NoIdentity = item.IdNumber;
                        msearch.Npwp = item.NPWP;
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
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = "-";
                        msearch.Limit = 0;
                        msearch.BankName = item.BankName;
                        msearch.Expired = DateTime.ParseExact(item.Expired, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.ReferenceNo = item.ReferenceNo;
                        SearchResultDHN.Add(msearch);
                    }
                }
                if (IsDuplicateNoNPWPDHN.Count > 0)
                {
                    var msearch = mSearch.Where(x =>
                    x.SearchType == "BLACKLIST"
                    && x.SearchId.Contains("b004_NPWP"))
                    .Select(x => new MSearchResponse
                    {
                        ResultType = x.ResultType,
                        SearchDesc = x.SearchDesc,
                        SearchId = x.SearchId,
                        SearchType = x.SearchType,
                        TypeId = x.TypeId
                    }).FirstOrDefault();

                    foreach (var item in IsDuplicateNoNPWPDHN)
                    {
                        msearch.Branch = "-";
                        msearch.Cif = "-";
                        msearch.DateOfBirth = DateTime.ParseExact(item.BirthDate, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.Fullname = item.CustomerName;
                        msearch.Outstanding = 0;
                        msearch.LoanType = "-";
                        msearch.NoIdentity = item.IdNumber;
                        msearch.Npwp = item.NPWP;
                        msearch.CustType = "-";
                        msearch.Limit = 0;
                        msearch.BankName = item.BankName;
                        msearch.Expired = DateTime.ParseExact(item.Expired, "ddMMyyyy", CultureInfo.GetCultureInfo("tr-TR"));
                        msearch.ReferenceNo = item.ReferenceNo;
                        SearchResultDHN.Add(msearch);
                    }
                }
                #endregion

                SlikRequestDuplikasiResponse duplicateLoanApplication = new SlikRequestDuplikasiResponse
                {
                    Internal = new SlikRequestDuplikasiLMSResponse
                    {
                        IsDuplicate = duplicateInLMS,
                        MSearch = SearchResultLMS
                    },
                    Core = new SlikRequestDuplikasiLMSResponse
                    {
                        IsDuplicate = duplicateInCore,
                        MSearch = SearchResultCore
                    },
                    DHN = new SlikRequestDuplikasiLMSResponse
                    {
                        IsDuplicate = duplicateINDHN,
                        MSearch = SearchResultDHN
                    }
                };
                var lmsDups = _mapper.Map<List<SlikRequestDuplikasi>>(SearchResultLMS);
                var coreDups = _mapper.Map<List<SlikRequestDuplikasi>>(SearchResultCore);
                var dhnDups = _mapper.Map<List<SlikRequestDuplikasi>>(SearchResultDHN);
                var agunanDups = _mapper.Map<List<SlikRequestDuplikasi>>(SearchResultCollateral);

                var ListRFJenisDuplikasi = await _RFJenisDuplikasi.GetAllAsync();

                foreach (SlikRequestDuplikasi lmsDup in lmsDups)
                {
                    lmsDup.SlikRequestId = request.SlikRequestId;
                    lmsDup.RFJenisDuplikasiId = ListRFJenisDuplikasi.Where(x=>x.JenisCode == "LMS").Select(x => x.Id).First();
                }

                foreach (SlikRequestDuplikasi coreDup in coreDups)
                {
                    coreDup.SlikRequestId = request.SlikRequestId;
                    coreDup.RFJenisDuplikasiId = ListRFJenisDuplikasi.Where(x=>x.JenisCode == "CORE").Select(x => x.Id).First();
                }

                foreach (SlikRequestDuplikasi dhndup in dhnDups)
                {
                    dhndup.SlikRequestId = request.SlikRequestId;
                    dhndup.RFJenisDuplikasiId = ListRFJenisDuplikasi.Where(x=>x.JenisCode == "DNH").Select(x => x.Id).First();
                }

                foreach (SlikRequestDuplikasi agunanDup in agunanDups)
                {
                    agunanDup.SlikRequestId = request.SlikRequestId;
                    agunanDup.RFJenisDuplikasiId = ListRFJenisDuplikasi.Where(x=>x.JenisCode == "AGN").Select(x => x.Id).First();
                }

                await _loanApplicationDuplication.AddRangeAsync(lmsDups);
                await _loanApplicationDuplication.AddRangeAsync(coreDups);
                await _loanApplicationDuplication.AddRangeAsync(dhnDups);
                await _loanApplicationDuplication.AddRangeAsync(agunanDups);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);

                response.Success = false;
                return response;
                // throw new Exception(ex.Message);
            }
        }
    }
}