using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Queries
{
    public class AnalisaFasilitassGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaFasilitasResponseDto>>>
    {
    }

    public class GetFilterAnalisaFasilitasQueryHandler : IRequestHandler<AnalisaFasilitassGetFilterQuery, PagedResponse<IEnumerable<AnalisaFasilitasResponseDto>>>
    {
        private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public GetFilterAnalisaFasilitasQueryHandler(IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas, IMapper mapper)
        {
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AnalisaFasilitasResponseDto>>> Handle(AnalisaFasilitassGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "Analisa",
                    "Analisa.Survey",
                    "JangkaWaktu",
                    "SkimKredit",
                };

            var data = await _AnalisaFasilitas.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<AnalisaFasilitasResponseDto>>(data.Results);
            IEnumerable<AnalisaFasilitasResponseDto> dataVm;
            var listResponse = new List<AnalisaFasilitasResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<AnalisaFasilitasResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<AnalisaFasilitasResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}