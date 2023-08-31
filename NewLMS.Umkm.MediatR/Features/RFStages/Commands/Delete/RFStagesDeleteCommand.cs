using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfStages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfStages.Commands
{
    public class RfStageDeleteCommand : RfStageFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfStageCommandHandler : IRequestHandler<RfStageDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfStage> _RfStage;
        private readonly IMapper _mapper;

        public DeleteRfStageCommandHandler(IGenericRepositoryAsync<RfStage> RfStage, IMapper mapper){
            _RfStage = RfStage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfStageDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfStage.GetByIdAsync(request.StageId, "StageId");
            rFProduct.IsDeleted = true;
            await _RfStage.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}