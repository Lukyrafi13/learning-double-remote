using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2PostCommand : RFSectorLBU2PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRFSectorLBU2CommandHandler : IRequestHandler<RFSectorLBU2PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSectorLBU2> _RFSectorLBU2;
        private readonly IMapper _mapper;

        public PostRFSectorLBU2CommandHandler(IGenericRepositoryAsync<RFSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _RFSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSectorLBU2PostCommand request, CancellationToken cancellationToken)
        {
            var RFSectorLBU2 = _mapper.Map<RFSectorLBU2>(request);
            await _RFSectorLBU2.AddAsync(RFSectorLBU2);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
