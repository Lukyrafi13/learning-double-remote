using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenors.Commands
{
    public class RFTenorPutCommand : RFTenorPutRequestDto, IRequest<ServiceResponse<RFTenorResponseDto>>
    {
    }

    public class PutRFTenorCommandHandler : IRequestHandler<RFTenorPutCommand, ServiceResponse<RFTenorResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public PutRFTenorCommandHandler(IGenericRepositoryAsync<RFTenor> RFTenor, IMapper mapper){
            _RFTenor = RFTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTenorResponseDto>> Handle(RFTenorPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTenor = await _RFTenor.GetByIdAsync(request.TNCode, "TNCode");
                existingRFTenor.TNCode = request.TNCode;
                existingRFTenor.TNDesc = request.TNDesc;
                existingRFTenor.Tenor = request.Tenor;
                existingRFTenor.CoreCode = request.CoreCode;
                existingRFTenor.Active = request.Active;
                existingRFTenor.Due = request.Due;
                existingRFTenor.ManDocNo = request.ManDocNo;
                existingRFTenor.ISTBO = request.ISTBO;
                existingRFTenor.Mandatory = request.Mandatory;
                existingRFTenor.ProductId = request.ProductId;
                
                await _RFTenor.UpdateAsync(existingRFTenor);

                var response = _mapper.Map<RFTenorResponseDto>(existingRFTenor);

                return ServiceResponse<RFTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}