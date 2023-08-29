using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductInts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductInts.Queries
{
    public class RFSubProductIntGetQuery : RFSubProductIntFindRequestDto, IRequest<ServiceResponse<RFSubProductIntResponseDto>>
    {
    }

    public class RFSubProductIntGetQueryHandler : IRequestHandler<RFSubProductIntGetQuery, ServiceResponse<RFSubProductIntResponseDto>>
    {
        private IGenericRepositoryAsync<RFSubProductInt> _RFSubProductInt;
        private readonly IMapper _mapper;

        public RFSubProductIntGetQueryHandler(IGenericRepositoryAsync<RFSubProductInt> RFSubProductInt, IMapper mapper)
        {
            _RFSubProductInt = RFSubProductInt;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSubProductIntResponseDto>> Handle(RFSubProductIntGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSubProductInt.GetByIdAsync(request.TPLCode, "TPLCode");
                if (data == null)
                    return ServiceResponse<RFSubProductIntResponseDto>.Return404("Data RFSubProductInt not found");
                var response = _mapper.Map<RFSubProductIntResponseDto>(data);
                return ServiceResponse<RFSubProductIntResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductIntResponseDto>.ReturnException(ex);
            }
        }
    }
}