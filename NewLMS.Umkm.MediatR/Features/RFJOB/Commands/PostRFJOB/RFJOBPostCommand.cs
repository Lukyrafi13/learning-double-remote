using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Data.Dto.RFJOBs;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJOBs.Commands
{
    public class RFJOBSPostCommand : RFJOBPostRequestDto, IRequest<ServiceResponse<RFJOBResponseDto>>
    {

    }
    public class PostRFJOBCommandHandler : IRequestHandler<RFJOBSPostCommand, ServiceResponse<RFJOBResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJOB> _RFJOB;
        private readonly IMapper _mapper;

        public PostRFJOBCommandHandler(IGenericRepositoryAsync<RFJOB> RFJOB, IMapper mapper)
        {
            _RFJOB = RFJOB;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJOBResponseDto>> Handle(RFJOBSPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RFJOB = _mapper.Map<RFJOB>(request);

                var returnedRFJOB = await _RFJOB.AddAsync(RFJOB, callSave: false);

                // var response = _mapper.Map<RFProductResponseDto>(returnedRfProduct);
                var response = _mapper.Map<RFJOBResponseDto>(returnedRFJOB);

                await _RFJOB.SaveChangeAsync();
                return ServiceResponse<RFJOBResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJOBResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}