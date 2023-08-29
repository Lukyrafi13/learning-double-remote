using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSkemaSIKPs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSkemaSIKPs.Commands
{
    public class RFSkemaSIKPDeleteCommand : RFSkemaSIKPFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSkemaSIKPCommandHandler : IRequestHandler<RFSkemaSIKPDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public DeleteRFSkemaSIKPCommandHandler(IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP, IMapper mapper){
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSkemaSIKPDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSkemaSIKP.GetByIdAsync(request.SkemaCode, "SkemaCode");
            rFProduct.IsDeleted = true;
            await _RFSkemaSIKP.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}