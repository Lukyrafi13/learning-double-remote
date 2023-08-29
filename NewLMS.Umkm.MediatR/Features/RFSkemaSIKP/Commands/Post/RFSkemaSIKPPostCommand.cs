using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSkemaSIKPs.Commands
{
    public class RFSkemaSIKPPostCommand : RFSkemaSIKPPostRequestDto, IRequest<ServiceResponse<RFSkemaSIKPResponseDto>>
    {

    }
    public class PostRFSkemaSIKPCommandHandler : IRequestHandler<RFSkemaSIKPPostCommand, ServiceResponse<RFSkemaSIKPResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public PostRFSkemaSIKPCommandHandler(IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP, IMapper mapper)
        {
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSkemaSIKPResponseDto>> Handle(RFSkemaSIKPPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSkemaSIKP = _mapper.Map<RFSkemaSIKP>(request);

                var returnedRFSkemaSIKP = await _RFSkemaSIKP.AddAsync(RFSkemaSIKP, callSave: false);

                // var response = _mapper.Map<RFSkemaSIKPResponseDto>(returnedRFSkemaSIKP);
                var response = _mapper.Map<RFSkemaSIKPResponseDto>(returnedRFSkemaSIKP);

                await _RFSkemaSIKP.SaveChangeAsync();
                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}