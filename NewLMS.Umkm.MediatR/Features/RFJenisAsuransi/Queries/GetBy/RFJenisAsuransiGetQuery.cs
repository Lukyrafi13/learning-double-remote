using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisAsuransis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAsuransis.Queries
{
    public class RFJenisAsuransiGetQuery : RFJenisAsuransiFindRequestDto, IRequest<ServiceResponse<RFJenisAsuransiResponseDto>>
    {
    }

    public class RFJenisAsuransiGetQueryHandler : IRequestHandler<RFJenisAsuransiGetQuery, ServiceResponse<RFJenisAsuransiResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisAsuransi> _RFJenisAsuransi;
        private readonly IMapper _mapper;

        public RFJenisAsuransiGetQueryHandler(IGenericRepositoryAsync<RFJenisAsuransi> RFJenisAsuransi, IMapper mapper)
        {
            _RFJenisAsuransi = RFJenisAsuransi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisAsuransiResponseDto>> Handle(RFJenisAsuransiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFJenisAsuransi.GetByIdAsync(request.JenisCode, "JenisCode");
                if (data == null)
                    return ServiceResponse<RFJenisAsuransiResponseDto>.Return404("Data RFJenisAsuransi not found");
                var response = _mapper.Map<RFJenisAsuransiResponseDto>(data);
                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAsuransiResponseDto>.ReturnException(ex);
            }
        }
    }
}