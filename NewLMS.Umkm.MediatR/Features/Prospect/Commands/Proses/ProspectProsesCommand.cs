using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands
{
    public class ProspectProsesCommand : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectProsesResponseDto>>
    {
        public string NamaUser { get; set; }
    }
    public class ProspectProsesCommandHandler : IRequestHandler<ProspectProsesCommand, ServiceResponse<ProspectProsesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<RfStage> _stages;
        private readonly IGenericRepositoryAsync<Debtor> _Debtor;
        private readonly IGenericRepositoryAsync<DebtorCompany> _DebtorCompany;
        private readonly IGenericRepositoryAsync<CompanyEntity> _CompanyEntity;
        private readonly IGenericRepositoryAsync<LoanApplicationStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public ProspectProsesCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<LoanApplication> LoanApplication,
                IGenericRepositoryAsync<RfStage> stages,
                IGenericRepositoryAsync<Debtor> Debtor,
                IGenericRepositoryAsync<DebtorCompany> DebtorCompany,
                IGenericRepositoryAsync<CompanyEntity> CompanyEntity,
                IGenericRepositoryAsync<LoanApplicationStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _prospect = prospect;
            _LoanApplication = LoanApplication;
            _stages = stages;
            _stageLogs = stageLogs;
            _Debtor = Debtor;
            _DebtorCompany = DebtorCompany;
            _CompanyEntity = CompanyEntity;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProspectProsesResponseDto>> Handle(ProspectProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id",
                    new string[] {
                        "RfProduct",
                        "RfOwnerCategory",
                    }
                );
                if (prospect == null)
                {
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.Return404("Data Prospect not found");
                    failResp.Success = false;
                    return failResp;
                }

                prospect.ProcessStatus = true;
                await _prospect.UpdateAsync(prospect);

                var newLoanApp = false;

                var LoanApplication = await _LoanApplication.GetByPredicate(x => x.ProspectId == prospect.Id);

                if (LoanApplication == null)
                {

                    // Assign New LoanApplication
                    LoanApplication = new LoanApplication();
                    
                    if(prospect.RfOwnerCategory.OwnCode == "01"){

                        // Create Debitur
                        var Debitur = new Debtor{
                            Fullname = prospect.Fullname,
                            NoIdentity = prospect.NoIdentity,
                            DateOfBirth = prospect.DateOfBirth,
                            PlaceOfBirth = prospect.PlaceOfBirth,
                            Phone = prospect.PhoneNumber,
                            Address = prospect.Address,
                            Province = prospect.Province,
                            City = prospect.City,
                            District = prospect.District,
                            Neighborhoods = prospect.Neighborhoods,
                            RfZipCodeId = prospect.ZipCodeId,
                        };

                        Debitur = await _Debtor.AddAsync(Debitur);

                        // Create Debitor Company
                        var DebiturCompany = new DebtorCompany{
                            CompanyName = prospect.CompanyName,
                            Address = prospect.CompanyAddress,
                            FullAddress = prospect.CompanyFullAddress,
                            RfZipCodeId = prospect.CompanyZipCodeId ?? 0,
                            Neighborhoods = prospect.Neighborhoods,
                            District = prospect.District,
                            City = prospect.City,
                            Province = prospect.Province,
                            DebtorId = prospect.NoIdentity,
                        };

                        DebiturCompany = await _DebtorCompany.AddAsync(DebiturCompany);

                        LoanApplication.NoIdentity = Debitur.NoIdentity;
                        
                    }
                    if(prospect.RfOwnerCategory.OwnCode == "02"){
                        var CompanyEntity = new CompanyEntity{
                            CompanyName = prospect.CompanyName,
                            Phone = prospect.PhoneNumber,
                            RfCompanyStatusId = (int)prospect.RfCompanyStatusId,
                            Address = prospect.Address,
                            Neighborhoods = prospect.Neighborhoods,
                            District = prospect.District,
                            City = prospect.City,
                            Province = prospect.Province,
                            RfZipCodeId = prospect.ZipCodeId,
                        };

                        CompanyEntity = await _CompanyEntity.AddAsync(CompanyEntity);

                        LoanApplication.CompanyEntityGuid = CompanyEntity.Id;
                    }
                    
                    var countDataApp = await _LoanApplication.GetCountByPredicate(x =>
                                x.CreatedDate.Year == DateTime.Now.Year
                                && x.CreatedDate.Month == DateTime.Now.Month
                                );

                    var LoanApplicationId = prospect.BranchId + "-" + prospect.RfProduct.ProductType + "-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + "-" + (countDataApp + 1).ToString("D4");

                    LoanApplication.LoanApplicationId = LoanApplicationId;
                    LoanApplication.DataSource = prospect.DataSource;
                    LoanApplication.ProspectId = prospect.Id;
                    LoanApplication.RfOwnerCategoryId = prospect.RfOwnerCategoryId;

                    
                    LoanApplication = await _LoanApplication.AddAsync(LoanApplication);
                }

                // Change prospect status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "2.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "1.0");

                if (LoanApplication.LatestStage?.Code == "2.0")
                {
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prospect sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (LoanApplication.LatestStage?.Code == "0.0")
                {
                    var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prospect sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                // Update prospect History
                var logList = await _stageLogs.GetListByPredicate(x => x.LoanApplicationId == LoanApplication.Id && x.StageId == previousStage.StageId);
                var oldLog = logList.Count == 0? null :
                logList.OrderBy(x=>x.CreatedBy)?.ToList()?.Last();
                
                newLoanApp = oldLog == null;
                
                oldLog ??= new LoanApplicationStageLogs(){
                        LoanApplicationId = LoanApplication.Id,
                        StageId = previousStage.StageId,
                    };
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();
                oldLog.TargetStage = stageFound.StageId;
                oldLog.BackStaged = false;
                oldLog.Aging = (newLoanApp? ((DateTime)oldLog.ExecutedDate - prospect.CreatedDate).Days : ((DateTime)oldLog.ExecutedDate - oldLog.CreatedDate).Days) + " HARI";

                if (newLoanApp){
                    await _stageLogs.AddAsync(oldLog);
                }
                
                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new LoanApplicationStageLogs
                {
                    LoanApplicationId = LoanApplication.Id,
                    StageId = stageFound.StageId
                };

                await _stageLogs.AddAsync(newLog);

                var response = new ProspectProsesResponseDto();

                response.AppId = LoanApplication.Id;
                response.ProspectId = prospect.Id;
                response.Stage = stageFound.Description;
                response.Message = "Prospect berhasil diproses ke IDE";

                return ServiceResponse<ProspectProsesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}