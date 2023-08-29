using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1DeleteCommand : RfSectorLBU1DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfSectorLBU1CommandHandler : IRequestHandler<RfSectorLBU1DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLbu1;
        private readonly IMapper _mapper;

        public DeleteRfSectorLBU1CommandHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLbu1, IMapper mapper)
        {
            _rfSectorLbu1 = rfSectorLbu1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU1DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu1 = await _rfSectorLbu1.GetByIdAsync(request.Code, "Code");
            rfSectorLbu1.IsDeleted = true;
            await _rfSectorLbu1.UpdateAsync(rfSectorLbu1);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
