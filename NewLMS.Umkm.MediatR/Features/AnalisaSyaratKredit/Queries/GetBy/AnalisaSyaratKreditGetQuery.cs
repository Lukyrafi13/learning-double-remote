using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Queries
{
    public class AnalisaSyaratKreditGetQuery : AnalisaSyaratKreditFindRequestDto, IRequest<ServiceResponse<AnalisaSyaratKreditResponseDto>>
    {
    }

    public class AnalisaSyaratKreditGetQueryHandler : IRequestHandler<AnalisaSyaratKreditGetQuery, ServiceResponse<AnalisaSyaratKreditResponseDto>>
    {
        private IGenericRepositoryAsync<AnalisaSyaratKredit> _AnalisaSyaratKredit;
        private readonly IMapper _mapper;

        public AnalisaSyaratKreditGetQueryHandler(IGenericRepositoryAsync<AnalisaSyaratKredit> AnalisaSyaratKredit, IMapper mapper)
        {
            _AnalisaSyaratKredit = AnalisaSyaratKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AnalisaSyaratKreditResponseDto>> Handle(AnalisaSyaratKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Analisa",
                    "Analisa.Survey",
                    "JenisSyaratKredit",
                    "Decision",
                };

                var data = await _AnalisaSyaratKredit.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaSyaratKreditResponseDto>.Return404("Data AnalisaSyaratKredit not found");
                var response = _mapper.Map<AnalisaSyaratKreditResponseDto>(data);
                return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}