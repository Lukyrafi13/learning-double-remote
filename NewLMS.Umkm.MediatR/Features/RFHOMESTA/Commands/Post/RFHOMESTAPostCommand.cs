using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFHOMESTAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFHOMESTAs.Commands
{
    public class RFHOMESTAPostCommand : RFHOMESTAPostRequestDto, IRequest<ServiceResponse<RFHOMESTAResponseDto>>
    {

    }
    public class PostRFHOMESTACommandHandler : IRequestHandler<RFHOMESTAPostCommand, ServiceResponse<RFHOMESTAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFHOMESTA> _RFHOMESTA;
        private readonly IMapper _mapper;

        public PostRFHOMESTACommandHandler(IGenericRepositoryAsync<RFHOMESTA> RFHOMESTA, IMapper mapper)
        {
            _RFHOMESTA = RFHOMESTA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFHOMESTAResponseDto>> Handle(RFHOMESTAPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFHOMESTA = _mapper.Map<RFHOMESTA>(request);

                var returnedRFHOMESTA = await _RFHOMESTA.AddAsync(RFHOMESTA, callSave: false);

                // var response = _mapper.Map<RFHOMESTAResponseDto>(returnedRFHOMESTA);
                var response = _mapper.Map<RFHOMESTAResponseDto>(returnedRFHOMESTA);

                await _RFHOMESTA.SaveChangeAsync();
                return ServiceResponse<RFHOMESTAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFHOMESTAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}