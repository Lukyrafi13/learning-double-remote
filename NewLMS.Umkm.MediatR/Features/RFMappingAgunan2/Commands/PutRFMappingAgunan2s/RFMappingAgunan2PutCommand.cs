using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFMappingAgunan2s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFMappingAgunan2s.Commands
{
    public class RFMappingAgunan2PutCommand : RFMappingAgunan2PutRequestDto, IRequest<ServiceResponse<RFMappingAgunan2ResponseDto>>
    {
    }

    public class PutRFMappingAgunan2CommandHandler : IRequestHandler<RFMappingAgunan2PutCommand, ServiceResponse<RFMappingAgunan2ResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingAgunan2> _RFMappingAgunan2;
        private readonly IMapper _mapper;

        public PutRFMappingAgunan2CommandHandler(IGenericRepositoryAsync<RFMappingAgunan2> RFMappingAgunan2, IMapper mapper){
            _RFMappingAgunan2 = RFMappingAgunan2;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingAgunan2ResponseDto>> Handle(RFMappingAgunan2PutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFMappingAgunan2 = await _RFMappingAgunan2.GetByIdAsync(request.ColCode, "ColCode");
                existingRFMappingAgunan2.ProductId = request.ProductId;
                existingRFMappingAgunan2.ColCode = request.ColCode;
                existingRFMappingAgunan2.ColDesc = request.ColDesc;
                existingRFMappingAgunan2.Active = request.Active;
                
                await _RFMappingAgunan2.UpdateAsync(existingRFMappingAgunan2);

                var response = _mapper.Map<RFMappingAgunan2ResponseDto>(existingRFMappingAgunan2);

                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}