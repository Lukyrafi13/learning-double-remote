using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFHOMESTAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFHOMESTAs.Queries
{
    public class RFHOMESTAGetQuery : RFHOMESTAFindRequestDto, IRequest<ServiceResponse<RFHOMESTAResponseDto>>
    {
    }

    public class RFHOMESTAGetQueryHandler : IRequestHandler<RFHOMESTAGetQuery, ServiceResponse<RFHOMESTAResponseDto>>
    {
        private IGenericRepositoryAsync<RFHOMESTA> _RFHOMESTA;
        private readonly IMapper _mapper;

        public RFHOMESTAGetQueryHandler(IGenericRepositoryAsync<RFHOMESTA> RFHOMESTA, IMapper mapper)
        {
            _RFHOMESTA = RFHOMESTA;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFHOMESTAResponseDto>> Handle(RFHOMESTAGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFHOMESTA.GetByIdAsync(request.HMSTA_CODE, "HMSTA_CODE");
                if (data == null)
                    return ServiceResponse<RFHOMESTAResponseDto>.Return404("Data RFHOMESTA not found");
                var response = _mapper.Map<RFHOMESTAResponseDto>(data);
                return ServiceResponse<RFHOMESTAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFHOMESTAResponseDto>.ReturnException(ex);
            }
        }
    }
}