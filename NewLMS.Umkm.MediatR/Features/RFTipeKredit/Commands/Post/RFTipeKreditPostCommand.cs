using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Commands
{
    public class RfCreditTypePostCommand : RfCreditTypePostRequestDto, IRequest<ServiceResponse<RfCreditTypeResponseDto>>
    {

    }
    public class RfCreditTypePostCommandHandler : IRequestHandler<RfCreditTypePostCommand, ServiceResponse<RfCreditTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCreditType> _RfCreditType;
        private readonly IMapper _mapper;

        public RfCreditTypePostCommandHandler(IGenericRepositoryAsync<RfCreditType> RfCreditType, IMapper mapper)
        {
            _RfCreditType = RfCreditType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCreditTypeResponseDto>> Handle(RfCreditTypePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCreditType = _mapper.Map<RfCreditType>(request);

                var returnedRfCreditType = await _RfCreditType.AddAsync(RfCreditType, callSave: false);

                // var response = _mapper.Map<RfCreditTypeResponseDto>(returnedRfCreditType);
                var response = _mapper.Map<RfCreditTypeResponseDto>(returnedRfCreditType);

                await _RfCreditType.SaveChangeAsync();
                return ServiceResponse<RfCreditTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCreditTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}