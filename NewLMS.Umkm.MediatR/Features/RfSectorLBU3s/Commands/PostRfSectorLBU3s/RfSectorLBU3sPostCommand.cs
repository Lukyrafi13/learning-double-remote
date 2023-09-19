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
    public class RFSectorLBU3PostCommand : RFSectorLBU3PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRFSectorLBU3CommandHandler : IRequestHandler<RFSectorLBU3PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _RFSectorLBU3;
        private readonly IMapper _mapper;

        public PostRFSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _RFSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU3PostCommand request, CancellationToken cancellationToken)
        {
            var RFSectorLBU3 = _mapper.Map<RfSectorLBU3>(request);
            await _RFSectorLBU3.AddAsync(RFSectorLBU3);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
