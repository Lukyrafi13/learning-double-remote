using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPaymentMethods;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPaymentMethods.Commands
{
    public class RFPaymentMethodPostCommand : RFPaymentMethodPostRequestDto, IRequest<ServiceResponse<RFPaymentMethodResponseDto>>
    {

    }
    public class RFPaymentMethodPostCommandHandler : IRequestHandler<RFPaymentMethodPostCommand, ServiceResponse<RFPaymentMethodResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPaymentMethod> _RFPaymentMethod;
        private readonly IMapper _mapper;

        public RFPaymentMethodPostCommandHandler(IGenericRepositoryAsync<RFPaymentMethod> RFPaymentMethod, IMapper mapper)
        {
            _RFPaymentMethod = RFPaymentMethod;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPaymentMethodResponseDto>> Handle(RFPaymentMethodPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFPaymentMethod = _mapper.Map<RFPaymentMethod>(request);

                var returnedRFPaymentMethod = await _RFPaymentMethod.AddAsync(RFPaymentMethod, callSave: false);

                // var response = _mapper.Map<RFPaymentMethodResponseDto>(returnedRFPaymentMethod);
                var response = _mapper.Map<RFPaymentMethodResponseDto>(returnedRFPaymentMethod);

                await _RFPaymentMethod.SaveChangeAsync();
                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}