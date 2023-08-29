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
    public class RfSectorLBU2PostCommand : RfSectorLBU2PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRfSectorLBU2CommandHandler : IRequestHandler<RfSectorLBU2PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU2> _RfSectorLBU2;
        private readonly IMapper _mapper;

        public PostRfSectorLBU2CommandHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _RfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU2PostCommand request, CancellationToken cancellationToken)
        {
            var RfSectorLBU2 = _mapper.Map<RfSectorLBU2>(request);
            await _RfSectorLBU2.AddAsync(RfSectorLBU2);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
