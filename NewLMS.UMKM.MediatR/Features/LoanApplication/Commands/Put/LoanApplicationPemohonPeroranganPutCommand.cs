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
using NewLMS.UMKM.Data.Dto.Debtors;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class LoanApplicationPemohonPeroranganPutCommand : LoanApplicationPemohonPerorangan, IRequest<ServiceResponse<Unit>>
    {

    }
    public class LoanApplicationPemohonPeroranganPutCommandHandler : IRequestHandler<LoanApplicationPemohonPeroranganPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<Debtor> _Debtor;
        private readonly IGenericRepositoryAsync<DebtorCouple> _DebtorCouple;
        private readonly IGenericRepositoryAsync<DebtorEmergency> _DebtorEmergency;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IMapper _mapper;

        public LoanApplicationPemohonPeroranganPutCommandHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IGenericRepositoryAsync<Debtor> Debtor,
            IGenericRepositoryAsync<DebtorCouple> DebtorCouple,
            IGenericRepositoryAsync<DebtorEmergency> DebtorEmergency,
            IGenericRepositoryAsync<RfZipCode> zipCode,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _Debtor = Debtor;
            _DebtorCouple = DebtorCouple;
            _DebtorEmergency = DebtorEmergency;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationPemohonPeroranganPutCommand request, CancellationToken cancellationToken)
        {
            try
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