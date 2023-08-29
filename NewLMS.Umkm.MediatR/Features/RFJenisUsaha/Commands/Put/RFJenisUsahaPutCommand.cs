using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Commands
{
    public class RFJenisUsahaPutCommand : RFJenisUsahaPutRequestDto, IRequest<ServiceResponse<RFJenisUsahaResponseDto>>
    {
    }

    public class PutRFJenisUsahaCommandHandler : IRequestHandler<RFJenisUsahaPutCommand, ServiceResponse<RFJenisUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public PutRFJenisUsahaCommandHandler(IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaResponseDto>> Handle(RFJenisUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisUsaha = await _RFJenisUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFJenisUsaha.ANL_CODE = request.ANL_CODE;
                existingRFJenisUsaha.ANL_DESC = request.ANL_DESC;
                existingRFJenisUsaha.CORE_CODE = request.CORE_CODE;
                existingRFJenisUsaha.ACTIVE = request.ACTIVE;

                await _RFJenisUsaha.UpdateAsync(existingRFJenisUsaha);

                var response = _mapper.Map<RFJenisUsahaResponseDto>(existingRFJenisUsaha);

                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}