using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPilihanPemutuss;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPilihanPemutuss.Commands
{
    public class RFPilihanPemutusPutCommand : RFPilihanPemutusPutRequestDto, IRequest<ServiceResponse<RFPilihanPemutusResponseDto>>
    {
    }

    public class PutRFPilihanPemutusCommandHandler : IRequestHandler<RFPilihanPemutusPutCommand, ServiceResponse<RFPilihanPemutusResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPilihanPemutus> _RFPilihanPemutus;
        private readonly IMapper _mapper;

        public PutRFPilihanPemutusCommandHandler(IGenericRepositoryAsync<RFPilihanPemutus> RFPilihanPemutus, IMapper mapper)
        {
            _RFPilihanPemutus = RFPilihanPemutus;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPilihanPemutusResponseDto>> Handle(RFPilihanPemutusPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFPilihanPemutus = await _RFPilihanPemutus.GetByIdAsync(request.PemCode, "PemCode");
                
                existingRFPilihanPemutus.PemDesc = request.PemDesc;
                existingRFPilihanPemutus.CoreCode = request.CoreCode;
                existingRFPilihanPemutus.Active = request.Active;

                await _RFPilihanPemutus.UpdateAsync(existingRFPilihanPemutus);

                var response = _mapper.Map<RFPilihanPemutusResponseDto>(existingRFPilihanPemutus);

                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}