using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalResults;
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

namespace NewLMS.Umkm.MediatR.Features.AppraisalResult.Queries
{
    public class GetCollateralBindingQuery : IRequest<ServiceResponse<AppraisalResultCollateralBindingResponse>>
    {
        public Guid CollateralBindingGuid;
    }

    public class GetCollateralBindingQueryHandler : IRequestHandler<GetCollateralBindingQuery, ServiceResponse<AppraisalResultCollateralBindingResponse>>
    {
        private readonly IGenericRepositoryAsync<AppraisalResultCollateralBinding> _collateralBinding;
        private readonly IMapper _mapper;

        public GetCollateralBindingQueryHandler(IMapper mapper, IGenericRepositoryAsync<AppraisalResultCollateralBinding> collateralBinding)
        {
            _mapper = mapper;
            _collateralBinding = collateralBinding;
        }

        public async Task<ServiceResponse<AppraisalResultCollateralBindingResponse>> Handle(GetCollateralBindingQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includeCollateralBinding = new string[] {
                    "RFCollaterals",
                    "RFBindings",
                    "RFBindingTypes",
                    "RFFacilities"
                };
                var collateralBinding = await _collateralBinding.GetByIdAsync(request.CollateralBindingGuid, "CollateralBindingGuid", includeCollateralBinding);
                var dataVm = _mapper.Map<AppraisalResultCollateralBindingResponse>(collateralBinding);

                return ServiceResponse<AppraisalResultCollateralBindingResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppraisalResultCollateralBindingResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
