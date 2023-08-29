using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTenors;
using System.Collections.Generic;
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Queries
{
    public class RFSubProductTenorGetSubProductIdQuery : IRequest<ServiceResponse<RFSubProductTenorDetailResponseDto>>
    {
        public string SubProductId { get; set; }
    }

    public class RFSubProductTenorGetSubProductIdQueryHandler : IRequestHandler<RFSubProductTenorGetSubProductIdQuery, ServiceResponse<RFSubProductTenorDetailResponseDto>>
    {
        private IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public RFSubProductTenorGetSubProductIdQueryHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper, IGenericRepositoryAsync<RFTenor> rFTenor)
        {
            _RFSubProductTenor = RFSubProductTenor;
            _RFTenor = rFTenor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSubProductTenorDetailResponseDto>> Handle(RFSubProductTenorGetSubProductIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSubProductTenor.GetListByPredicate(x => x.SubProductId == request.SubProductId);
                if (data == null)
                    return ServiceResponse<RFSubProductTenorDetailResponseDto>.Return404("Data RFSubProductTenor not found");
                var response = _mapper.Map<RFSubProductTenorDetailResponseDto>(data.Find(x => x != null));

                foreach (RFSubProductTenor subProductTenor in data)
                {
                    var tenor = await _RFTenor.GetByPredicate(x => x.TNCode == subProductTenor.TNCode);
                    if (tenor != null)
                    {
                        var tenorResponse = _mapper.Map<RFTenorShortResponseDto>(tenor);
                        response.Tenors.Add(tenorResponse);
                    }
                }

                response.Tenors = response.Tenors.OrderBy(x=> x.Tenor).ToList();

                return ServiceResponse<RFSubProductTenorDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductTenorDetailResponseDto>.ReturnException(ex);
            }
        }
    }
}