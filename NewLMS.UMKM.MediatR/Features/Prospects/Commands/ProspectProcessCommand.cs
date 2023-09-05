using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;

#nullable enable
namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands
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
        private readonly IGenericRepositoryAsync<LoanApplicationStageLog> _stageLogs;
        private readonly ICurrentUserService _userInfoToken;

        private readonly IMapper _mapper;

        public ProspectProcessCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<LoanApplication> loanApplication,
                IGenericRepositoryAsync<RfStage> stages,
                IGenericRepositoryAsync<Debtor> debtor,
                IGenericRepositoryAsync<DebtorCompany> debtorCompany,
                IGenericRepositoryAsync<LoanApplicationStageLog> stageLogs,
                IMapper mapper,
				ICurrentUserService userInfoToken
			)
        {
            _prospect = prospect;
            _loanApplication = loanApplication;
            _stages = stages;
            _stageLogs = stageLogs;
            _debtor = debtor;
            _debtorCompany = debtorCompany;
            _mapper = mapper;
            _userInfoToken = userInfoToken;
        }

        public async Task<ServiceResponse<Guid>> Handle(ProspectProcessCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var prospectIncludes = new string[] {
                    "RfOwnerCategory"
                };
                var prospect = await _prospect.GetByIdAsync(request.Id, "Id");

                Debtor? debtor;
                DebtorCompany? debtorCompany;

                if (prospect.RfOwnerCategory.Code == "001") // Perorangan
                {
                    debtor = new Debtor()
                    {
                        Id = Guid.NewGuid(),
                        Fullname = prospect.Fullname,
                        NoIdentity = prospect.NoIdentity,
                        Address = prospect.Address,
                        Province = prospect.Province,
                        City = prospect.City,
                        District = prospect.District,
                        Neighborhoods = prospect.Neighborhoods,
                        ZipCodeId = prospect.ZipCodeId,
                        GenderId = prospect.GenderId,
                        PhoneNumber = prospect.PhoneNumber,
                    };
                    await _debtor.AddAsync(debtor);
                }
                else if (prospect.RfOwnerCategory.Code == "002") // Badan Usaha
                {
                    debtorCompany = new DebtorCompany()
                    {
                        Id = Guid.NewGuid(),
                        Name = prospect.CompanyName,
                        PhoneNumber = prospect.PhoneNumber,
                        Address = prospect.CompanyAddress,
                        Province = prospect.CompanyProvince,
                        City = prospect.CompanyCity,
                        District = prospect.CompanyDistrict,
                        Neighborhoods = prospect.CompanyNeighborhoods,
                        ZipCodeId = prospect.CompanyZipCodeId ?? 0,
                    };
                    await _debtorCompany.AddAsync(debtorCompany);
                }

                return ServiceResponse<Guid>.ReturnResultWith200(Guid.NewGuid());
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