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

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Queries
{
    public class LoanApplicationPemohonBadanUsahaGet : LoanApplicationFind, IRequest<ServiceResponse<LoanApplicationPemohonBadanUsahaResponse>>
    {
    }

    public class LoanApplicationPemohonBadanUsahaGetQueryHandler : IRequestHandler<LoanApplicationPemohonBadanUsahaGet, ServiceResponse<LoanApplicationPemohonBadanUsahaResponse>>
    {
        private IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private IGenericRepositoryAsync<CompanyEntity> _CompanyEntity;
        private readonly IMapper _mapper;

        public LoanApplicationPemohonBadanUsahaGetQueryHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IGenericRepositoryAsync<CompanyEntity> CompanyEntity,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _CompanyEntity = CompanyEntity;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationPemohonBadanUsahaResponse>> Handle(LoanApplicationPemohonBadanUsahaGet request, CancellationToken cancellationToken)
        {

            var data = await _LoanApplication.GetByIdAsync(request.Id, "Id");
            
            var CompanyEntity = await _CompanyEntity.GetByPredicate(x => x.LoanApplicationGuid == request.Id);

            if (CompanyEntity == null)
            {
                return ServiceResponse<LoanApplicationPemohonBadanUsahaResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Company not found");
            }

            var response = new LoanApplicationPemohonBadanUsahaResponse{
                CompanyEntityResponse = CompanyEntity
            };

            return ServiceResponse<LoanApplicationPemohonBadanUsahaResponse>.ReturnResultWith200(response);
        }
    }
}