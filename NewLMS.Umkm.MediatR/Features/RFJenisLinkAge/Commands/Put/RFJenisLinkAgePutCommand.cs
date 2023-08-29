using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Commands
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