using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBusinessTypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBusinessTypes.Commands
{
    public class RFBusinessTypePostCommand : RFBusinessTypePostRequestDto, IRequest<ServiceResponse<RFBusinessTypeResponseDto>>
    {

    }
    public class RFBusinessTypePostCommandHandler : IRequestHandler<RFBusinessTypePostCommand, ServiceResponse<RFBusinessTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBusinessType> _RFBusinessType;
        private readonly IMapper _mapper;

        public RFBusinessTypePostCommandHandler(IGenericRepositoryAsync<RFBusinessType> RFBusinessType, IMapper mapper)
        {
            _RFBusinessType = RFBusinessType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBusinessTypeResponseDto>> Handle(RFBusinessTypePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBusinessType = _mapper.Map<RFBusinessType>(request);

                var returnedRFBusinessType = await _RFBusinessType.AddAsync(RFBusinessType, callSave: false);

                // var response = _mapper.Map<RFBusinessTypeResponseDto>(returnedRFBusinessType);
                var response = _mapper.Map<RFBusinessTypeResponseDto>(returnedRFBusinessType);

                await _RFBusinessType.SaveChangeAsync();
                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}