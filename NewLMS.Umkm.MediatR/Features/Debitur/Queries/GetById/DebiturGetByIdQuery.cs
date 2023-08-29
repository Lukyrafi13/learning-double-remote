using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Debiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Debiturs.Queries
{
    public class DebitursGetByIdQuery : DebiturFindRequestDto, IRequest<ServiceResponse<DebiturResponseDto>>
    {
    }

    public class GetByIdDebiturQueryHandler : IRequestHandler<DebitursGetByIdQuery, ServiceResponse<DebiturResponseDto>>
    {
        private IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IMapper _mapper;

        public GetByIdDebiturQueryHandler(IGenericRepositoryAsync<Debitur> debitur, IMapper mapper)
        {
            _debitur = debitur;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<DebiturResponseDto>> Handle(DebitursGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var debitur = await _debitur.GetByIdAsync(request.Id, "Id");
                if (debitur == null)
                    return ServiceResponse<DebiturResponseDto>.Return404("Data Debitur not found");
                var response = _mapper.Map<DebiturResponseDto>(debitur);
                
                return ServiceResponse<DebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DebiturResponseDto>.ReturnException(ex);
            }
        }
    }
}