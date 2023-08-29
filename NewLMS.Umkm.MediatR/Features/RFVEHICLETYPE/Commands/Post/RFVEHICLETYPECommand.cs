using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Commands
{
    public class RFVEHICLETYPEPostCommand : RFVEHICLETYPEPostRequestDto, IRequest<ServiceResponse<RFVEHICLETYPEResponseDto>>
    {

    }
    public class PostRFVEHICLETYPECommandHandler : IRequestHandler<RFVEHICLETYPEPostCommand, ServiceResponse<RFVEHICLETYPEResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHICLETYPEs> _RFVEHICLETYPEs;
        private readonly IMapper _mapper;

        public PostRFVEHICLETYPECommandHandler(IGenericRepositoryAsync<RFVEHICLETYPEs> RFVEHICLETYPEs, IMapper mapper)
        {
            _RFVEHICLETYPEs = RFVEHICLETYPEs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHICLETYPEResponseDto>> Handle(RFVEHICLETYPEPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFVEHICLETYPE = _mapper.Map<RFVEHICLETYPEs>(request);

                var returnedRFVEHICLETYPE = await _RFVEHICLETYPEs.AddAsync(RFVEHICLETYPE, callSave: false);

                // var response = _mapper.Map<RFVEHICLETYPEResponseDto>(returnedRFVEHICLETYPE);
                var response = _mapper.Map<RFVEHICLETYPEResponseDto>(returnedRFVEHICLETYPE);

                await _RFVEHICLETYPEs.SaveChangeAsync();
                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}