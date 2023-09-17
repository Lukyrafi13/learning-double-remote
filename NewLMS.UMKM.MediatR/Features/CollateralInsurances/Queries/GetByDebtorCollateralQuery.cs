using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.CollateralInsurances;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.CollateralInsurances.Queries
{
    public class GetByDebtorCollateralQuery : IRequest<ServiceResponse<CollateralInsuranceResponse>>
    {
        public Guid LoanApplicationCollateralGuid { get; set; }
    }

    public class GetByDebtorCollateralQueryHandler : IRequestHandler<GetByDebtorCollateralQuery, ServiceResponse<CollateralInsuranceResponse>>
    {
        private readonly IGenericRepositoryAsync<CollateralInsurance> _coll;
        private IMapper _mapper;

        public GetByDebtorCollateralQueryHandler(IGenericRepositoryAsync<CollateralInsurance> coll, IMapper mapper)
        {
            _coll = coll;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CollateralInsuranceResponse>> Handle(GetByDebtorCollateralQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _coll.GetByPredicate(x => x.LoanApplicationCollateralGuid == request.LoanApplicationCollateralGuid, new string[]
                {
                    "RFInsuranceCompanyRateTemplete",
                    "RFInsuranceCompanyRateTemplete.RFInsuranceCompany",
                    "RFInsuranceCompanyRateTemplete.RFInsuranceCompany.CompanyTypeFk",
                    "RFInsuranceCompanyRateTemplete.RFInsuranceRateTemplate",
                    "RFInsuranceRateTemplateMapping"
                });
                var dataVm = _mapper.Map<CollateralInsuranceResponse>(data);

                return ServiceResponse<CollateralInsuranceResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<CollateralInsuranceResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
