using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Tests;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes
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
