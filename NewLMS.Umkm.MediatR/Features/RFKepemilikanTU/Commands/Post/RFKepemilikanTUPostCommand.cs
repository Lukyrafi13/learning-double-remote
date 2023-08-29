using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Commands
{
    public class RFKepemilikanTUPostCommand : RFKepemilikanTUPostRequestDto, IRequest<ServiceResponse<RFKepemilikanTUResponseDto>>
    {

    }
    public class PostRFKepemilikanTUCommandHandler : IRequestHandler<RFKepemilikanTUPostCommand, ServiceResponse<RFKepemilikanTUResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanTU> _RFKepemilikanTU;
        private readonly IMapper _mapper;

        public PostRFKepemilikanTUCommandHandler(IGenericRepositoryAsync<RFKepemilikanTU> RFKepemilikanTU, IMapper mapper)
        {
            _RFKepemilikanTU = RFKepemilikanTU;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKepemilikanTUResponseDto>> Handle(RFKepemilikanTUPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFKepemilikanTU = _mapper.Map<RFKepemilikanTU>(request);

                var returnedRFKepemilikanTU = await _RFKepemilikanTU.AddAsync(RFKepemilikanTU, callSave: false);

                // var response = _mapper.Map<RFKepemilikanTUResponseDto>(returnedRFKepemilikanTU);
                var response = _mapper.Map<RFKepemilikanTUResponseDto>(returnedRFKepemilikanTU);

                await _RFKepemilikanTU.SaveChangeAsync();
                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}