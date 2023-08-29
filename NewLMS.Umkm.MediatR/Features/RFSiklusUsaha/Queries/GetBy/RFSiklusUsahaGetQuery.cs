using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSiklusUsahas.Queries
{
    public class RFSiklusUsahaGetQuery : RFSiklusUsahaFindRequestDto, IRequest<ServiceResponse<RFSiklusUsahaResponseDto>>
    {
    }

    public class RFSiklusUsahaGetQueryHandler : IRequestHandler<RFSiklusUsahaGetQuery, ServiceResponse<RFSiklusUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFSiklusUsaha> _RFSiklusUsaha;
        private readonly IMapper _mapper;

        public RFSiklusUsahaGetQueryHandler(IGenericRepositoryAsync<RFSiklusUsaha> RFSiklusUsaha, IMapper mapper)
        {
            _RFSiklusUsaha = RFSiklusUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSiklusUsahaResponseDto>> Handle(RFSiklusUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFSiklusUsaha.GetByIdAsync(request.SiklusCode, "SiklusCode");
                if (data == null)
                    return ServiceResponse<RFSiklusUsahaResponseDto>.Return404("Data RFSiklusUsaha not found");
                var response = _mapper.Map<RFSiklusUsahaResponseDto>(data);
                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSiklusUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}