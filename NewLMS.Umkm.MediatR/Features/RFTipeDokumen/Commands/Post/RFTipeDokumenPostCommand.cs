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
    public class RFTipeDokumenPostCommand : RFTipeDokumenPostRequestDto, IRequest<ServiceResponse<RFTipeDokumenResponseDto>>
    {

    }
    public class RFTipeDokumenPostCommandHandler : IRequestHandler<RFTipeDokumenPostCommand, ServiceResponse<RFTipeDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IMapper _mapper;

        public RFTipeDokumenPostCommandHandler(IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen, IMapper mapper)
        {
            _RFTipeDokumen = RFTipeDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTipeDokumenResponseDto>> Handle(RFTipeDokumenPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTipeDokumen = _mapper.Map<RFTipeDokumen>(request);

                var returnedRFTipeDokumen = await _RFTipeDokumen.AddAsync(RFTipeDokumen, callSave: false);

                // var response = _mapper.Map<RFTipeDokumenResponseDto>(returnedRFTipeDokumen);
                var response = _mapper.Map<RFTipeDokumenResponseDto>(returnedRFTipeDokumen);

                await _RFTipeDokumen.SaveChangeAsync();
                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}