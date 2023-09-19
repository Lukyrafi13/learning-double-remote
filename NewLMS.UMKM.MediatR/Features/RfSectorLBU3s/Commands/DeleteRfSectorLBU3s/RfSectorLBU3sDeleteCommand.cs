using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3DeleteCommand : RFSectorLBU3DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRFSectorLBU3CommandHandler : IRequestHandler<RFSectorLBU3DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLbu3;
        private readonly IMapper _mapper;

        public DeleteRFSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLbu3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU3DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu3 = await _rfSectorLbu3.GetByIdAsync(request.Code, "Code");
            rfSectorLbu3.IsDeleted = true;
            await _rfSectorLbu3.UpdateAsync(rfSectorLbu3);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
