using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLokasiTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiTempatUsahas.Commands
{
    public class RFLokasiTempatUsahaPutCommand : RFLokasiTempatUsahaPutRequestDto, IRequest<ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {
    }

    public class PutRFLokasiTempatUsahaCommandHandler : IRequestHandler<RFLokasiTempatUsahaPutCommand, ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiTempatUsaha> _RFLokasiTempatUsaha;
        private readonly IMapper _mapper;

        public PutRFLokasiTempatUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiTempatUsaha> RFLokasiTempatUsaha, IMapper mapper){
            _RFLokasiTempatUsaha = RFLokasiTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLokasiTempatUsahaResponseDto>> Handle(RFLokasiTempatUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFLokasiTempatUsaha = await _RFLokasiTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFLokasiTempatUsaha.ANL_CODE = request.ANL_CODE;
                existingRFLokasiTempatUsaha.ANL_DESC = request.ANL_DESC;
                existingRFLokasiTempatUsaha.CORE_CODE = request.CORE_CODE;
                existingRFLokasiTempatUsaha.ACTIVE = request.ACTIVE;
                
                await _RFLokasiTempatUsaha.UpdateAsync(existingRFLokasiTempatUsaha);

                var response = _mapper.Map<RFLokasiTempatUsahaResponseDto>(existingRFLokasiTempatUsaha);

                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}