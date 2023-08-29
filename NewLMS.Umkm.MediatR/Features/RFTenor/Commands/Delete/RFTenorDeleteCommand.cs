using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenors.Commands
{
    public class RFTenorDeleteCommand : RFTenorFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFTenorCommandHandler : IRequestHandler<RFTenorDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public DeleteRFTenorCommandHandler(IGenericRepositoryAsync<RFTenor> RFTenor, IMapper mapper){
            _RFTenor = RFTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTenorDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTenor.GetByIdAsync(request.TNCode, "TNCode");
            rFProduct.IsDeleted = true;
            await _RFTenor.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}