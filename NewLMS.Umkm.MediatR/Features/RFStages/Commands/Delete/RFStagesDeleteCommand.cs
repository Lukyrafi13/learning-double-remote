using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStagess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFStagess.Commands
{
    public class RFStagesDeleteCommand : RFStagesFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFStagesCommandHandler : IRequestHandler<RFStagesDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IMapper _mapper;

        public DeleteRFStagesCommandHandler(IGenericRepositoryAsync<RFStages> RFStages, IMapper mapper){
            _RFStages = RFStages;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFStagesDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFStages.GetByIdAsync(request.StageId, "StageId");
            rFProduct.IsDeleted = true;
            await _RFStages.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}