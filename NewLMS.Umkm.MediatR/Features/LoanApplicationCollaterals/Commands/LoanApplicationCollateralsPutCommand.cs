using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollaterals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCollaterals.Commands
{
    public class LoanApplicationCollateralsPutCommand : LoanApplicationCollateralAndOwnerPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationCollateralsPutCommandHandler : IRequestHandler<LoanApplicationCollateralsPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<loanApplicationcollateralowner> _loanApplicationCollateral;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateralOwner> _loanApplicationCollateralOwner;
        private readonly IMapper _mapper;

        public LoanApplicationCollateralsPutCommandHandler(
            IGenericRepositoryAsync<loanApplicationcollateralowner> loanApplicationCollateral, 
            IGenericRepositoryAsync<LoanApplicationCollateralOwner> loanApplicationCollateralOwner, 
            IMapper mapper)
        {
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplicationCollateralOwner = loanApplicationCollateralOwner;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCollateralsPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationCollateral = await _loanApplicationCollateral.GetByPredicate(x => x.Id == request.LoanApplicationCollateral.Id);
                if (loanApplicationCollateral != null)
                {
                    _mapper.Map(request.LoanApplicationCollateral, loanApplicationCollateral);
                    await _loanApplicationCollateral.UpdateAsync(loanApplicationCollateral);

                    var loanApplicationCollateralOwner = await _loanApplicationCollateralOwner.GetByPredicate(x => x.Id == request.LoanApplicationCollateral.Id);
                    if(loanApplicationCollateralOwner != null)
                    {
                        _mapper.Map(request.LoanApplicationCollateralOwner, loanApplicationCollateralOwner);
                        await _loanApplicationCollateralOwner.UpdateAsync(loanApplicationCollateralOwner);
                    }
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data LoanApplicationCollateral Not Found");
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
