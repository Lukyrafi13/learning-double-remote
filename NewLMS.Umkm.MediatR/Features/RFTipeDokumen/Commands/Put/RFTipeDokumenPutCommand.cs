using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTipeDokumens;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTipeDokumens.Commands
{
    public class RFTipeDokumenPutCommand : RFTipeDokumenPutRequestDto, IRequest<ServiceResponse<RFTipeDokumenResponseDto>>
    {
    }

    public class PutRFTipeDokumenCommandHandler : IRequestHandler<RFTipeDokumenPutCommand, ServiceResponse<RFTipeDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IMapper _mapper;

        public PutRFTipeDokumenCommandHandler(IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen, IMapper mapper)
        {
            _RFTipeDokumen = RFTipeDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTipeDokumenResponseDto>> Handle(RFTipeDokumenPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTipeDokumen = await _RFTipeDokumen.GetByIdAsync(request.TypeCode, "TypeCode");
                
                existingRFTipeDokumen.TypeDesc = request.TypeDesc;
                existingRFTipeDokumen.Active = request.Active;
                await _RFTipeDokumen.UpdateAsync(existingRFTipeDokumen);

                var response = _mapper.Map<RFTipeDokumenResponseDto>(existingRFTipeDokumen);

                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}