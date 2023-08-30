using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PostRfParameters
{
    public class RfParameterPostCommand : RfParameterPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRfParameterCommandHandler : IRequestHandler<RfParameterPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameter> _RfParameter;
        private readonly IMapper _mapper;

        public PostRfParameterCommandHandler(IGenericRepositoryAsync<RfParameter> rfParameter, IMapper mapper)
        {
            _RfParameter = rfParameter;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterPostCommand request, CancellationToken cancellationToken)
        {
            var RfParameter = _mapper.Map<RfParameter>(request);
            await _RfParameter.AddAsync(RfParameter);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
