using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Commands
{
    public class RFKepemilikanTUPutCommand : RFKepemilikanTUPutRequestDto, IRequest<ServiceResponse<RFKepemilikanTUResponseDto>>
    {
    }

    public class PutRFKepemilikanTUCommandHandler : IRequestHandler<RFKepemilikanTUPutCommand, ServiceResponse<RFKepemilikanTUResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanTU> _RFKepemilikanTU;
        private readonly IMapper _mapper;

        public PutRFKepemilikanTUCommandHandler(IGenericRepositoryAsync<RFKepemilikanTU> RFKepemilikanTU, IMapper mapper)
        {
            _RFKepemilikanTU = RFKepemilikanTU;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKepemilikanTUResponseDto>> Handle(RFKepemilikanTUPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFKepemilikanTU = await _RFKepemilikanTU.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFKepemilikanTU.ANL_CODE = request.ANL_CODE;
                existingRFKepemilikanTU.ANL_DESC = request.ANL_DESC;
                existingRFKepemilikanTU.LOKASITEMPATUSAHA = request.LOKASITEMPATUSAHA;
                existingRFKepemilikanTU.CORE_CODE = request.CORE_CODE;
                existingRFKepemilikanTU.ACTIVE = request.ACTIVE;

                await _RFKepemilikanTU.UpdateAsync(existingRFKepemilikanTU);

                var response = _mapper.Map<RFKepemilikanTUResponseDto>(existingRFKepemilikanTU);

                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}