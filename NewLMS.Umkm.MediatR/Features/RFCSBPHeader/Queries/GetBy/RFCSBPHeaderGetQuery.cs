using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCSBPHeaders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPHeaders.Queries
{
    public class RFCSBPHeaderGetQuery : RFCSBPHeaderFindRequestDto, IRequest<ServiceResponse<RFCSBPHeaderResponseDto>>
    {
    }

    public class RFCSBPHeaderGetQueryHandler : IRequestHandler<RFCSBPHeaderGetQuery, ServiceResponse<RFCSBPHeaderResponseDto>>
    {
        private IGenericRepositoryAsync<RFCSBPHeader> _RFCSBPHeader;
        private readonly IMapper _mapper;

        public RFCSBPHeaderGetQueryHandler(IGenericRepositoryAsync<RFCSBPHeader> RFCSBPHeader, IMapper mapper)
        {
            _RFCSBPHeader = RFCSBPHeader;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFCSBPHeaderResponseDto>> Handle(RFCSBPHeaderGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFCSBPHeader.GetByIdAsync(request.CSBPGroupID, "CSBPGroupID");
                if (data == null)
                    return ServiceResponse<RFCSBPHeaderResponseDto>.Return404("Data RFCSBPHeader not found");
                var response = _mapper.Map<RFCSBPHeaderResponseDto>(data);
                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnException(ex);
            }
        }
    }
}