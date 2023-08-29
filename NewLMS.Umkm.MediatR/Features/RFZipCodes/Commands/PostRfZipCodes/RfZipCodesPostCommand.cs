using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodePostCommand : RFZipCodePostRequest, IRequest<ServiceResponse<RFZipCode>>
    {
    }

    public class PostRFZipCodeCommandHandler : IRequestHandler<RFZipCodePostCommand, ServiceResponse<RFZipCode>>
    {
        private readonly IGenericRepositoryAsync<RFZipCode> _RFZipCode;
        private readonly IMapper _mapper;

        public PostRFZipCodeCommandHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode, IMapper mapper)
        {
            _RFZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFZipCode>> Handle(RFZipCodePostCommand request, CancellationToken cancellationToken)
        {
            var RFZipCode = _mapper.Map<RFZipCode>(request);
            await _RFZipCode.AddAsync(RFZipCode);
            return ServiceResponse<RFZipCode>.ReturnResultWith200(RFZipCode);
        }
    }
}
