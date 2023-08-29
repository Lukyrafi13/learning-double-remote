using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Commands
{
    public class RFJenisTempatUsahaPutCommand : RFJenisTempatUsahaPutRequestDto, IRequest<ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {
    }

    public class PutRFJenisTempatUsahaCommandHandler : IRequestHandler<RFJenisTempatUsahaPutCommand, ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisTempatUsaha> _RFJenisTempatUsaha;
        private readonly IMapper _mapper;

        public PutRFJenisTempatUsahaCommandHandler(IGenericRepositoryAsync<RFJenisTempatUsaha> RFJenisTempatUsaha, IMapper mapper)
        {
            _RFJenisTempatUsaha = RFJenisTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisTempatUsahaResponseDto>> Handle(RFJenisTempatUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisTempatUsaha = await _RFJenisTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFJenisTempatUsaha.ANL_CODE = request.ANL_CODE;
                existingRFJenisTempatUsaha.ANL_DESC = request.ANL_DESC;
                existingRFJenisTempatUsaha.CORE_CODE = request.CORE_CODE;
                existingRFJenisTempatUsaha.ACTIVE = request.ACTIVE;
                existingRFJenisTempatUsaha.PRODUCTID = request.PRODUCTID;

                await _RFJenisTempatUsaha.UpdateAsync(existingRFJenisTempatUsaha);

                var response = _mapper.Map<RFJenisTempatUsahaResponseDto>(existingRFJenisTempatUsaha);

                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}