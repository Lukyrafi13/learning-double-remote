using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Enums;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;

#nullable enable
namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands
{
    public class ProspectProcessCommand : ProspectFindRequest, IRequest<ServiceResponse<Guid>>
    {
    }
    public class ProspectProcessCommandHandler : IRequestHandler<ProspectProcessCommand, ServiceResponse<Guid>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<RfStage> _stages;
        private readonly IGenericRepositoryAsync<Debtor> _debtor;
        private readonly IGenericRepositoryAsync<DebtorCompany> _debtorCompany;
        private readonly IGenericRepositoryAsync<LoanApplicationStage> _loanApplicationStage;
        private readonly ICurrentUserService _userInfoToken;

        private readonly IMapper _mapper;

        public ProspectProcessCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<LoanApplication> loanApplication,
                IGenericRepositoryAsync<RfStage> stages,
                IGenericRepositoryAsync<Debtor> debtor,
                IGenericRepositoryAsync<DebtorCompany> debtorCompany,
                IMapper mapper,
                ICurrentUserService userInfoToken
,
                IGenericRepositoryAsync<LoanApplicationStage> loanApplicationStage)
        {
            _prospect = prospect;
            _loanApplication = loanApplication;
            _stages = stages;
            _debtor = debtor;
            _debtorCompany = debtorCompany;
            _mapper = mapper;
            _userInfoToken = userInfoToken;
            _loanApplicationStage = loanApplicationStage;
        }

        public async Task<ServiceResponse<Guid>> Handle(ProspectProcessCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var prospectIncludes = new string[] {
                    "RfOwnerCategory",
                    "RfProduct"
                };

                //TODO: Refine building ID logic
                var countDataLoan = await _loanApplication.GetCountByPredicate(x =>
                            x.CreatedDate.Year == DateTime.Now.Year
                            && x.CreatedDate.Month == DateTime.Now.Month
                            );
                var prospect = await _prospect.GetByIdAsync(request.Id, "Id", prospectIncludes);
                var loanApplicationId = prospect.BranchId
                            + "-"
                            + prospect.RfProduct.ProductType
                            + "-"
                            + DateTime.Now.ToString("yy")
                            + DateTime.Now.ToString("MM")
                            + "-"
                            + (countDataLoan + 1).ToString("D4");
                var loanApplication = new LoanApplication()
                {
                    Id = Guid.NewGuid(),
                    BranchId = prospect.BranchId,
                    DataSource = prospect.DataSource,
                    ProspectId = prospect.Id,
                    LoanApplicationId = loanApplicationId,
                    ProductId = prospect.ProductId,
                    Status = EnumLoanApplicationStatus.Draft,
                    StageId = Guid.Parse("1FBE4B9F-1B6C-4056-9054-7BBA1AE614E2"),
                    OwnerCategoryId = prospect.OwnerCategoryId ?? 1,
                    OwnerId = Guid.Parse(_userInfoToken.Id),
                };

                Debtor debtor = new();
                DebtorCompany debtorCompany = new();

                if (prospect.RfOwnerCategory.Code == "001") // Perorangan
                {
                    debtor = new Debtor()
                    {
                        Id = Guid.NewGuid(),
                        Fullname = prospect.Fullname,
                        NoIdentity = prospect.NoIdentity,
                        DateOfBirth = prospect.DateOfBirth,
                        PlaceOfBirth = prospect.PlaceOfBirth,
                        Address = prospect.Address,
                        Province = prospect.Province,
                        City = prospect.City,
                        District = prospect.District,
                        Neighborhoods = prospect.Neighborhoods,
                        ZipCodeId = prospect.ZipCodeId,
                        GenderId = prospect.GenderId,
                        PhoneNumber = prospect.PhoneNumber,
                        PlaceOfBirth = prospect.PlaceOfBirth,
                        DateOfBirth = prospect.DateOfBirth
                    };
                    await _debtor.AddAsync(debtor);

                    loanApplication.DebtorCompanyId = null;
                    loanApplication.DebtorId = debtor.Id;
                }
                else if (prospect.RfOwnerCategory.Code == "002") // Badan Usaha
                {
                    debtorCompany = new DebtorCompany()
                    {
                        Id = Guid.NewGuid(),
                        Name = prospect.Fullname,
                        Address = prospect.Address,
                        Province = prospect.Province,
                        City = prospect.City,
                        District = prospect.District,
                        Neighborhoods = prospect.Neighborhoods,
                        ZipCodeId = prospect.ZipCodeId,
                        PhoneNumber = prospect.PhoneNumber,
                    };
                    await _debtorCompany.AddAsync(debtorCompany);

                    loanApplication.DebtorId = null;
                    loanApplication.DebtorCompanyId = debtorCompany.Id;
                }

                await _loanApplication.AddAsync(loanApplication);
                prospect.Status = EnumProspectStatus.Processed;
                await _prospect.UpdateAsync(prospect);

                var loanApplicationStage = new LoanApplicationStage()
                {
                    Id = Guid.NewGuid(),
                    LoanApplicationId = loanApplication.Id,
                    OwnerRoleId = Guid.Parse("CB409959-9416-4C35-9AE8-EB905C3DE1AC"),
                    StageId = UMKMConst.Stages["InitialDateEntry"],
                    OwnerUserId = loanApplication.CreatedBy,
                    Processed = false,
                    ProcessedBy = loanApplication.CreatedBy,
                    ProcessedDate = DateTime.Now,
                };
                await _loanApplicationStage.AddAsync(loanApplicationStage);

                return ServiceResponse<Guid>.ReturnResultWith201(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<Guid>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}