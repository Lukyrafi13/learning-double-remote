using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Commands
{
    public class RFMappingAgunan2DeleteCommand : RFMappingAgunan2FindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFMappingAgunan2CommandHandler : IRequestHandler<RFMappingAgunan2DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFMappingAgunan2> _RFMappingAgunan2;
        private readonly IMapper _mapper;

        public DeleteRFMappingAgunan2CommandHandler(IGenericRepositoryAsync<RFMappingAgunan2> RFMappingAgunan2, IMapper mapper){
            _RFMappingAgunan2 = RFMappingAgunan2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFMappingAgunan2DeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFMappingAgunan2.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFMappingAgunan2.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}