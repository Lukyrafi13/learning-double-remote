using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOSALDOREKRATAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSALDOREKRATAs.Commands
{
    public class RFSCOSALDOREKRATAPostCommand : RFSCOSALDOREKRATAPostRequestDto, IRequest<ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {

    }
    public class PostRFSCOSALDOREKRATACommandHandler : IRequestHandler<RFSCOSALDOREKRATAPostCommand, ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSALDOREKRATA> _RFSCOSALDOREKRATA;
        private readonly IMapper _mapper;

        public PostRFSCOSALDOREKRATACommandHandler(IGenericRepositoryAsync<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA, IMapper mapper)
        {
            _RFSCOSALDOREKRATA = RFSCOSALDOREKRATA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOSALDOREKRATAResponseDto>> Handle(RFSCOSALDOREKRATAPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOSALDOREKRATA = _mapper.Map<RFSCOSALDOREKRATA>(request);

                var returnedRFSCOSALDOREKRATA = await _RFSCOSALDOREKRATA.AddAsync(RFSCOSALDOREKRATA, callSave: false);

                // var response = _mapper.Map<RFSCOSALDOREKRATAResponseDto>(returnedRFSCOSALDOREKRATA);
                var response = _mapper.Map<RFSCOSALDOREKRATAResponseDto>(returnedRFSCOSALDOREKRATA);

                await _RFSCOSALDOREKRATA.SaveChangeAsync();
                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}