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
    public class RfSectorLBU3PostCommand : RfSectorLBU3PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRfSectorLBU3CommandHandler : IRequestHandler<RfSectorLBU3PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _RfSectorLBU3;
        private readonly IMapper _mapper;

        public PostRfSectorLBU3CommandHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _RfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU3PostCommand request, CancellationToken cancellationToken)
        {
            var RfSectorLBU3 = _mapper.Map<RfSectorLBU3>(request);
            await _RfSectorLBU3.AddAsync(RfSectorLBU3);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
