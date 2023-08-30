using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycles.Commands
{
    public class RfBusinessPrimaryCyclePutCommand : RFSiklusUsahaPokokPutRequestDto, IRequest<ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {
    }

    public class RfBusinessPrimaryCiclusPutCommandHandler : IRequestHandler<RfBusinessPrimaryCyclePutCommand, ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RfBusinessPrimaryCiclusPutCommandHandler(IGenericRepositoryAsync<RfBusinessPrimaryCycle> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBusinessPrimaryCicleResponseDto>> Handle(RfBusinessPrimaryCyclePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSiklusUsahaPokok = await _RFSiklusUsahaPokok.GetByIdAsync(request.CycleCode, "CyclusCode");
                
                existingRFSiklusUsahaPokok.CycleDesc = request.CycleDesc;
                existingRFSiklusUsahaPokok.CoreCode = request.CoreCode;
                existingRFSiklusUsahaPokok.Active = request.Active;

                await _RFSiklusUsahaPokok.UpdateAsync(existingRFSiklusUsahaPokok);

                var response = _mapper.Map<RfBusinessPrimaryCicleResponseDto>(existingRFSiklusUsahaPokok);

                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}