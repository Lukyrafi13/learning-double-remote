using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Queries
{
    public class RFSiklusUsahaPokokGetQuery : RFSiklusUsahaPokokFindRequestDto, IRequest<ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {
    }

    public class RFSiklusUsahaPokokGetQueryHandler : IRequestHandler<RFSiklusUsahaPokokGetQuery, ServiceResponse<RFSiklusUsahaPokokResponseDto>>
    {
        private IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RFSiklusUsahaPokokGetQueryHandler(IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSiklusUsahaPokokResponseDto>> Handle(RFSiklusUsahaPokokGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFSiklusUsahaPokok.GetByIdAsync(request.SiklusCode, "SiklusCode");
                if (data == null)
                    return ServiceResponse<RFSiklusUsahaPokokResponseDto>.Return404("Data RFSiklusUsahaPokok not found");
                var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(data);
                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaPokokResponseDto>.ReturnException(ex);
            }
        }
    }
}