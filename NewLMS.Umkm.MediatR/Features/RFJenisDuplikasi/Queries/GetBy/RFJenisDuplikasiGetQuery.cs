using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Queries
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