using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanDeleteCommand : RFNegaraPenempatanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFNegaraPenempatanCommandHandler : IRequestHandler<RFNegaraPenempatanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFNegaraPenempatan> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public DeleteRFNegaraPenempatanCommandHandler(IGenericRepositoryAsync<RFNegaraPenempatan> RFNegaraPenempatan, IMapper mapper){
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