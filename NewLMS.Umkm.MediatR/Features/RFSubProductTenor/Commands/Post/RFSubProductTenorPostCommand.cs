using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Commands
{
    public class RFSubProductTenorPostCommand : RFSubProductTenorPostRequestDto, IRequest<ServiceResponse<RFSubProductTenorResponseDto>>
    {

    }
    public class PostRFSubProductTenorCommandHandler : IRequestHandler<RFSubProductTenorPostCommand, ServiceResponse<RFSubProductTenorResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private readonly IMapper _mapper;

        public PostRFSubProductTenorCommandHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper)
        {
            _RFSubProductTenor = RFSubProductTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductTenorResponseDto>> Handle(RFSubProductTenorPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSubProductTenor = _mapper.Map<RFSubProductTenor>(request);

                var returnedRFSubProductTenor = await _RFSubProductTenor.AddAsync(RFSubProductTenor, callSave: false);

                // var response = _mapper.Map<RFSubProductTenorResponseDto>(returnedRFSubProductTenor);
                var response = _mapper.Map<RFSubProductTenorResponseDto>(returnedRFSubProductTenor);

                await _RFSubProductTenor.SaveChangeAsync();
                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}