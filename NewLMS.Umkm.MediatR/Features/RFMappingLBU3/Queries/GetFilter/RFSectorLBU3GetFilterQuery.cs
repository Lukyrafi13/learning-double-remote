using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using System;
using System.Linq;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Queries
{
    public class RFSectorLBU3sGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSectorLBU3Response>>>
    {
        public string RFSectorLBU2Code { get; set; }
        public string ProductId { get; set; }
    }

    public class RFSectorLBU3sGetFilterQueryHandler : IRequestHandler<RFSectorLBU3sGetFilterQuery, PagedResponse<IEnumerable<RFSectorLBU3Response>>>
    {
        private IGenericRepositoryAsync<RFProduct> _RFProduct;
        private IGenericRepositoryAsync<RFSectorLBU2> _RFSectorLBU2;
        private IGenericRepositoryAsync<RFSectorLBU3> _RFSectorLBU3;
        private IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public RFSectorLBU3sGetFilterQueryHandler(
            IGenericRepositoryAsync<RFProduct> RFProduct,
            IGenericRepositoryAsync<RFSectorLBU2> RFSectorLBU2,
            IGenericRepositoryAsync<RFSectorLBU3> RFSectorLBU3,
            IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3,
            IMapper mapper)
        {
            _RFProduct = RFProduct;
            _RFSectorLBU2 = RFSectorLBU2;
            _RFSectorLBU3 = RFSectorLBU3;
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSectorLBU3Response>>> Handle(RFSectorLBU3sGetFilterQuery request, CancellationToken cancellationToken)
        {
            var SubSector = await _RFSectorLBU2.GetByIdAsync(request.RFSectorLBU2Code, "Code");
            // var Product = await _RFProduct.GetByIdAsync(request.ProductId, "ProductId");
            var includes = new string[]{
            };
            
            var SubSubSectors = await _RFMappingLBU3.GetListByPredicate(x => x.ProductId == request.ProductId);
            var SubSubSectorIds = SubSubSectors.Select(x => x.LBU3Code).ToArray();

            var data = await _RFSectorLBU3.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSectorLBU3Response>>(data.Results);
            IEnumerable<RFSectorLBU3Response> dataVm;
            var listResponse = new List<RFSectorLBU3Response>();

            foreach (var res in data.Results){
                if (!SubSubSectorIds.Contains(res.Code)){
                    continue;
                }

                var response = _mapper.Map<RFSectorLBU3Response>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSectorLBU3Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}