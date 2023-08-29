using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.Umkm.Data.Dto.RFMARITALs;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Commands
{
    public class RFMARITALDeleteCommand : RFMARITALFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFMARITALCommandHandler : IRequestHandler<RFMARITALDeleteCommand, ServiceResponse<Unit>>

    {
        private readonly IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IMapper _mapper;

        public DeleteRFMARITALCommandHandler(IGenericRepositoryAsync<RFMARITAL> RFMARITAL, IMapper mapper)
        {
            _RFMARITAL = RFMARITAL;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFMARITALDeleteCommand request, CancellationToken cancellationToken)
        {
            var RFMARITAL = await _RFMARITAL.GetByIdAsync(request.MR_CODE, "MR_CODE");
            RFMARITAL.IsDeleted = true;
            await _RFMARITAL.UpdateAsync(RFMARITAL);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }

    }
}




