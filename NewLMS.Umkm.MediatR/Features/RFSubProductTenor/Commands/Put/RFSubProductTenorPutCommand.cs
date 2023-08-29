using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProductTenors;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductTenors.Commands
{
    public class RFSubProductTenorPutCommand : RFSubProductTenorPutRequestDto, IRequest<ServiceResponse<RFSubProductTenorResponseDto>>
    {
    }

    public class PutRFSubProductTenorCommandHandler : IRequestHandler<RFSubProductTenorPutCommand, ServiceResponse<RFSubProductTenorResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private readonly IMapper _mapper;

        public PutRFSubProductTenorCommandHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper){
            _RFSubProductTenor = RFSubProductTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductTenorResponseDto>> Handle(RFSubProductTenorPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSubProductTenor = await _RFSubProductTenor.GetByIdAsync(request.Id, "Id");
                existingRFSubProductTenor.SubProductId = request.SubProductId;
                existingRFSubProductTenor.TNCode = request.TNCode;
                existingRFSubProductTenor.Active = request.Active;
                
                await _RFSubProductTenor.UpdateAsync(existingRFSubProductTenor);

                var response = _mapper.Map<RFSubProductTenorResponseDto>(existingRFSubProductTenor);

                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}