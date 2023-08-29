using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Commands
{
    public class RFInsRateMappingDeleteCommand : RFInsRateMappingFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFInsRateMappingCommandHandler : IRequestHandler<RFInsRateMappingDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateMapping> _RFInsRateMapping;
        private readonly IMapper _mapper;

        public DeleteRFInsRateMappingCommandHandler(IGenericRepositoryAsync<RFInsRateMapping> RFInsRateMapping, IMapper mapper){
            _RFInsRateMapping = RFInsRateMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFInsRateMappingDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFInsRateMapping.GetByIdAsync(request.InsRateId, "InsRateId");
            rFProduct.IsDeleted = true;
            await _RFInsRateMapping.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}