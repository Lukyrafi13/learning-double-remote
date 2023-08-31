using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Commands
{
    public class LoanAppCollateralPostCommand : AppAgunanPostRequestDto, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanAppCollateralPostCommandHandler : IRequestHandler<LoanAppCollateralPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanAppCollateral;
        private readonly IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public LoanAppCollateralPostCommandHandler(IGenericRepositoryAsync<LoanApplicationCollateral> loanAppCollateral, IGenericRepositoryAsync<RfZipCode> zipCode, IMapper mapper)
        {
            _loanAppCollateral = loanAppCollateral;
            _rfZipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppCollateralPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var LoanAppCollNew = _mapper.Map<LoanApplicationCollateral>(request);
                await _loanAppCollateral.AddAsync(LoanAppCollNew);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}