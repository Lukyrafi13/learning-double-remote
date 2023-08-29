using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaPinjamanDariBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AnalisaPinjamanDariBanks.Queries
{
    public class AnalisaPinjamanDariBankGetQuery : AnalisaPinjamanDariBankFindRequestDto, IRequest<ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {
    }

    public class AnalisaPinjamanDariBankGetQueryHandler : IRequestHandler<AnalisaPinjamanDariBankGetQuery, ServiceResponse<AnalisaPinjamanDariBankResponseDto>>
    {
        private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public AnalisaPinjamanDariBankGetQueryHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper)
        {
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AnalisaPinjamanDariBankResponseDto>> Handle(AnalisaPinjamanDariBankGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Analisa",
                    "Analisa.Survey",
                    "TujuanPinjaman",
                };

                var data = await _AnalisaPinjamanDariBank.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.Return404("Data AnalisaPinjamanDariBank not found");
                var response = _mapper.Map<AnalisaPinjamanDariBankResponseDto>(data);
                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaPinjamanDariBankResponseDto>.ReturnException(ex);
            }
        }
    }
}