using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycle;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycle.Commands
{
    public class RfBusinessPrimaryCiclePostCommand : RfBusinessPrimaryCiclusPostRequestDto, IRequest<ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {

    }
    public class RfBusinessPrimaryCiclusPostCommandHandler : IRequestHandler<RfBusinessPrimaryCiclePostCommand, ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RfBusinessPrimaryCiclusPostCommandHandler(IGenericRepositoryAsync<RfBusinessPrimaryCycle> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfBusinessPrimaryCicleResponseDto>> Handle(RfBusinessPrimaryCiclePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSiklusUsahaPokok = _mapper.Map<RfBusinessPrimaryCycle>(request);

                var returnedRFSiklusUsahaPokok = await _RFSiklusUsahaPokok.AddAsync(RFSiklusUsahaPokok, callSave: false);

                // var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(returnedRFSiklusUsahaPokok);
                var response = _mapper.Map<RfBusinessPrimaryCicleResponseDto>(returnedRFSiklusUsahaPokok);

                await _RFSiklusUsahaPokok.SaveChangeAsync();
                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}