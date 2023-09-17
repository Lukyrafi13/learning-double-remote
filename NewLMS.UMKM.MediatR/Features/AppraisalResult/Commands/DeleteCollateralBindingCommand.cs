using AutoMapper;
using MediatR;
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

namespace NewLMS.UMKM.MediatR.Features.AppraisalResult.Commands
{
    public class DeleteCollateralBindingCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid CollateralBindingGuid;
    }

    public class DeleteCollateralBindingCommandHandler : IRequestHandler<DeleteCollateralBindingCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<AppraisalResultCollateralBinding> _collateralBinding;
        private readonly IMapper _mapper;

        public DeleteCollateralBindingCommandHandler(IMapper mapper, IGenericRepositoryAsync<AppraisalResultCollateralBinding> collateralBinding)
        {
            _mapper = mapper;
            _collateralBinding = collateralBinding;
        }

        public async Task<ServiceResponse<Unit>> Handle(DeleteCollateralBindingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var collateralBinding = await _collateralBinding.GetByIdAsync(request.CollateralBindingGuid, "CollateralBindingGuid");
                collateralBinding.IsDeleted = true;
                collateralBinding.DeletedDate = DateTime.Now;

                await _collateralBinding.UpdateAsync(collateralBinding);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
