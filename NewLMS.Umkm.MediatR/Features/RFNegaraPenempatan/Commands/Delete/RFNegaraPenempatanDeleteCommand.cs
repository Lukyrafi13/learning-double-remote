using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanDeleteCommand : RFPlacementCountryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFNegaraPenempatanCommandHandler : IRequestHandler<RFNegaraPenempatanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFPlacementCountry> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public DeleteRFNegaraPenempatanCommandHandler(IGenericRepositoryAsync<RFPlacementCountry> RFNegaraPenempatan, IMapper mapper){
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFNegaraPenempatanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFNegaraPenempatan.GetByIdAsync(request.NegaraCode, "NegaraCode");
            rFProduct.IsDeleted = true;
            await _RFNegaraPenempatan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}