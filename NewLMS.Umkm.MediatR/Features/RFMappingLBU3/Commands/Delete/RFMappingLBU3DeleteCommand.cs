using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Commands
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