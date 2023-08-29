using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTenorMappings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTenorMappings.Commands
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