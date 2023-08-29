using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFCaraPengikatans.Commands
{
    public class RFCaraPengikatanPutCommand : RFCaraPengikatanPutRequestDto, IRequest<ServiceResponse<RFCaraPengikatanResponseDto>>
    {
    }

    public class PutRFCaraPengikatanCommandHandler : IRequestHandler<RFCaraPengikatanPutCommand, ServiceResponse<RFCaraPengikatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCaraPengikatan> _RFCaraPengikatan;
        private readonly IMapper _mapper;

        public PutRFCaraPengikatanCommandHandler(IGenericRepositoryAsync<RFCaraPengikatan> RFCaraPengikatan, IMapper mapper)
        {
            _RFCaraPengikatan = RFCaraPengikatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCaraPengikatanResponseDto>> Handle(RFCaraPengikatanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFCaraPengikatan = await _RFCaraPengikatan.GetByIdAsync(request.PK_CODE, "PK_CODE");
                existingRFCaraPengikatan.PK_CODE = request.PK_CODE;
                existingRFCaraPengikatan.PK_DESC = request.PK_DESC;
                existingRFCaraPengikatan.CORE_CODE = request.CORE_CODE;
                existingRFCaraPengikatan.ACTIVE = request.ACTIVE;

                await _RFCaraPengikatan.UpdateAsync(existingRFCaraPengikatan);

                var response = _mapper.Map<RFCaraPengikatanResponseDto>(existingRFCaraPengikatan);

                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}