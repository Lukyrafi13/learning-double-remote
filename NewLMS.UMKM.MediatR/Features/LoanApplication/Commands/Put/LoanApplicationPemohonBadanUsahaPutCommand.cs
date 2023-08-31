using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class LoanApplicationPemohonBadanUsahaPutCommand : LoanApplicationPemohonBadanUsaha, IRequest<ServiceResponse<Unit>>
    {

    }
    public class LoanApplicationPemohonBadanUsahaPutCommandHandler : IRequestHandler<LoanApplicationPemohonBadanUsahaPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<CompanyEntity> _CompanyEntity;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IMapper _mapper;

        public LoanApplicationPemohonBadanUsahaPutCommandHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IGenericRepositoryAsync<CompanyEntity> CompanyEntity,
            IGenericRepositoryAsync<RfZipCode> zipCode,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _CompanyEntity = CompanyEntity;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationPemohonBadanUsahaPutCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var existingLoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id");

                var CompanyEntity = await _CompanyEntity.GetByPredicate(x=>x.LoanApplicationGuid == request.Id);

                if(CompanyEntity == null){
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "CompanyEntity not found");
                }

                if (request.CompanyEntity != null){
                    CompanyEntity = _mapper.Map(request.CompanyEntity, CompanyEntity);
                    await _CompanyEntity.UpdateAsync(CompanyEntity);
                    existingLoanApplication.CompanyEntity = CompanyEntity;
                }                

                await _LoanApplication.UpdateAsync(existingLoanApplication);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}