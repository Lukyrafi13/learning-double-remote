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
    public class LoanApplicationPemohonPeroranganPutCommand : LoanApplicationPemohonPerorangan, IRequest<ServiceResponse<Unit>>
    {

    }
    public class LoanApplicationPemohonPeroranganPutCommandHandler : IRequestHandler<LoanApplicationPemohonPeroranganPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IMapper _mapper;

        public LoanApplicationPemohonPeroranganPutCommandHandler(
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IGenericRepositoryAsync<RfZipCode> zipCode,
            IMapper mapper)
        {
            _LoanApplication = LoanApplication;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationPemohonPeroranganPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingLoanApplication = await _LoanApplication.GetByIdAsync(request.Id, "Id");

                

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