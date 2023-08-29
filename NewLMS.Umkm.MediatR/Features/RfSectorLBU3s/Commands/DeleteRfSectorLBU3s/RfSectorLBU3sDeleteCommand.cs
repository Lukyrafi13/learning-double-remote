using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU3s.Commands
{
    public class RfSectorLBU3DeleteCommand : RfSectorLBU3DeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteRfSectorLBU3CommandHandler : IRequestHandler<RfSectorLBU3DeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLbu3;
        private readonly IMapper _mapper;

        public DeleteRfSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLbu3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU3DeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSectorLbu3 = await _rfSectorLbu3.GetByIdAsync(request.Code, "Code");
            rfSectorLbu3.IsDeleted = true;
            await _rfSectorLbu3.UpdateAsync(rfSectorLbu3);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
