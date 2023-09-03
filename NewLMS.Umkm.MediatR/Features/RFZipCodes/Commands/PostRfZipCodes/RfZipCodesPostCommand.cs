using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodePostCommand : RfZipCodePostRequest, IRequest<ServiceResponse<RfZipCode>>
    {
    }

    public class PostRfZipCodeCommandHandler : IRequestHandler<RfZipCodePostCommand, ServiceResponse<RfZipCode>>
    {
        private readonly IGenericRepositoryAsync<RfZipCode> _RfZipCode;
        private readonly IMapper _mapper;

        public PostRfZipCodeCommandHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _RfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfZipCode>> Handle(RfZipCodePostCommand request, CancellationToken cancellationToken)
        {
            var RfZipCode = _mapper.Map<RfZipCode>(request);
            await _RfZipCode.AddAsync(RfZipCode);
            return ServiceResponse<RfZipCode>.ReturnResultWith200(RfZipCode);
        }
    }
}
