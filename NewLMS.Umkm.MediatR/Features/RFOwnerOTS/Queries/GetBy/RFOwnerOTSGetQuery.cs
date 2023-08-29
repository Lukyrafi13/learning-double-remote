using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerOTSs.Queries
{
    public class RFOwnerOTSGetQuery : RFOwnerOTSFindRequestDto, IRequest<ServiceResponse<RFOwnerOTSResponseDto>>
    {
    }

    public class RFOwnerOTSGetQueryHandler : IRequestHandler<RFOwnerOTSGetQuery, ServiceResponse<RFOwnerOTSResponseDto>>
    {
        private IGenericRepositoryAsync<RFOwnerOTS> _RFOwnerOTS;
        private readonly IMapper _mapper;

        public RFOwnerOTSGetQueryHandler(IGenericRepositoryAsync<RFOwnerOTS> RFOwnerOTS, IMapper mapper)
        {
            _RFOwnerOTS = RFOwnerOTS;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFOwnerOTSResponseDto>> Handle(RFOwnerOTSGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFOwnerOTS.GetByIdAsync(request.OWN_CODE, "OWN_CODE");
                if (data == null)
                    return ServiceResponse<RFOwnerOTSResponseDto>.Return404("Data RFOwnerOTS not found");
                var response = _mapper.Map<RFOwnerOTSResponseDto>(data);
                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnException(ex);
            }
        }
    }
}