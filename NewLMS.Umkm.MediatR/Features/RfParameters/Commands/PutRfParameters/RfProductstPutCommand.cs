using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PutRfParameters
{
    public class RfParameterPutCommand : RfParameterPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRfParameterCommandHandler : IRequestHandler<RfParameterPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameter> _rfParameter;
        private readonly IMapper _mapper;

        public PutRfParameterCommandHandler(IGenericRepositoryAsync<RfParameter> rfParameter, IMapper mapper)
        {
            _rfParameter = rfParameter;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterPutCommand request, CancellationToken cancellationToken)
        {
            var rfParameter = await _rfParameter.GetByIdAsync(request.ParameterId, "ParameterId");

            rfParameter.Name = request.Name;
            rfParameter.Description = request.Description;
            rfParameter.Active = request.Active;

            await _rfParameter.UpdateAsync(rfParameter);

            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
