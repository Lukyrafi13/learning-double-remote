using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2DeleteCommand : RFSectorLBU2DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRFSectorLBU2CommandHandler : IRequestHandler<RFSectorLBU2DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLbu2;
        private readonly IMapper _mapper;

        public DeleteRFSectorLBU2CommandHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLbu2, IMapper mapper)
        {
            _rfSectorLbu2 = rfSectorLbu2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU2DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu2 = await _rfSectorLbu2.GetByIdAsync(request.Code, "Code");
            rfSectorLbu2.IsDeleted = true;
            await _rfSectorLbu2.UpdateAsync(rfSectorLbu2);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
