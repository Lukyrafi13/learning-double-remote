using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisDuplikasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFJenisDuplikasis.Queries
{
    public class RFJenisDuplikasiGetQuery : RFJenisDuplikasiFindRequestDto, IRequest<ServiceResponse<RFJenisDuplikasiResponseDto>>
    {
    }

    public class RFJenisDuplikasiGetQueryHandler : IRequestHandler<RFJenisDuplikasiGetQuery, ServiceResponse<RFJenisDuplikasiResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        private readonly IMapper _mapper;

        public RFJenisDuplikasiGetQueryHandler(IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi, IMapper mapper)
        {
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisDuplikasiResponseDto>> Handle(RFJenisDuplikasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFJenisDuplikasi.GetByIdAsync(request.JenisCode, "JenisCode");
                if (data == null)
                    return ServiceResponse<RFJenisDuplikasiResponseDto>.Return404("Data RFJenisDuplikasi not found");
                var response = _mapper.Map<RFJenisDuplikasiResponseDto>(data);
                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnException(ex);
            }
        }
    }
}