using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Queries
{
    public class RFVEHICLETYPEGetQuery : RFVEHICLETYPEFindRequestDto, IRequest<ServiceResponse<RFVEHICLETYPEResponseDto>>
    {
    }

    public class RFVEHICLETYPEGetQueryHandler : IRequestHandler<RFVEHICLETYPEGetQuery, ServiceResponse<RFVEHICLETYPEResponseDto>>
    {
        private IGenericRepositoryAsync<RFVEHICLETYPEs> _RFVEHICLETYPE;
        private readonly IMapper _mapper;

        public RFVEHICLETYPEGetQueryHandler(IGenericRepositoryAsync<RFVEHICLETYPEs> RFVEHICLETYPE, IMapper mapper)
        {
            _RFVEHICLETYPE = RFVEHICLETYPE;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFVEHICLETYPEResponseDto>> Handle(RFVEHICLETYPEGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFVEHICLETYPE.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
                if (data == null)
                    return ServiceResponse<RFVEHICLETYPEResponseDto>.Return404("Data RFVEHICLETYPE not found");
                var response = _mapper.Map<RFVEHICLETYPEResponseDto>(data);
                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnException(ex);
            }
        }
    }
}