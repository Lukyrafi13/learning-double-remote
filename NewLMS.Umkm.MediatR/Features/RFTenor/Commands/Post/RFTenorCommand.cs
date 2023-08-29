using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenors.Commands
{
    public class RFTenorPostCommand : RFTenorPostRequestDto, IRequest<ServiceResponse<RFTenorResponseDto>>
    {

    }
    public class PostRFTenorCommandHandler : IRequestHandler<RFTenorPostCommand, ServiceResponse<RFTenorResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public PostRFTenorCommandHandler(IGenericRepositoryAsync<RFTenor> RFTenor, IMapper mapper)
        {
            _RFTenor = RFTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTenorResponseDto>> Handle(RFTenorPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTenor = _mapper.Map<RFTenor>(request);

                var returnedRFTenor = await _RFTenor.AddAsync(RFTenor, callSave: false);

                // var response = _mapper.Map<RFTenorResponseDto>(returnedRFTenor);
                var response = _mapper.Map<RFTenorResponseDto>(returnedRFTenor);

                await _RFTenor.SaveChangeAsync();
                return ServiceResponse<RFTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}