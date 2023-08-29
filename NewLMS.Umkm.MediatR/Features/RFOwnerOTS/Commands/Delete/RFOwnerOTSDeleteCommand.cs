using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerOTSs.Commands
{
    public class RFOwnerOTSDeleteCommand : RFOwnerOTSFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class RFOwnerOTSDeleteCommandHandler : IRequestHandler<RFOwnerOTSDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerOTS> _RFOwnerOTS;
        private readonly IMapper _mapper;

        public RFOwnerOTSDeleteCommandHandler(IGenericRepositoryAsync<RFOwnerOTS> RFOwnerOTS, IMapper mapper)
        {
            _RFOwnerOTS = RFOwnerOTS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFOwnerOTSDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFOwnerOTS.GetByIdAsync(request.OWN_CODE, "OWN_CODE");
            rFProduct.IsDeleted = true;
            await _RFOwnerOTS.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}