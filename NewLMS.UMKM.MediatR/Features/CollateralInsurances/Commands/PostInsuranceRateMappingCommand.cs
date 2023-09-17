using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.CollateralInsurances;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.CollateralInsurances.Commands
{
    public class PostInsuranceRateMappingCommand : InsuranceRateMappingRequest, IRequest<ServiceResponse<Unit>>
    { }

    public class PostInsuranceRateMappingCommandHandler : IRequestHandler<PostInsuranceRateMappingCommand, ServiceResponse<Unit>>
    {
        //private readonly IGenericRepositoryAsync<RFInsuranceRateTemplateMapping> _rateTemplateMap;
        private readonly IMapper _mapper;

        public PostInsuranceRateMappingCommandHandler(
            //IGenericRepositoryAsync<RFInsuranceRateTemplateMapping> rateTemplateMap,
            IMapper mapper
        )
        {
            //_rateTemplateMap = rateTemplateMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostInsuranceRateMappingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var insuranceRate = _mapper.Map<RFInsuranceRateTemplateMapping>(request);
                //await _rateTemplateMap.AddAsync(insuranceRate);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}
