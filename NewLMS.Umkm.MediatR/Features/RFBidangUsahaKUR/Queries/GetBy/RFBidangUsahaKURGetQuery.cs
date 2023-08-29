using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Queries
{
    public class RFBidangUsahaKURGetQuery : RFBidangUsahaKURFindRequestDto, IRequest<ServiceResponse<RFBidangUsahaKURResponseDto>>
    {
    }

    public class RFBidangUsahaKURGetQueryHandler : IRequestHandler<RFBidangUsahaKURGetQuery, ServiceResponse<RFBidangUsahaKURResponseDto>>
    {
        private IGenericRepositoryAsync<RFBidangUsahaKUR> _RFBidangUsahaKUR;
        private readonly IMapper _mapper;

        public RFBidangUsahaKURGetQueryHandler(IGenericRepositoryAsync<RFBidangUsahaKUR> RFBidangUsahaKUR, IMapper mapper)
        {
            _RFBidangUsahaKUR = RFBidangUsahaKUR;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBidangUsahaKURResponseDto>> Handle(RFBidangUsahaKURGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFBidangUsahaKUR.GetByIdAsync(request.BTCode, "BTCode");
                if (data == null)
                    return ServiceResponse<RFBidangUsahaKURResponseDto>.Return404("Data RFBidangUsahaKUR not found");
                var response = _mapper.Map<RFBidangUsahaKURResponseDto>(data);
                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnException(ex);
            }
        }
    }
}