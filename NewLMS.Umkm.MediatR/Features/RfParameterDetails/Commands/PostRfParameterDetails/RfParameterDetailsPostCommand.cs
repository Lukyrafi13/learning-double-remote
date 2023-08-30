using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PostRfParameterDetails
{
    public class RfParameterDetailPostCommand : RfParameterDetailPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostRfParameterDetailCommandHandler : IRequestHandler<RfParameterDetailPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfParameterDetail> _RfParameterDetail;
        private readonly IMapper _mapper;

        public PostRfParameterDetailCommandHandler(IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail, IMapper mapper)
        {
            _RfParameterDetail = rfParameterDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfParameterDetailPostCommand request, CancellationToken cancellationToken)
        {
            var RfParameterDetail = _mapper.Map<RfParameterDetail>(request);
            await _RfParameterDetail.AddAsync(RfParameterDetail);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
