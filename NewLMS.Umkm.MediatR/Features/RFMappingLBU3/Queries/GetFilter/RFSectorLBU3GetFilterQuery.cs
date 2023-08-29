using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Queries
{
    public class RfSectorLBU3sGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
        public string RfSectorLBU2Code { get; set; }
        public string ProductId { get; set; }
    }

    public class RfSectorLBU3sGetFilterQueryHandler : IRequestHandler<RfSectorLBU3sGetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
        private IGenericRepositoryAsync<RfProduct> _RfProduct;
        private IGenericRepositoryAsync<RfSectorLBU2> _RfSectorLBU2;
        private IGenericRepositoryAsync<RfSectorLBU3> _RfSectorLBU3;
        private IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public RfSectorLBU3sGetFilterQueryHandler(
            IGenericRepositoryAsync<RfProduct> RfProduct,
            IGenericRepositoryAsync<RfSectorLBU2> RfSectorLBU2,
            IGenericRepositoryAsync<RfSectorLBU3> RfSectorLBU3,
            IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3,
            IMapper mapper)
        {
            _RfProduct = RfProduct;
            _RfSectorLBU2 = RfSectorLBU2;
            _RfSectorLBU3 = RfSectorLBU3;
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU3Response>>> Handle(RfSectorLBU3sGetFilterQuery request, CancellationToken cancellationToken)
        {
            var SubSector = await _RfSectorLBU2.GetByIdAsync(request.RfSectorLBU2Code, "Code");
            // var Product = await _RfProduct.GetByIdAsync(request.ProductId, "ProductId");
            var includes = new string[]{
            };
            
            var SubSubSectors = await _RFMappingLBU3.GetListByPredicate(x => x.ProductId == request.ProductId);
            var SubSubSectorIds = SubSubSectors.Select(x => x.LBU3Code).ToArray();

            var data = await _RfSectorLBU3.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfSectorLBU3Response>>(data.Results);
            IEnumerable<RfSectorLBU3Response> dataVm;
            var listResponse = new List<RfSectorLBU3Response>();

            foreach (var res in data.Results){
                if (!SubSubSectorIds.Contains(res.Code)){
                    continue;
                }

                var response = _mapper.Map<RfSectorLBU3Response>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfSectorLBU3Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}