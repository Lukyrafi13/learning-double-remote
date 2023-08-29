using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTanahLnkPertumbuhans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLnkPertumbuhans.Queries
{
    public class RFApprTanahLnkPertumbuhanGetQuery : RFApprTanahLnkPertumbuhanFindRequestDto, IRequest<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {
    }

    public class RFApprTanahLnkPertumbuhanGetQueryHandler : IRequestHandler<RFApprTanahLnkPertumbuhanGetQuery, ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {
        private IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> _RFApprTanahLnkPertumbuhan;
        private readonly IMapper _mapper;

        public RFApprTanahLnkPertumbuhanGetQueryHandler(IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> RFApprTanahLnkPertumbuhan, IMapper mapper)
        {
            _RFApprTanahLnkPertumbuhan = RFApprTanahLnkPertumbuhan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>> Handle(RFApprTanahLnkPertumbuhanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFApprTanahLnkPertumbuhan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                if (data == null)
                    return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.Return404("Data RFApprTanahLnkPertumbuhan not found");
                var response = _mapper.Map<RFApprTanahLnkPertumbuhanResponseDto>(data);
                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnException(ex);
            }
        }
    }
}