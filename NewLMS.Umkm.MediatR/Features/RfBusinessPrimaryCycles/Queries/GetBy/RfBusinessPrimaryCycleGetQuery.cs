using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycles.Queries
{
    public class RfBusinessPrimaryCycleGetQuery : RfBusinesPrimaryCycleFindRequestDto, IRequest<ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {
    }

    public class RfBusinessPrimaryCiclusGetQueryHandler : IRequestHandler<RfBusinessPrimaryCycleGetQuery, ServiceResponse<RfBusinessPrimaryCicleResponseDto>>
    {
        private IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RfBusinessPrimaryCiclusGetQueryHandler(IGenericRepositoryAsync<RfBusinessPrimaryCycle> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfBusinessPrimaryCicleResponseDto>> Handle(RfBusinessPrimaryCycleGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFSiklusUsahaPokok.GetByIdAsync(request.CycleCode, "CyclusCode");
                if (data == null)
                    return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.Return404("Data RFSiklusUsahaPokok not found");
                var response = _mapper.Map<RfBusinessPrimaryCicleResponseDto>(data);
                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfBusinessPrimaryCicleResponseDto>.ReturnException(ex);
            }
        }
    }
}