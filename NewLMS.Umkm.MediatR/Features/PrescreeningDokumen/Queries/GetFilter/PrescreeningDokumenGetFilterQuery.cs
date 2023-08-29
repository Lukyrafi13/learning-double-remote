using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Queries
{
    public class PrescreeningDokumensGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<PrescreeningDokumenResponseDto>>>
    {
    }

    public class GetFilterPrescreeningDokumenQueryHandler : IRequestHandler<PrescreeningDokumensGetFilterQuery, PagedResponse<IEnumerable<PrescreeningDokumenResponseDto>>>
    {
        private IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
        private IGenericRepositoryAsync<FileDokumen> _FileDokumen;
        private readonly IMapper _mapper;

        public GetFilterPrescreeningDokumenQueryHandler(
            IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen,
            IGenericRepositoryAsync<FileDokumen> FileDokumen,
            IMapper mapper)
        {
            _PrescreeningDokumen = PrescreeningDokumen;
            _FileDokumen = FileDokumen;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PrescreeningDokumenResponseDto>>> Handle(PrescreeningDokumensGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "Prescreening",
                    "Dokumen",
                    "TipeDokumen",
                    "DokumenStatus",
                    "JenisAgunan",
                };

            var data = await _PrescreeningDokumen.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<PrescreeningDokumenResponseDto>>(data.Results);
            IEnumerable<PrescreeningDokumenResponseDto> dataVm;
            var listResponse = new List<PrescreeningDokumenResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<PrescreeningDokumenResponseDto>(res);

                
                var fileDokumens = await _FileDokumen.GetListByPredicate(x => x.PrescreeningDokumenId == res.Id, new string[] { "FileUrl"});
                var listFileDokumens = new List<FileDokumen>();

                foreach (var fileDokumen in fileDokumens){
                    listFileDokumens.Add(fileDokumen);
                }

                response.ListFile = listFileDokumens;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<PrescreeningDokumenResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}