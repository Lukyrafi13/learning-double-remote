using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1DeleteCommand : RFSectorLBU1DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRFSectorLBU1CommandHandler : IRequestHandler<RFSectorLBU1DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSectorLBU1> _rfSectorLbu1;
        private readonly IMapper _mapper;

        public DeleteRFSectorLBU1CommandHandler(IGenericRepositoryAsync<RFSectorLBU1> rfSectorLbu1, IMapper mapper)
        {
            _rfSectorLbu1 = rfSectorLbu1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU1DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu1 = await _rfSectorLbu1.GetByIdAsync(request.Code, "Code");
            rfSectorLbu1.IsDeleted = true;
            await _rfSectorLbu1.UpdateAsync(rfSectorLbu1);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
