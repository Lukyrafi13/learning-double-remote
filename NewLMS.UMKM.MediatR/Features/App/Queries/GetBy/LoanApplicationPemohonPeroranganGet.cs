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

                var debtor = await _Debtor.GetByPredicate(x=>x.LoanApplicationGuid == request.Id);

                if(debtor == null){
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Debtor not found");
                }

                if (request.Debtor != null){
                    debtor = _mapper.Map(request.Debtor, debtor);
                    await _Debtor.UpdateAsync(debtor);
                    existingLoanApplication.Debtor = debtor;
                }

                if (request.DebtorCouple != null){
                    var debtorCouple = await _DebtorCouple.GetByPredicate(x=>x.DebtorCoupleId == debtor.NoIdentity);
                    var IsNew = debtorCouple == null;
                    if (IsNew){
                        debtorCouple = new DebtorCouple();
                    }
                    debtorCouple = _mapper.Map(request.DebtorCouple, debtorCouple);

                    if (IsNew){
                        await _DebtorCouple.AddAsync(debtorCouple);
                    }else{
                        await _DebtorCouple.UpdateAsync(debtorCouple);
                    }

                }

                if (request.DebtorEmergency != null){
                    var debtorEmergency = await _DebtorEmergency.GetByPredicate(x=>x.DebtorId == debtor.NoIdentity);
                    var IsNew = debtorEmergency == null;
                    if (IsNew){
                        debtorEmergency = new DebtorEmergency();
                    }
                    debtorEmergency = _mapper.Map(request.DebtorCouple, debtorEmergency);

                    if (IsNew){
                        await _DebtorEmergency.AddAsync(debtorEmergency);
                    }else{
                        await _DebtorEmergency.UpdateAsync(debtorEmergency);
                    }
                }

            return ServiceResponse<LoanApplicationPemohonPeroranganResponse>.ReturnResultWith200(response);
        }
    }
}