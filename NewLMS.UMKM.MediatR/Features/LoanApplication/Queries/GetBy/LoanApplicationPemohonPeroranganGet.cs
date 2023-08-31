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
    public class LoanApplicationPemohonPeroranganGet : LoanApplicationFind, IRequest<ServiceResponse<LoanApplicationPemohonPeroranganResponse>>
    {
    }

    public class LoanApplicationPemohonPeroranganGetQueryHandler : IRequestHandler<LoanApplicationPemohonPeroranganGet, ServiceResponse<LoanApplicationPemohonPeroranganResponse>>
    {
        private IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private IGenericRepositoryAsync<Debtor> _Debtor;
        private IGenericRepositoryAsync<DebtorCouple> _DebtorCouple;
        private IGenericRepositoryAsync<DebtorEmergency> _DebtorEmergency;
        private readonly IMapper _mapper;

        public LoanApplicationPemohonPeroranganGetQueryHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationPemohonPeroranganResponse>> Handle(LoanApplicationPemohonPeroranganGet request, CancellationToken cancellationToken)
        {

            var existingLoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id");

            var debtor = await _Debtor.GetByPredicate(x => x.LoanApplicationGuid == request.Id);

            if (debtor == null)
            {
                return ServiceResponse<LoanApplicationPemohonPeroranganResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Debtor not found");
            }

            var response = new LoanApplicationPemohonPeroranganResponse
            {
                DebtorResponse = debtor
            };

            var debtorCouple = await _DebtorCouple.GetByPredicate(x => x.DebtorCoupleId == debtor.NoIdentity);

            if (debtorCouple != null)
            {
                response.DebtorCoupleResponse = debtorCouple;
            }

            var debtorEmergency = await _DebtorEmergency.GetByPredicate(x => x.DebtorId == debtor.NoIdentity);
            if (debtorEmergency != null)
            {
                response.DebtorEmergencyResponse = debtorEmergency;
            }

            return ServiceResponse<LoanApplicationPemohonPeroranganResponse>.ReturnResultWith200(response);
        }
    }
}