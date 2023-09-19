using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.CollateralInsurances;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.CollateralInsurances.Commands
{
    public class CollateralInsurancePostCommand : CollateralInsurancePostRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid LoanApplicationCollateralGuid;
    }

    public class PostCollateralInsuranceCommandHandler : IRequestHandler<CollateralInsurancePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<CollateralInsurance> _coll;
        private readonly IMapper _mapper;

        public PostCollateralInsuranceCommandHandler(IGenericRepositoryAsync<CollateralInsurance> coll, IMapper mapper)

        {
            _coll = coll;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(CollateralInsurancePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var collateralInsurance = await _coll.GetByPredicate(x => x.LoanApplicationCollateralGuid == request.LoanApplicationCollateralGuid);
                var collateralInsuranceMapped = _mapper.Map<CollateralInsurance>(request);
                collateralInsuranceMapped.LoanApplicationCollateralGuid = request.LoanApplicationCollateralGuid;
                if (collateralInsurance != null)
                {
                    collateralInsuranceMapped.CollateralInsuranceGuid = collateralInsurance.CollateralInsuranceGuid;
                    collateralInsuranceMapped = HelperGeneral.UpdateBaseEntityTime(collateralInsuranceMapped, collateralInsurance);

                    await _coll.UpdateAsync(collateralInsuranceMapped);
                }
                else
                {
                    collateralInsuranceMapped.CollateralInsuranceGuid = Guid.NewGuid();

                    await _coll.AddAsync(collateralInsuranceMapped);
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
