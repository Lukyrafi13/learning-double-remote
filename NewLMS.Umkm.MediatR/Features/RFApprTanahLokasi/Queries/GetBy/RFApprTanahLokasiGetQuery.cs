using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTanahLokasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLokasis.Queries
{
    public class RFApprTanahLokasiGetQuery : RFApprTanahLokasiFindRequestDto, IRequest<ServiceResponse<RFApprTanahLokasiResponseDto>>
    {
    }

    public class RFApprTanahLokasiGetQueryHandler : IRequestHandler<RFApprTanahLokasiGetQuery, ServiceResponse<RFApprTanahLokasiResponseDto>>
    {
        private IGenericRepositoryAsync<RFApprTanahLokasi> _RFApprTanahLokasi;
        private readonly IMapper _mapper;

        public RFApprTanahLokasiGetQueryHandler(IGenericRepositoryAsync<RFApprTanahLokasi> RFApprTanahLokasi, IMapper mapper)
        {
            _RFApprTanahLokasi = RFApprTanahLokasi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFApprTanahLokasiResponseDto>> Handle(RFApprTanahLokasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFApprTanahLokasi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                if (data == null)
                    return ServiceResponse<RFApprTanahLokasiResponseDto>.Return404("Data RFApprTanahLokasi not found");
                var response = _mapper.Map<RFApprTanahLokasiResponseDto>(data);
                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnException(ex);
            }
        }
    }
}