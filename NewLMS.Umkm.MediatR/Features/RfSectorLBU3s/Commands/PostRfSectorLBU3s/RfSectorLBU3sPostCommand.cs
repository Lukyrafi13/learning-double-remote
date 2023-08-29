using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3PostCommand : RFSectorLBU3PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRFSectorLBU3CommandHandler : IRequestHandler<RFSectorLBU3PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSectorLBU3> _RFSectorLBU3;
        private readonly IMapper _mapper;

        public PostRFSectorLBU3CommandHandler(IGenericRepositoryAsync<RFSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _RFSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU3PostCommand request, CancellationToken cancellationToken)
        {
            var RFSectorLBU3 = _mapper.Map<RFSectorLBU3>(request);
            await _RFSectorLBU3.AddAsync(RFSectorLBU3);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
