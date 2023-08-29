using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductInts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductInts.Commands
{
    public class RFSubProductIntPostCommand : RFSubProductIntPostRequestDto, IRequest<ServiceResponse<RFSubProductIntResponseDto>>
    {

    }
    public class PostRFSubProductIntCommandHandler : IRequestHandler<RFSubProductIntPostCommand, ServiceResponse<RFSubProductIntResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductInt> _RFSubProductInt;
        private readonly IMapper _mapper;

        public PostRFSubProductIntCommandHandler(IGenericRepositoryAsync<RFSubProductInt> RFSubProductInt, IMapper mapper)
        {
            _RFSubProductInt = RFSubProductInt;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductIntResponseDto>> Handle(RFSubProductIntPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSubProductInt = _mapper.Map<RFSubProductInt>(request);

                var returnedRFSubProductInt = await _RFSubProductInt.AddAsync(RFSubProductInt, callSave: false);

                // var response = _mapper.Map<RFSubProductIntResponseDto>(returnedRFSubProductInt);
                var response = _mapper.Map<RFSubProductIntResponseDto>(returnedRFSubProductInt);

                await _RFSubProductInt.SaveChangeAsync();
                return ServiceResponse<RFSubProductIntResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductIntResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}