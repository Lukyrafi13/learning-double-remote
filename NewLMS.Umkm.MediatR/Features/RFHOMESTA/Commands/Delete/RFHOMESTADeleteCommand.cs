using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFHOMESTAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFHOMESTAs.Commands
{
    public class RFHOMESTADeleteCommand : RFHOMESTAFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFHOMESTACommandHandler : IRequestHandler<RFHOMESTADeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFHOMESTA> _RFHOMESTA;
        private readonly IMapper _mapper;

        public DeleteRFHOMESTACommandHandler(IGenericRepositoryAsync<RFHOMESTA> RFHOMESTA, IMapper mapper){
            _RFHOMESTA = RFHOMESTA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFHOMESTADeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFHOMESTA.GetByIdAsync(request.HMSTA_CODE, "HMSTA_CODE");
            rFProduct.IsDeleted = true;
            await _RFHOMESTA.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}