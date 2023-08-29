using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Commands
{
    public class RfAppTypePutCommand : RfAppTypePutRequestDto, IRequest<ServiceResponse<RfAppTypeResponseDto>>
    {
    }

    public class PutRfAppTypeCommandHandler : IRequestHandler<RfAppTypePutCommand, ServiceResponse<RfAppTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfAppType> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public PutRfAppTypeCommandHandler(IGenericRepositoryAsync<RfAppType> rfJenisPermohonan, IMapper mapper){
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfAppTypeResponseDto>> Handle(RfAppTypePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfAppType = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");
                
                existingRfAppType.Type = request.Type;
                
                await _rfJenisPermohonan.UpdateAsync(existingRfAppType);

                var response = _mapper.Map<RfAppTypeResponseDto>(existingRfAppType);

                return ServiceResponse<RfAppTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfAppTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}