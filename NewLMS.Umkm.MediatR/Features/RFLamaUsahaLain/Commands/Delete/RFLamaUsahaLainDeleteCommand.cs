using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLamaUsahaLains;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLamaUsahaLains.Commands
{
    public class RFLamaUsahaLainDeleteCommand : RFLamaUsahaLainFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFLamaUsahaLainCommandHandler : IRequestHandler<RFLamaUsahaLainDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFLamaUsahaLain> _RFLamaUsahaLain;
        private readonly IMapper _mapper;

        public DeleteRFLamaUsahaLainCommandHandler(IGenericRepositoryAsync<RFLamaUsahaLain> RFLamaUsahaLain, IMapper mapper){
            _RFLamaUsahaLain = RFLamaUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFLamaUsahaLainDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFLamaUsahaLain.GetByIdAsync(request.ANLCode, "ANLCode");
            rFProduct.IsDeleted = true;
            await _RFLamaUsahaLain.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}