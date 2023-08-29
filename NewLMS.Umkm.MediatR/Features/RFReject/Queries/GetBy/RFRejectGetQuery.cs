using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRejects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFRejects.Queries
{
    public class RFRejectGetQuery : RFRejectFindRequestDto, IRequest<ServiceResponse<RFRejectResponseDto>>
    {
    }

    public class RFRejectGetQueryHandler : IRequestHandler<RFRejectGetQuery, ServiceResponse<RFRejectResponseDto>>
    {
        private IGenericRepositoryAsync<RFReject> _RFReject;
        private readonly IMapper _mapper;

        public RFRejectGetQueryHandler(IGenericRepositoryAsync<RFReject> RFReject, IMapper mapper)
        {
            _RFReject = RFReject;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFRejectResponseDto>> Handle(RFRejectGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFReject.GetByIdAsync(request.RjCode, "RjCode");
                if (data == null)
                    return ServiceResponse<RFRejectResponseDto>.Return404("Data RFReject not found");
                var response = _mapper.Map<RFRejectResponseDto>(data);
                return ServiceResponse<RFRejectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRejectResponseDto>.ReturnException(ex);
            }
        }
    }
}