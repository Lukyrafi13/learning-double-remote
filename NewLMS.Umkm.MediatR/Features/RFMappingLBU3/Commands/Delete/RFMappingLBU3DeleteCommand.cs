using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFMappingLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Commands
{
    public class RFMappingLBU3DeleteCommand : RFMappingLBU3FindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFMappingLBU3CommandHandler : IRequestHandler<RFMappingLBU3DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public DeleteRFMappingLBU3CommandHandler(IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3, IMapper mapper){
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFMappingLBU3DeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFMappingLBU3.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFMappingLBU3.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}