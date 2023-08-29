using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Queries
{
    public class RFVEHMAKERGetQuery : RFVEHMAKERFindRequestDto, IRequest<ServiceResponse<RFVEHMAKERResponseDto>>
    {
    }

    public class RFVEHMAKERGetQueryHandler : IRequestHandler<RFVEHMAKERGetQuery, ServiceResponse<RFVEHMAKERResponseDto>>
    {
        private IGenericRepositoryAsync<RFVEHMAKER> _RFVEHMAKER;
        private readonly IMapper _mapper;

        public RFVEHMAKERGetQueryHandler(IGenericRepositoryAsync<RFVEHMAKER> RFVEHMAKER, IMapper mapper)
        {
            _RFVEHMAKER = RFVEHMAKER;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFVEHMAKERResponseDto>> Handle(RFVEHMAKERGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFVEHMAKER.GetByIdAsync(request.VMKR_CODE, "VMKR_CODE");
                if (data == null)
                    return ServiceResponse<RFVEHMAKERResponseDto>.Return404("Data RFVEHMAKER not found");
                var response = _mapper.Map<RFVEHMAKERResponseDto>(data);
                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnException(ex);
            }
        }
    }
}