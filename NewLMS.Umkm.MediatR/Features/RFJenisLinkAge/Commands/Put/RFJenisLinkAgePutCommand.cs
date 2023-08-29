using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisLinkAges;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisLinkAges.Commands
{
    public class RFJenisLinkAgePutCommand : RFJenisLinkAgePutRequestDto, IRequest<ServiceResponse<RFJenisLinkAgeResponseDto>>
    {
    }

    public class PutRFJenisLinkAgeCommandHandler : IRequestHandler<RFJenisLinkAgePutCommand, ServiceResponse<RFJenisLinkAgeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisLinkAge> _RFJenisLinkAge;
        private readonly IMapper _mapper;

        public PutRFJenisLinkAgeCommandHandler(IGenericRepositoryAsync<RFJenisLinkAge> RFJenisLinkAge, IMapper mapper)
        {
            _RFJenisLinkAge = RFJenisLinkAge;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisLinkAgeResponseDto>> Handle(RFJenisLinkAgePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisLinkAge = await _RFJenisLinkAge.GetByIdAsync(request.JenisLinkAgeCode, "JenisLinkAgeCode");

                existingRFJenisLinkAge.JenisLinkAgeDesc = request.JenisLinkAgeDesc;
                existingRFJenisLinkAge.Active = request.Active;
                await _RFJenisLinkAge.UpdateAsync(existingRFJenisLinkAge);

                var response = _mapper.Map<RFJenisLinkAgeResponseDto>(existingRFJenisLinkAge);

                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}