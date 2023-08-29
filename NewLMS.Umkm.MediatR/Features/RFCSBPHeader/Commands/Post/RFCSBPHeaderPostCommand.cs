using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCSBPHeaders;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPHeaders.Commands
{
    public class RFCSBPHeaderPostCommand : RFCSBPHeaderPostRequestDto, IRequest<ServiceResponse<RFCSBPHeaderResponseDto>>
    {

    }
    public class PostRFCSBPHeaderCommandHandler : IRequestHandler<RFCSBPHeaderPostCommand, ServiceResponse<RFCSBPHeaderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPHeader> _RFCSBPHeader;
        private readonly IMapper _mapper;

        public PostRFCSBPHeaderCommandHandler(IGenericRepositoryAsync<RFCSBPHeader> RFCSBPHeader, IMapper mapper)
        {
            _RFCSBPHeader = RFCSBPHeader;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCSBPHeaderResponseDto>> Handle(RFCSBPHeaderPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFCSBPHeader = _mapper.Map<RFCSBPHeader>(request);

                var returnedRFCSBPHeader = await _RFCSBPHeader.AddAsync(RFCSBPHeader, callSave: false);

                // var response = _mapper.Map<RFCSBPHeaderResponseDto>(returnedRFCSBPHeader);
                var response = _mapper.Map<RFCSBPHeaderResponseDto>(returnedRFCSBPHeader);

                await _RFCSBPHeader.SaveChangeAsync();
                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}