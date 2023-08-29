using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Commands
{
    public class RFJenisUsahaMapPostCommand : RFJenisUsahaMapPostRequestDto, IRequest<ServiceResponse<RFJenisUsahaMapResponseDto>>
    {

    }
    public class PostRFJenisUsahaMapCommandHandler : IRequestHandler<RFJenisUsahaMapPostCommand, ServiceResponse<RFJenisUsahaMapResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
        private readonly IMapper _mapper;

        public PostRFJenisUsahaMapCommandHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaMapResponseDto>> Handle(RFJenisUsahaMapPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisUsahaMap = _mapper.Map<RFJenisUsahaMap>(request);

                var returnedRFJenisUsahaMap = await _RFJenisUsahaMap.AddAsync(RFJenisUsahaMap, callSave: false);

                // var response = _mapper.Map<RFJenisUsahaMapResponseDto>(returnedRFJenisUsahaMap);
                var response = _mapper.Map<RFJenisUsahaMapResponseDto>(returnedRFJenisUsahaMap);

                await _RFJenisUsahaMap.SaveChangeAsync();
                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}