using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBuktiKepemilikans.Commands
{
    public class RFBuktiKepemilikanPutCommand : RFBuktiKepemilikanPutRequestDto, IRequest<ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {
    }

    public class PutRFBuktiKepemilikanCommandHandler : IRequestHandler<RFBuktiKepemilikanPutCommand, ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBuktiKepemilikan> _RFBuktiKepemilikan;
        private readonly IMapper _mapper;

        public PutRFBuktiKepemilikanCommandHandler(IGenericRepositoryAsync<RFBuktiKepemilikan> RFBuktiKepemilikan, IMapper mapper){
            _RFBuktiKepemilikan = RFBuktiKepemilikan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBuktiKepemilikanResponseDto>> Handle(RFBuktiKepemilikanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBuktiKepemilikan = await _RFBuktiKepemilikan.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFBuktiKepemilikan.ANL_CODE = request.ANL_CODE;
                existingRFBuktiKepemilikan.ANL_DESC = request.ANL_DESC;
                existingRFBuktiKepemilikan.CORE_CODE = request.CORE_CODE;
                existingRFBuktiKepemilikan.ACTIVE = request.ACTIVE;
                
                await _RFBuktiKepemilikan.UpdateAsync(existingRFBuktiKepemilikan);

                var response = _mapper.Map<RFBuktiKepemilikanResponseDto>(existingRFBuktiKepemilikan);

                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}