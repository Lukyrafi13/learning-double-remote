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
    public class RFCSBPHeaderPutCommand : RFCSBPHeaderPutRequestDto, IRequest<ServiceResponse<RFCSBPHeaderResponseDto>>
    {
    }

    public class PutRFCSBPHeaderCommandHandler : IRequestHandler<RFCSBPHeaderPutCommand, ServiceResponse<RFCSBPHeaderResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPHeader> _RfCSBPHeader;
        private readonly IMapper _mapper;

        public PutRFCSBPHeaderCommandHandler(IGenericRepositoryAsync<RFCSBPHeader> RfCSBPHeader, IMapper mapper)
        {
            _RfCSBPHeader = RfCSBPHeader;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCSBPHeaderResponseDto>> Handle(RFCSBPHeaderPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFCSBPHeader = await _RfCSBPHeader.GetByIdAsync(request.CSBPGroupID, "CSBPGroupID");

                existingRFCSBPHeader = _mapper.Map<RFCSBPHeaderPostRequestDto, RFCSBPHeader>(request, existingRFCSBPHeader);

                await _RfCSBPHeader.UpdateAsync(existingRFCSBPHeader);

                var response = _mapper.Map<RFCSBPHeaderResponseDto>(existingRFCSBPHeader);

                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPHeaderResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}