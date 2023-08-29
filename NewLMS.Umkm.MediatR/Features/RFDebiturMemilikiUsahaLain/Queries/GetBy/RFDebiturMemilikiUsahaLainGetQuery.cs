using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Queries
{
    public class RFDebiturMemilikiUsahaLainGetQuery : RFDebiturMemilikiUsahaLainFindRequestDto, IRequest<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {
    }

    public class RFDebiturMemilikiUsahaLainGetQueryHandler : IRequestHandler<RFDebiturMemilikiUsahaLainGetQuery, ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {
        private IGenericRepositoryAsync<DebiturMemilikiUsahaLain> _RFDebiturMemilikiUsahaLain;
        private readonly IMapper _mapper;

        public RFDebiturMemilikiUsahaLainGetQueryHandler(IGenericRepositoryAsync<DebiturMemilikiUsahaLain> RFDebiturMemilikiUsahaLain, IMapper mapper)
        {
            _RFDebiturMemilikiUsahaLain = RFDebiturMemilikiUsahaLain;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>> Handle(RFDebiturMemilikiUsahaLainGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFDebiturMemilikiUsahaLain.GetByIdAsync(request.StatusDebitur_Code, "StatusDebitur_Code");
                if (data == null)
                    return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.Return404("Data RFDebiturMemilikiUsahaLain not found");
                var response = _mapper.Map<RFDebiturMemilikiUsahaLainResponseDto>(data);
                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnException(ex);
            }
        }
    }
}