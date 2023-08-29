using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Commands
{
    public class RfSectorLBU2DeleteCommand : RfSectorLBU2DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfSectorLBU2CommandHandler : IRequestHandler<RfSectorLBU2DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLbu2;
        private readonly IMapper _mapper;

        public DeleteRfSectorLBU2CommandHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLbu2, IMapper mapper)
        {
            _rfSectorLbu2 = rfSectorLbu2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU2DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu2 = await _rfSectorLbu2.GetByIdAsync(request.Code, "Code");
            rfSectorLbu2.IsDeleted = true;
            await _rfSectorLbu2.UpdateAsync(rfSectorLbu2);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
