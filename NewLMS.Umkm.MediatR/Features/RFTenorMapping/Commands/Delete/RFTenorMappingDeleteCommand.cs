using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenorMappings;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenorMappings.Commands
{
    public class RFTenorMappingDeleteCommand : RFTenorMappingFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFTenorMappingCommandHandler : IRequestHandler<RFTenorMappingDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTenorMapping> _RFTenorMapping;
        private readonly IMapper _mapper;

        public DeleteRFTenorMappingCommandHandler(IGenericRepositoryAsync<RFTenorMapping> RFTenorMapping, IMapper mapper){
            _RFTenorMapping = RFTenorMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTenorMappingDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTenorMapping.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFTenorMapping.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}