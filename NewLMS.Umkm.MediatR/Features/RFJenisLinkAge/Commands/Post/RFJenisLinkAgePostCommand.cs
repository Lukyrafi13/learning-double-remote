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
    public class RFJenisLinkAgePostCommand : RFJenisLinkAgePostRequestDto, IRequest<ServiceResponse<RFJenisLinkAgeResponseDto>>
    {

    }
    public class RFJenisLinkAgePostCommandHandler : IRequestHandler<RFJenisLinkAgePostCommand, ServiceResponse<RFJenisLinkAgeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisLinkAge> _RFJenisLinkAge;
        private readonly IMapper _mapper;

        public RFJenisLinkAgePostCommandHandler(IGenericRepositoryAsync<RFJenisLinkAge> RFJenisLinkAge, IMapper mapper)
        {
            _RFJenisLinkAge = RFJenisLinkAge;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisLinkAgeResponseDto>> Handle(RFJenisLinkAgePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisLinkAge = _mapper.Map<RFJenisLinkAge>(request);

                var returnedRFJenisLinkAge = await _RFJenisLinkAge.AddAsync(RFJenisLinkAge, callSave: false);

                // var response = _mapper.Map<RFJenisLinkAgeResponseDto>(returnedRFJenisLinkAge);
                var response = _mapper.Map<RFJenisLinkAgeResponseDto>(returnedRFJenisLinkAge);

                await _RFJenisLinkAge.SaveChangeAsync();
                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}