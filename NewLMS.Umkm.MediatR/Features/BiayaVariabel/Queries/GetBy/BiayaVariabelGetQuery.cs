using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabels.Queries
{
    public class BiayaVariabelGetQuery : BiayaVariabelFindRequestDto, IRequest<ServiceResponse<BiayaVariabelResponseDto>>
    {
    }

    public class BiayaVariabelGetQueryHandler : IRequestHandler<BiayaVariabelGetQuery, ServiceResponse<BiayaVariabelResponseDto>>
    {
        private IGenericRepositoryAsync<BiayaVariabel> _BiayaVariabel;
        private readonly IMapper _mapper;

        public BiayaVariabelGetQueryHandler(IGenericRepositoryAsync<BiayaVariabel> BiayaVariabel, IMapper mapper)
        {
            _BiayaVariabel = BiayaVariabel;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<BiayaVariabelResponseDto>> Handle(BiayaVariabelGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _BiayaVariabel.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<BiayaVariabelResponseDto>.Return404("Data BiayaVariabel not found");
                var response = _mapper.Map<BiayaVariabelResponseDto>(data);
                return ServiceResponse<BiayaVariabelResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaVariabelResponseDto>.ReturnException(ex);
            }
        }
    }
}