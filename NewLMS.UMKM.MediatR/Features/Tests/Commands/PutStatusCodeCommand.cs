using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Tests;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes
{
    public class PutStatusCodeCommand : TestPutCommand, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutStatusCodeCommandHandler : IRequestHandler<PutStatusCodeCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<RfVehType> _rfVehType;
        private readonly IMapper _mapper;

        public PutStatusCodeCommandHandler()
        {
        }

        public async Task<ServiceResponse<Unit>> Handle(PutStatusCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await _rfVehType.GetByIdAsync("", "Id");
            return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
        }
    }
}
