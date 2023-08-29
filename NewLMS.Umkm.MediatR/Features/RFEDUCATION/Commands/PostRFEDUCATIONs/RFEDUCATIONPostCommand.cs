using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFEDUCATIONs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFEDUCATIONs.Commands
{
    public class RFEDUCATIONPostCommand : RFEDUCATIONPostRequestDto, IRequest<ServiceResponse<RFEDUCATIONResponseDto>>
    {

    }
    public class PostRFEDUCATIONCommandHandler : IRequestHandler<RFEDUCATIONPostCommand, ServiceResponse<RFEDUCATIONResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private readonly IMapper _mapper;

        public PostRFEDUCATIONCommandHandler(IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION, IMapper mapper)
        {
            _RFEDUCATION = RFEDUCATION;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFEDUCATIONResponseDto>> Handle(RFEDUCATIONPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFEDUCATION = _mapper.Map<RFEDUCATION>(request);

                var returnedRFEDUCATION = await _RFEDUCATION.AddAsync(RFEDUCATION, callSave: false);

                // var response = _mapper.Map<RFEDUCATIONResponseDto>(returnedRfStatusTarget);
                var response = _mapper.Map<RFEDUCATIONResponseDto>(returnedRFEDUCATION);

                await _RFEDUCATION.SaveChangeAsync();
                return ServiceResponse<RFEDUCATIONResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFEDUCATIONResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}