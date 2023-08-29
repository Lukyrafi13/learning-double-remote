using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Commands
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