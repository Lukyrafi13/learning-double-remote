using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLokasiUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiUsahas.Commands
{
    public class RFLokasiUsahaPutCommand : RFLokasiUsahaPutRequestDto, IRequest<ServiceResponse<RFLokasiUsahaResponseDto>>
    {
    }

    public class PutRFLokasiUsahaCommandHandler : IRequestHandler<RFLokasiUsahaPutCommand, ServiceResponse<RFLokasiUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiUsaha> _RFLokasiUsaha;
        private readonly IMapper _mapper;

        public PutRFLokasiUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiUsaha> RFLokasiUsaha, IMapper mapper){
            _RFLokasiUsaha = RFLokasiUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLokasiUsahaResponseDto>> Handle(RFLokasiUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFLokasiUsaha = await _RFLokasiUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFLokasiUsaha.ANL_CODE = request.ANL_CODE;
                existingRFLokasiUsaha.ANL_DESC = request.ANL_DESC;
                existingRFLokasiUsaha.CORE_CODE = request.CORE_CODE;
                existingRFLokasiUsaha.ACTIVE = request.ACTIVE;
                
                await _RFLokasiUsaha.UpdateAsync(existingRFLokasiUsaha);

                var response = _mapper.Map<RFLokasiUsahaResponseDto>(existingRFLokasiUsaha);

                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}