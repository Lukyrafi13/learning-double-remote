using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.CollateralInsurances;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.CollateralInsurances.Queries
{
    public class GetInsuranceRatesByCoverageQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<InsuranceRateMappingResponse>>>
    {
        public string TemplateId;
    }

    public class GetInsuranceRatesByCoverageQueryHandler : IRequestHandler<GetInsuranceRatesByCoverageQuery, PagedResponse<IEnumerable<InsuranceRateMappingResponse>>>
    {
        //private readonly IGenericRepositoryAsync<RFInsuranceRateTemplateMapping> _insMapping;
        private readonly IMapper _mapper;

        public GetInsuranceRatesByCoverageQueryHandler(
            IMapper mapper)
            //IGenericRepositoryAsync<RFInsuranceRateTemplateMapping> insMapping)
        {
            //_insMapping = insMapping;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<InsuranceRateMappingResponse>>> Handle(GetInsuranceRatesByCoverageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dataVm = new List<InsuranceRateMappingResponse>();
                /*var insuranceMapping = await _insMapping.GetPagedReponseAsync(request);
                if (insuranceMapping != null)
                {
                    dataVm = _mapper.Map<List<InsuranceRateMappingResponse>>(insuranceMapping.Results);
                }*/

                return new PagedResponse<IEnumerable<InsuranceRateMappingResponse>>(dataVm, 
                    //insuranceMapping.Info, 
                    request.Page, request.Length)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                return new PagedResponse<IEnumerable<InsuranceRateMappingResponse>>(null, null, request.Page, request.Length)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
