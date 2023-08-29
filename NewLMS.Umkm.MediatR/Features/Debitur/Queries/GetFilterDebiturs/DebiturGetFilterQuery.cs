using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Debiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Debiturs.Queries
{
    public class DebitursGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<DebiturResponseDto>>>
    {
    }

    public class GetFilterDebiturQueryHandler : IRequestHandler<DebitursGetFilterQuery, PagedResponse<IEnumerable<DebiturResponseDto>>>
    {
        private IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IMapper _mapper;

        public GetFilterDebiturQueryHandler(IGenericRepositoryAsync<Debitur> debitur, IGenericRepositoryAsync<RFGender> jenisKelamin, IMapper mapper)
        {
            _debitur = debitur;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<DebiturResponseDto>>> Handle(DebitursGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "JenisKelamin"
            };
            var data = await _debitur.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<DebiturResponseDto>>(data.Results);
            IEnumerable<DebiturResponseDto> dataVm;
            var listResponse = new List<DebiturResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<DebiturResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<DebiturResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}