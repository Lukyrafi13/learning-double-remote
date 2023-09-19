using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalResults;
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

namespace NewLMS.Umkm.MediatR.Features.AppraisalResult.Commands
{
    public class PostCollateralBindingCommand : CollateralBindingRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid LoanApplicationGuid;
    }

    public class PostCollateralBindingCommandHandler : IRequestHandler<PostCollateralBindingCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AppraisalResults> _appraisalResult;
        private readonly IGenericRepositoryAsync<AppraisalResultCollateralBinding> _collateralBinding;
        private readonly IMapper _mapper;

        public PostCollateralBindingCommandHandler(IGenericRepositoryAsync<AppraisalResults> appraisalResult, IMapper mapper, IGenericRepositoryAsync<AppraisalResultCollateralBinding> collateralBinding)
        {
            _appraisalResult = appraisalResult;
            _mapper = mapper;
            _collateralBinding = collateralBinding;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostCollateralBindingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appraisalResultGuid = await GetAppraisalResultGuid(request.LoanApplicationGuid);
                var collateralBinding = _mapper.Map<AppraisalResultCollateralBinding>(request);
                collateralBinding.AppraisalResultGuid = appraisalResultGuid;

                if (request.CollateralBindingGuid != null)
                {
                    var collateralBindingData = await _collateralBinding.GetByIdAsync(Guid.Parse(request.CollateralBindingGuid), "CollateralBindingGuid");
                    collateralBinding.CollateralBindingGuid = collateralBindingData.CollateralBindingGuid;
                    collateralBinding.AppraisalResultGuid = collateralBindingData.AppraisalResultGuid;
                    collateralBinding = HelperGeneral.UpdateBaseEntityTime(collateralBinding, collateralBindingData);
                    await _collateralBinding.UpdateAsync(collateralBinding);
                }
                else
                {
                    collateralBinding.CollateralBindingGuid = Guid.NewGuid();
                    await _collateralBinding.AddAsync(collateralBinding);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<Guid> GetAppraisalResultGuid(Guid loanApplicationGuid)
        {
            var data = await _appraisalResult.GetByIdAsync(loanApplicationGuid, "LoanApplicationGuid");
            if (data != null)
            {
                return data.AppraisalResultGuid;
            }
            else
            {
                Guid newGuid = Guid.NewGuid();
                var appraisalResult = new AppraisalResults
                {
                    AppraisalResultGuid = newGuid,
                    LoanApplicationGuid = loanApplicationGuid
                };

                await _appraisalResult.AddAsync(appraisalResult);
                return newGuid;
            }
        }
    }
}
