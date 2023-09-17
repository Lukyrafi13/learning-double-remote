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
    public class GetInsuranceByBrokerQuery : IRequest<ServiceResponse<List<SimpleResponse<string>>>>
    {
        public Guid CompanyType;
    }

    public class GetInsuranceByBrokerQueryHandler : IRequestHandler<GetInsuranceByBrokerQuery, ServiceResponse<List<SimpleResponse<string>>>>
    {
        //private readonly IGenericRepositoryAsync<RFInsuranceCompany> _insCompany;
        private readonly IMapper _mapper;

        public GetInsuranceByBrokerQueryHandler(
            //IGenericRepositoryAsync<RFInsuranceCompany> insCompany, 
            IMapper mapper)
        {
            //_insCompany = insCompany;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<SimpleResponse<string>>>> Handle(GetInsuranceByBrokerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dataVm = new List<SimpleResponse<string>>();
                /*var insuranceCompany = await _insCompany.GetListByPredicate(x => x.CompanyType == request.CompanyType && x.IsActive && !x.IsDeleted);
                if (insuranceCompany != null && insuranceCompany.Count > 0)
                {
                    dataVm = _mapper.Map<List<SimpleResponse<string>>>(insuranceCompany);
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
