using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaInvestasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.BiayaInvestasis.Queries
{
    public class BiayaInvestasiGetQuery : BiayaInvestasiFindRequestDto, IRequest<ServiceResponse<BiayaInvestasiResponseDto>>
    {
    }

    public class BiayaInvestasiGetQueryHandler : IRequestHandler<BiayaInvestasiGetQuery, ServiceResponse<BiayaInvestasiResponseDto>>
    {
        private IGenericRepositoryAsync<BiayaInvestasi> _BiayaInvestasi;
        private readonly IMapper _mapper;

        public BiayaInvestasiGetQueryHandler(IGenericRepositoryAsync<BiayaInvestasi> BiayaInvestasi, IMapper mapper)
        {
            _BiayaInvestasi = BiayaInvestasi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<BiayaInvestasiResponseDto>> Handle(BiayaInvestasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _BiayaInvestasi.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<BiayaInvestasiResponseDto>.Return404("Data BiayaInvestasi not found");
                var response = _mapper.Map<BiayaInvestasiResponseDto>(data);
                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnException(ex);
            }
        }
    }
}