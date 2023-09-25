using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappingDocumentPrescreenings;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfMappings.Queries
{
    public class RfMappingDocumentPrescreeningQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMappingDocumentPrescreeningResponse>>>
    {
    }

    public class RfMappinsDocumentPrescreeningQueryHandler : IRequestHandler<RfMappingDocumentPrescreeningQuery, PagedResponse<IEnumerable<RfMappingDocumentPrescreeningResponse>>>
    {
        private IGenericRepositoryAsync<RfMappingDocumentPrescreening> _rfMappingDocumentPrescreening;
        private readonly IMapper _mapper;

        public RfMappinsDocumentPrescreeningQueryHandler(IGenericRepositoryAsync<RfMappingDocumentPrescreening> rfMappingDocumentPrescreening, IMapper mapper)
        {
            _rfMappingDocumentPrescreening = rfMappingDocumentPrescreening;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMappingDocumentPrescreeningResponse>>> Handle(RfMappingDocumentPrescreeningQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
                "OwnerCategory",
                "RfDocument",
            };
            var data = await _rfMappingDocumentPrescreening.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfMappingDocumentPrescreeningResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMappingDocumentPrescreeningResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
