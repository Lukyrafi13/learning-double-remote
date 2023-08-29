using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSatuanLuass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSatuanLuass.Queries
{
    public class RFSatuanLuasGetQuery : RFSatuanLuasFindRequestDto, IRequest<ServiceResponse<RFSatuanLuasResponseDto>>
    {
    }

    public class RFSatuanLuasGetQueryHandler : IRequestHandler<RFSatuanLuasGetQuery, ServiceResponse<RFSatuanLuasResponseDto>>
    {
        private IGenericRepositoryAsync<RFSatuanLuas> _RFSatuanLuas;
        private readonly IMapper _mapper;

        public RFSatuanLuasGetQueryHandler(IGenericRepositoryAsync<RFSatuanLuas> RFSatuanLuas, IMapper mapper)
        {
            _RFSatuanLuas = RFSatuanLuas;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSatuanLuasResponseDto>> Handle(RFSatuanLuasGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSatuanLuas.GetByIdAsync(request.SatuanLuas_Id, "SatuanLuas_Id");
                if (data == null)
                    return ServiceResponse<RFSatuanLuasResponseDto>.Return404("Data RFSatuanLuas not found");
                var response = _mapper.Map<RFSatuanLuasResponseDto>(data);
                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanLuasResponseDto>.ReturnException(ex);
            }
        }
    }
}