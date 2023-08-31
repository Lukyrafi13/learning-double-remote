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
    public class LoanAppCollateralPutCommand : AppAgunanPutRequestDto, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanAppCollateralPutCommandHandler : IRequestHandler<LoanAppCollateralPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanAppCollateral;
        private readonly IMapper _mapper;

        public LoanAppCollateralPutCommandHandler(
            IGenericRepositoryAsync<LoanApplicationCollateral> loanAppCollateral, 
            IMapper mapper)
        {
            _loanAppCollateral = loanAppCollateral;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppCollateralPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var LoanAppCollateral = await _loanAppCollateral.GetByPredicate(x => x.Id == request.Id);

                if (LoanAppCollateral != null)
                {
                    var LoanAppCollUpdate = _mapper.Map<LoanApplicationCollateral>(request);
                    await _loanAppCollateral.UpdateAsync(LoanAppCollUpdate);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data Collateral Not Found");
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}