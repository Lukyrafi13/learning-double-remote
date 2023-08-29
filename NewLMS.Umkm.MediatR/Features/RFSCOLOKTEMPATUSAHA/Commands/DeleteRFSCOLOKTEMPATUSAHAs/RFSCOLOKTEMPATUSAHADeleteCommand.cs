using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Commands
{
    public class RFSCOLOKTEMPATUSAHADeleteCommand : RFSCOLOKTEMPATUSAHAFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSCOLOKTEMPATUSAHACommandHandler : IRequestHandler<RFSCOLOKTEMPATUSAHADeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> _RFSCOLOKTEMPATUSAHA;
        private readonly IMapper _mapper;

        public DeleteRFSCOLOKTEMPATUSAHACommandHandler(IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA, IMapper mapper)
        {
            _RFSCOLOKTEMPATUSAHA = RFSCOLOKTEMPATUSAHA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOLOKTEMPATUSAHADeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOLOKTEMPATUSAHA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOLOKTEMPATUSAHA.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}