using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPengikatanKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFPengikatanKredits.Queries
{
    public class RFPengikatanKreditGetQuery : RFPengikatanKreditFindRequestDto, IRequest<ServiceResponse<RFPengikatanKreditResponseDto>>
    {
    }

    public class RFPengikatanKreditGetQueryHandler : IRequestHandler<RFPengikatanKreditGetQuery, ServiceResponse<RFPengikatanKreditResponseDto>>
    {
        private IGenericRepositoryAsync<RFPengikatanKredit> _RFPengikatanKredit;
        private readonly IMapper _mapper;

        public RFPengikatanKreditGetQueryHandler(IGenericRepositoryAsync<RFPengikatanKredit> RFPengikatanKredit, IMapper mapper)
        {
            _RFPengikatanKredit = RFPengikatanKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFPengikatanKreditResponseDto>> Handle(RFPengikatanKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFPengikatanKredit.GetByIdAsync(request.PK_CODE, "PK_CODE");
                if (data == null)
                    return ServiceResponse<RFPengikatanKreditResponseDto>.Return404("Data RFPengikatanKredit not found");
                var response = _mapper.Map<RFPengikatanKreditResponseDto>(data);
                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}