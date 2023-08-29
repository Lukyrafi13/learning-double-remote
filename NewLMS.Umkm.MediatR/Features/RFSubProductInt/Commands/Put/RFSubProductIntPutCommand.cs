using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProductInts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductInts.Commands
{
    public class RFSubProductIntPutCommand : RFSubProductIntPutRequestDto, IRequest<ServiceResponse<RFSubProductIntResponseDto>>
    {
    }

    public class PutRFSubProductIntCommandHandler : IRequestHandler<RFSubProductIntPutCommand, ServiceResponse<RFSubProductIntResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductInt> _RFSubProductInt;
        private readonly IMapper _mapper;

        public PutRFSubProductIntCommandHandler(IGenericRepositoryAsync<RFSubProductInt> RFSubProductInt, IMapper mapper){
            _RFSubProductInt = RFSubProductInt;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductIntResponseDto>> Handle(RFSubProductIntPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSubProductInt = await _RFSubProductInt.GetByIdAsync(request.TPLCode, "TPLCode");

                existingRFSubProductInt = _mapper.Map<RFSubProductIntPutRequestDto, RFSubProductInt>(request, existingRFSubProductInt);

                await _RFSubProductInt.UpdateAsync(existingRFSubProductInt);

                var response = _mapper.Map<RFSubProductIntResponseDto>(existingRFSubProductInt);

                return ServiceResponse<RFSubProductIntResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductIntResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}