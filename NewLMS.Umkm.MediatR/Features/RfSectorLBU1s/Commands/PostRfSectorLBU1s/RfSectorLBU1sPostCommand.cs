using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1PostCommand : RfSectorLBU1PostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRfSectorLBU1CommandHandler : IRequestHandler<RfSectorLBU1PostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _RfSectorLBU1;
        private readonly IMapper _mapper;

        public PostRfSectorLBU1CommandHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _RfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfSectorLBU1PostCommand request, CancellationToken cancellationToken)
        {
            var RfSectorLBU1 = _mapper.Map<RfSectorLBU1>(request);
            await _RfSectorLBU1.AddAsync(RfSectorLBU1);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
