using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Commands
{
    public class RFKelompokUsahaPutCommand : RFKelompokUsahaPutRequestDto, IRequest<ServiceResponse<RFKelompokUsahaResponseDto>>
    {
    }

    public class PutRFKelompokUsahaCommandHandler : IRequestHandler<RFKelompokUsahaPutCommand, ServiceResponse<RFKelompokUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKelompokUsaha> _RFKelompokUsaha;
        private readonly IMapper _mapper;

        public PutRFKelompokUsahaCommandHandler(IGenericRepositoryAsync<RFKelompokUsaha> RFKelompokUsaha, IMapper mapper){
            _RFKelompokUsaha = RFKelompokUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKelompokUsahaResponseDto>> Handle(RFKelompokUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFKelompokUsaha = await _RFKelompokUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFKelompokUsaha.ANL_CODE = request.ANL_CODE;
                existingRFKelompokUsaha.ANL_DESC = request.ANL_DESC;
                existingRFKelompokUsaha.CORE_CODE = request.CORE_CODE;
                existingRFKelompokUsaha.ACTIVE = request.ACTIVE;
                
                await _RFKelompokUsaha.UpdateAsync(existingRFKelompokUsaha);

                var response = _mapper.Map<RFKelompokUsahaResponseDto>(existingRFKelompokUsaha);

                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}