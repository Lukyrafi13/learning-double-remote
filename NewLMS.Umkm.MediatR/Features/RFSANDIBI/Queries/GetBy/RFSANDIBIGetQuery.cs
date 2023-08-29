using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSANDIBIS;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSANDIBIS.Queries
{
    public class RFSANDIBIGetQuery : RFSANDIBIFindRequestDto, IRequest<ServiceResponse<RFSANDIBIResponseDto>>
    {
    }

    public class RFSANDIBIGetQueryHandler : IRequestHandler<RFSANDIBIGetQuery, ServiceResponse<RFSANDIBIResponseDto>>
    {
        private IGenericRepositoryAsync<RFSANDIBI> _RFSANDIBI;
        private readonly IMapper _mapper;

        public RFSANDIBIGetQueryHandler(IGenericRepositoryAsync<RFSANDIBI> RFSANDIBI, IMapper mapper)
        {
            _RFSANDIBI = RFSANDIBI;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSANDIBIResponseDto>> Handle(RFSANDIBIGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSANDIBI.GetByIdAsync(request.BI_CODE, "BI_CODE");
                if (data == null)
                    return ServiceResponse<RFSANDIBIResponseDto>.Return404("Data RFSANDIBI not found");
                var response = _mapper.Map<RFSANDIBIResponseDto>(data);
                return ServiceResponse<RFSANDIBIResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSANDIBIResponseDto>.ReturnException(ex);
            }
        }
    }
}