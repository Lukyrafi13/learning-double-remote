using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto;
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
    public class GetCoverageByInsuranceQuery : IRequest<ServiceResponse<List<SimpleResponse<string>>>>
    {
        public string CompanyId;
    }

    public class GetCoverageByInsuranceQueryHandler : IRequestHandler<GetCoverageByInsuranceQuery, ServiceResponse<List<SimpleResponse<string>>>>
    {
        //private readonly IGenericRepositoryAsync<RFInsuranceCompanyRateTemplete> _insRateCompany;
        private readonly IMapper _mapper;

        public GetCoverageByInsuranceQueryHandler(
            //IGenericRepositoryAsync<RFInsuranceCompanyRateTemplete> insRateCompany, 
            IMapper mapper)
        {
            //_insRateCompany = insRateCompany;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<SimpleResponse<string>>>> Handle(GetCoverageByInsuranceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dataVm = new List<SimpleResponse<string>>();
                /*var coverages = await _insRateCompany.GetListByPredicate(x => x.CompanyId == request.CompanyId && x.IsActive && !x.IsDeleted,
                    new string[] {
                        "RFInsuranceRateTemplate"
                    });
                if (coverages != null && coverages.Count > 0)
                {
                    foreach (var data in coverages)
                    {
                        dataVm.Add(_mapper.Map<SimpleResponse<string>>(data.RFInsuranceRateTemplate));
                    }
                }*/

                return ServiceResponse<List<SimpleResponse<string>>>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponse<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
